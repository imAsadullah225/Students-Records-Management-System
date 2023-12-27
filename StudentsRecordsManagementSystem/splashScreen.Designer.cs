namespace StudentsRecordsManagementSystem
{
    partial class splashScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splashDetailsPanel = new System.Windows.Forms.Panel();
            this.splashLoadingLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.splashWaitLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.splashCoprightLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.splashLoadingBar = new Bunifu.Framework.UI.BunifuProgressBar();
            this.splashNamesLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.splashSeparatorDown = new Bunifu.Framework.UI.BunifuSeparator();
            this.splashSeparatorUp = new Bunifu.Framework.UI.BunifuSeparator();
            this.splashTitleLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.splashIconPanel = new System.Windows.Forms.Panel();
            this.splashIcon = new Bunifu.Framework.UI.BunifuImageButton();
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.splashDetailsPanel.SuspendLayout();
            this.splashIconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splashIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // splashDetailsPanel
            // 
            this.splashDetailsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.splashDetailsPanel.Controls.Add(this.splashLoadingLabel);
            this.splashDetailsPanel.Controls.Add(this.splashWaitLabel);
            this.splashDetailsPanel.Controls.Add(this.splashCoprightLabel);
            this.splashDetailsPanel.Controls.Add(this.splashLoadingBar);
            this.splashDetailsPanel.Controls.Add(this.splashNamesLabel);
            this.splashDetailsPanel.Controls.Add(this.splashSeparatorDown);
            this.splashDetailsPanel.Controls.Add(this.splashSeparatorUp);
            this.splashDetailsPanel.Controls.Add(this.splashTitleLabel);
            this.splashDetailsPanel.Controls.Add(this.splashIconPanel);
            this.splashDetailsPanel.Location = new System.Drawing.Point(12, 12);
            this.splashDetailsPanel.Name = "splashDetailsPanel";
            this.splashDetailsPanel.Size = new System.Drawing.Size(488, 488);
            this.splashDetailsPanel.TabIndex = 0;
            // 
            // splashLoadingLabel
            // 
            this.splashLoadingLabel.AutoSize = true;
            this.splashLoadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashLoadingLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashLoadingLabel.ForeColor = System.Drawing.Color.White;
            this.splashLoadingLabel.Location = new System.Drawing.Point(205, 294);
            this.splashLoadingLabel.Name = "splashLoadingLabel";
            this.splashLoadingLabel.Size = new System.Drawing.Size(65, 17);
            this.splashLoadingLabel.TabIndex = 9;
            this.splashLoadingLabel.Text = "Loading...";
            // 
            // splashWaitLabel
            // 
            this.splashWaitLabel.AutoSize = true;
            this.splashWaitLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashWaitLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashWaitLabel.ForeColor = System.Drawing.Color.White;
            this.splashWaitLabel.Location = new System.Drawing.Point(196, 258);
            this.splashWaitLabel.Name = "splashWaitLabel";
            this.splashWaitLabel.Size = new System.Drawing.Size(77, 17);
            this.splashWaitLabel.TabIndex = 8;
            this.splashWaitLabel.Text = "Please Wait";
            // 
            // splashCoprightLabel
            // 
            this.splashCoprightLabel.AutoSize = true;
            this.splashCoprightLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashCoprightLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashCoprightLabel.ForeColor = System.Drawing.Color.White;
            this.splashCoprightLabel.Location = new System.Drawing.Point(69, 441);
            this.splashCoprightLabel.Name = "splashCoprightLabel";
            this.splashCoprightLabel.Size = new System.Drawing.Size(365, 17);
            this.splashCoprightLabel.TabIndex = 7;
            this.splashCoprightLabel.Text = "© 2017-2018 All Right Reserved to their Respective Owners.";
            // 
            // splashLoadingBar
            // 
            this.splashLoadingBar.BackColor = System.Drawing.Color.Gray;
            this.splashLoadingBar.BorderRadius = 6;
            this.splashLoadingBar.Location = new System.Drawing.Point(76, 280);
            this.splashLoadingBar.MaximumValue = 100;
            this.splashLoadingBar.Name = "splashLoadingBar";
            this.splashLoadingBar.ProgressColor = System.Drawing.Color.WhiteSmoke;
            this.splashLoadingBar.Size = new System.Drawing.Size(333, 10);
            this.splashLoadingBar.TabIndex = 6;
            this.splashLoadingBar.Value = 0;
            // 
            // splashNamesLabel
            // 
            this.splashNamesLabel.AutoSize = true;
            this.splashNamesLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashNamesLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashNamesLabel.ForeColor = System.Drawing.Color.White;
            this.splashNamesLabel.Location = new System.Drawing.Point(146, 413);
            this.splashNamesLabel.Name = "splashNamesLabel";
            this.splashNamesLabel.Size = new System.Drawing.Size(209, 17);
            this.splashNamesLabel.TabIndex = 5;
            this.splashNamesLabel.Text = "Design by Muhammad Asadullah";
            // 
            // splashSeparatorDown
            // 
            this.splashSeparatorDown.BackColor = System.Drawing.Color.Transparent;
            this.splashSeparatorDown.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splashSeparatorDown.LineThickness = 1;
            this.splashSeparatorDown.Location = new System.Drawing.Point(49, 329);
            this.splashSeparatorDown.Name = "splashSeparatorDown";
            this.splashSeparatorDown.Size = new System.Drawing.Size(388, 35);
            this.splashSeparatorDown.TabIndex = 4;
            this.splashSeparatorDown.Transparency = 255;
            this.splashSeparatorDown.Vertical = false;
            // 
            // splashSeparatorUp
            // 
            this.splashSeparatorUp.BackColor = System.Drawing.Color.Transparent;
            this.splashSeparatorUp.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splashSeparatorUp.LineThickness = 1;
            this.splashSeparatorUp.Location = new System.Drawing.Point(49, 202);
            this.splashSeparatorUp.Name = "splashSeparatorUp";
            this.splashSeparatorUp.Size = new System.Drawing.Size(388, 35);
            this.splashSeparatorUp.TabIndex = 4;
            this.splashSeparatorUp.Transparency = 255;
            this.splashSeparatorUp.Vertical = false;
            // 
            // splashTitleLabel
            // 
            this.splashTitleLabel.AutoSize = true;
            this.splashTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashTitleLabel.ForeColor = System.Drawing.Color.White;
            this.splashTitleLabel.Location = new System.Drawing.Point(127, 147);
            this.splashTitleLabel.Name = "splashTitleLabel";
            this.splashTitleLabel.Size = new System.Drawing.Size(228, 56);
            this.splashTitleLabel.TabIndex = 3;
            this.splashTitleLabel.Text = "  STUDENTS RECORDS\r\nMANAGEMENT SYSTEM\r\n";
            // 
            // splashIconPanel
            // 
            this.splashIconPanel.BackColor = System.Drawing.Color.Transparent;
            this.splashIconPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splashIconPanel.Controls.Add(this.splashIcon);
            this.splashIconPanel.Location = new System.Drawing.Point(171, 23);
            this.splashIconPanel.Name = "splashIconPanel";
            this.splashIconPanel.Size = new System.Drawing.Size(136, 113);
            this.splashIconPanel.TabIndex = 2;
            // 
            // splashIcon
            // 
            this.splashIcon.BackColor = System.Drawing.Color.Transparent;
            this.splashIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splashIcon.Image = global::StudentsRecordsManagementSystem.Properties.Resources.Graduation_Cap_104px;
            this.splashIcon.ImageActive = null;
            this.splashIcon.Location = new System.Drawing.Point(-1, -1);
            this.splashIcon.Name = "splashIcon";
            this.splashIcon.Size = new System.Drawing.Size(135, 112);
            this.splashIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.splashIcon.TabIndex = 1;
            this.splashIcon.TabStop = false;
            this.splashIcon.Zoom = 10;
            // 
            // splashTimer
            // 
            this.splashTimer.Enabled = true;
            this.splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            // 
            // splashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(107)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.splashDetailsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "splashScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash Screen";
            this.splashDetailsPanel.ResumeLayout(false);
            this.splashDetailsPanel.PerformLayout();
            this.splashIconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splashIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel splashDetailsPanel;
        private Bunifu.Framework.UI.BunifuImageButton splashIcon;
        private System.Windows.Forms.Panel splashIconPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel splashTitleLabel;
        private Bunifu.Framework.UI.BunifuSeparator splashSeparatorUp;
        private Bunifu.Framework.UI.BunifuSeparator splashSeparatorDown;
        private Bunifu.Framework.UI.BunifuCustomLabel splashNamesLabel;
        private Bunifu.Framework.UI.BunifuProgressBar splashLoadingBar;
        private Bunifu.Framework.UI.BunifuCustomLabel splashCoprightLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel splashLoadingLabel;
        private Bunifu.Framework.UI.BunifuCustomLabel splashWaitLabel;
        private System.Windows.Forms.Timer splashTimer;
    }
}

