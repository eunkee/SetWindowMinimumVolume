
namespace SetWindowMinimumVolume
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextBoxNumber = new System.Windows.Forms.TextBox();
            this.ButtonUp = new System.Windows.Forms.Button();
            this.ButtonDown = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxNumber
            // 
            this.TextBoxNumber.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBoxNumber.Location = new System.Drawing.Point(22, 8);
            this.TextBoxNumber.Name = "TextBoxNumber";
            this.TextBoxNumber.Size = new System.Drawing.Size(74, 43);
            this.TextBoxNumber.TabIndex = 0;
            this.TextBoxNumber.Text = "30";
            this.TextBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // ButtonUp
            // 
            this.ButtonUp.Location = new System.Drawing.Point(97, 7);
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.Size = new System.Drawing.Size(42, 23);
            this.ButtonUp.TabIndex = 1;
            this.ButtonUp.Text = "▲";
            this.ButtonUp.UseVisualStyleBackColor = true;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.Location = new System.Drawing.Point(97, 29);
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.Size = new System.Drawing.Size(42, 23);
            this.ButtonDown.TabIndex = 2;
            this.ButtonDown.Text = "▼";
            this.ButtonDown.UseVisualStyleBackColor = true;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Set Minimum-Volume";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShow,
            this.ToolStripMenuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // ToolStripMenuItemShow
            // 
            this.ToolStripMenuItemShow.Name = "ToolStripMenuItemShow";
            this.ToolStripMenuItemShow.Size = new System.Drawing.Size(103, 22);
            this.ToolStripMenuItemShow.Text = "View";
            this.ToolStripMenuItemShow.Click += new System.EventHandler(this.ToolStripMenuItemShow_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(103, 22);
            this.ToolStripMenuItemExit.Text = "Close";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 59);
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.ButtonUp);
            this.Controls.Add(this.TextBoxNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Minimum Volume";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNumber;
        private System.Windows.Forms.Button ButtonUp;
        private System.Windows.Forms.Button ButtonDown;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
    }
}

