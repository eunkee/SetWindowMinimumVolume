using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SetWindowMinimumVolume
{
    public partial class Form1 : Form
    {

        #region 소리 설정
        //출처: https://eskerahn.dk/wordpress/?p=2089
        //추후 다시 연구
        [ComImport]
        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDeviceEnumerator
        {
            void _VtblGap1_1();
            int GetDefaultAudioEndpoint(int dataFlow, int role, out IMMDevice ppDevice);
        }
        private static class MMDeviceEnumeratorFactory
        {
            public static IMMDeviceEnumerator CreateInstance()
            {
                return (IMMDeviceEnumerator)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("BCDE0395-E52F-467C-8E3D-C4579291692E"))); // a MMDeviceEnumerator
            }
        }
        [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDevice
        {
            int Activate([MarshalAs(UnmanagedType.LPStruct)] Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
        }

        [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAudioEndpointVolume
        {
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE RegisterControlChangeNotify(/* [in] */__in IAudioEndpointVolumeCallback *pNotify) = 0;
            int RegisterControlChangeNotify(IntPtr pNotify);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE UnregisterControlChangeNotify(/* [in] */ __in IAudioEndpointVolumeCallback *pNotify) = 0;
            int UnregisterControlChangeNotify(IntPtr pNotify);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetChannelCount(/* [out] */ __out UINT *pnChannelCount) = 0;
            int GetChannelCount(ref uint pnChannelCount);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetMasterVolumeLevel( /* [in] */ __in float fLevelDB,/* [unique][in] */ LPCGUID pguidEventContext) = 0;
            int SetMasterVolumeLevel(float fLevelDB, Guid pguidEventContext);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SetMasterVolumeLevelScalar( /* [in] */ __in float fLevel,/* [unique][in] */ LPCGUID pguidEventContext) = 0;
            int SetMasterVolumeLevelScalar(float fLevel, Guid pguidEventContext);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetMasterVolumeLevel(/* [out] */ __out float *pfLevelDB) = 0;
            int GetMasterVolumeLevel(ref float pfLevelDB);
            //virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetMasterVolumeLevelScalar( /* [out] */ __out float *pfLevel) = 0;
            int GetMasterVolumeLevelScalar(ref float pfLevel);
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        public static void SetSoundVolume(int volume)
        {
            try
            {
                IMMDeviceEnumerator deviceEnumerator = MMDeviceEnumeratorFactory.CreateInstance();
                const int eRender = 0;
                const int eMultimedia = 1;
                deviceEnumerator.GetDefaultAudioEndpoint(eRender, eMultimedia, out IMMDevice speakers);
                speakers.Activate(typeof(IAudioEndpointVolume).GUID, 0, IntPtr.Zero, out object aepv_obj);
                IAudioEndpointVolume aepv = (IAudioEndpointVolume)aepv_obj;
                Guid ZeroGuid = new();

                int res = aepv.SetMasterVolumeLevelScalar(volume / 100f, ZeroGuid);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                System.Diagnostics.Trace.WriteLine(ex.StackTrace);
            }
        }

        public static int GetSoundVolume()
        {
            int volume = 0;

            try
            {
                IMMDeviceEnumerator deviceEnumerator = MMDeviceEnumeratorFactory.CreateInstance();
                const int eRender = 0;
                const int eMultimedia = 1;
                deviceEnumerator.GetDefaultAudioEndpoint(eRender, eMultimedia, out IMMDevice speakers);
                speakers.Activate(typeof(IAudioEndpointVolume).GUID, 0, IntPtr.Zero, out object aepv_obj);
                IAudioEndpointVolume aepv = (IAudioEndpointVolume)aepv_obj;
                float current_v = 0;
                int res = aepv.GetMasterVolumeLevelScalar(ref current_v);
                volume = Convert.ToInt32(current_v * 100f);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                System.Diagnostics.Trace.WriteLine(ex.StackTrace);
            }

            return volume;
        }

        private static bool CheckRunThisProcess()
        {
            bool rslt = false;
            int processcount = 0;
            System.Diagnostics.Process[] procs;
            procs = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process aProc in procs)
            {
                if (aProc.ProcessName.ToString().Equals("SetMinimumVolume"))
                {
                    processcount++;
                    if (processcount > 1)
                    {
                        rslt = true;
                        break;
                    }
                }
            }
            return rslt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckRunThisProcess())
            {
                Application.Exit();
            }

            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void ToolStripMenuItemShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        //트레이아이콘 메뉴 -> Exit
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램이 종료됩니다.", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //종료 될 때 종료 대신 트레이 모드로 진행
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon1.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        //실행 후 보여질 때 트레이 모드로 진행
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Close();
        }

        //타이머 -> 현재 볼륨 확인 설정 값보다 작을 경우 수정
        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool canConvert = int.TryParse(TextBoxNumber.Text, out int SetVolume);
            if (!canConvert)
            {
                return;
            }

            int CurrentVolume = GetSoundVolume();
            if (CurrentVolume < SetVolume)
            {
                SetSoundVolume(SetVolume);
            }
        }

        //설정 숫자 크게
        //100보다 작게
        private void ButtonUp_Click(object sender, EventArgs e)
        {
            bool canConvert = int.TryParse(TextBoxNumber.Text, out int SetVolume);
            if (!canConvert)
            {
                return;
            }

            if (SetVolume < 100)
            {
                SetVolume++;
            }

            TextBoxNumber.Text = SetVolume.ToString();
        }

        //설정 숫자 작게
        //0보다 크게
        private void ButtonDown_Click(object sender, EventArgs e)
        {
            bool canConvert = int.TryParse(TextBoxNumber.Text, out int SetVolume);
            if (!canConvert)
            {
                return;
            }

            if (SetVolume > 0)
            {
                SetVolume--;
            }

            TextBoxNumber.Text = SetVolume.ToString();
        }

        //숫자만 입력받게
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
