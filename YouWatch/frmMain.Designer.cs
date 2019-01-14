namespace YouWatch
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtURL = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkMoveByMouse = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.chkShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.chkKeepRatio = new System.Windows.Forms.CheckBox();
            this.chkKeepTopOn = new System.Windows.Forms.CheckBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.timHider = new System.Windows.Forms.Timer(this.components);
            this.wbbYouTube = new System.Windows.Forms.WebBrowser();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtURL.Location = new System.Drawing.Point(51, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(327, 29);
            this.txtURL.TabIndex = 1;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtURL_KeyDown);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkMoveByMouse);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.chkShowBorder);
            this.pnlTop.Controls.Add(this.chkShowInTaskbar);
            this.pnlTop.Controls.Add(this.chkKeepRatio);
            this.pnlTop.Controls.Add(this.chkKeepTopOn);
            this.pnlTop.Controls.Add(this.btnGO);
            this.pnlTop.Controls.Add(this.lblURL);
            this.pnlTop.Controls.Add(this.txtURL);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(495, 60);
            this.pnlTop.TabIndex = 2;
            // 
            // chkMoveByMouse
            // 
            this.chkMoveByMouse.AutoSize = true;
            this.chkMoveByMouse.Enabled = false;
            this.chkMoveByMouse.Location = new System.Drawing.Point(381, 40);
            this.chkMoveByMouse.Name = "chkMoveByMouse";
            this.chkMoveByMouse.Size = new System.Drawing.Size(103, 17);
            this.chkMoveByMouse.TabIndex = 6;
            this.chkMoveByMouse.Text = "Move By Mouse";
            this.chkMoveByMouse.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(472, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Location = new System.Drawing.Point(453, 7);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(20, 28);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Text = "F";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(434, 7);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 28);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Checked = true;
            this.chkShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBorder.Location = new System.Drawing.Point(12, 41);
            this.chkShowBorder.Name = "chkShowBorder";
            this.chkShowBorder.Size = new System.Drawing.Size(87, 17);
            this.chkShowBorder.TabIndex = 4;
            this.chkShowBorder.Text = "Show Border";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            this.chkShowBorder.CheckedChanged += new System.EventHandler(this.chkShowBorder_CheckedChanged);
            // 
            // chkShowInTaskbar
            // 
            this.chkShowInTaskbar.AutoSize = true;
            this.chkShowInTaskbar.Location = new System.Drawing.Point(105, 41);
            this.chkShowInTaskbar.Name = "chkShowInTaskbar";
            this.chkShowInTaskbar.Size = new System.Drawing.Size(106, 17);
            this.chkShowInTaskbar.TabIndex = 4;
            this.chkShowInTaskbar.Text = "Show in Taskbar";
            this.chkShowInTaskbar.UseVisualStyleBackColor = true;
            this.chkShowInTaskbar.CheckedChanged += new System.EventHandler(this.chkShowInTaskbar_CheckedChanged);
            // 
            // chkKeepRatio
            // 
            this.chkKeepRatio.AutoSize = true;
            this.chkKeepRatio.Location = new System.Drawing.Point(296, 41);
            this.chkKeepRatio.Name = "chkKeepRatio";
            this.chkKeepRatio.Size = new System.Drawing.Size(79, 17);
            this.chkKeepRatio.TabIndex = 4;
            this.chkKeepRatio.Text = "Keep Ratio";
            this.chkKeepRatio.UseVisualStyleBackColor = true;
            this.chkKeepRatio.CheckedChanged += new System.EventHandler(this.chkKeepRatio_CheckedChanged);
            // 
            // chkKeepTopOn
            // 
            this.chkKeepTopOn.AutoSize = true;
            this.chkKeepTopOn.Checked = true;
            this.chkKeepTopOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepTopOn.Location = new System.Drawing.Point(217, 41);
            this.chkKeepTopOn.Name = "chkKeepTopOn";
            this.chkKeepTopOn.Size = new System.Drawing.Size(73, 17);
            this.chkKeepTopOn.TabIndex = 4;
            this.chkKeepTopOn.Text = "Keep Top";
            this.chkKeepTopOn.UseVisualStyleBackColor = true;
            this.chkKeepTopOn.CheckedChanged += new System.EventHandler(this.chkKeepTopOn_CheckedChanged);
            // 
            // btnGO
            // 
            this.btnGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGO.Location = new System.Drawing.Point(384, 6);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(44, 29);
            this.btnGO.TabIndex = 3;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblURL.Location = new System.Drawing.Point(9, 12);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(36, 17);
            this.lblURL.TabIndex = 2;
            this.lblURL.Text = "URL";
            this.lblURL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblURL_MouseClick);
            // 
            // timHider
            // 
            this.timHider.Interval = 1000;
            this.timHider.Tick += new System.EventHandler(this.timHider_Tick);
            // 
            // wbbYouTube
            // 
            this.wbbYouTube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbbYouTube.Location = new System.Drawing.Point(0, 60);
            this.wbbYouTube.Margin = new System.Windows.Forms.Padding(0);
            this.wbbYouTube.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbYouTube.Name = "wbbYouTube";
            this.wbbYouTube.ScrollBarsEnabled = false;
            this.wbbYouTube.Size = new System.Drawing.Size(495, 211);
            this.wbbYouTube.TabIndex = 0;
            this.wbbYouTube.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbbYouTube_DocumentCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 271);
            this.ControlBox = false;
            this.Controls.Add(this.wbbYouTube);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouWatch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeBegin += new System.EventHandler(this.frmMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.MouseEnter += new System.EventHandler(this.frmMain_MouseEnter);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.CheckBox chkKeepTopOn;
        private System.Windows.Forms.Timer timHider;
        private System.Windows.Forms.WebBrowser wbbYouTube;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.CheckBox chkKeepRatio;
        private System.Windows.Forms.CheckBox chkShowInTaskbar;
        private System.Windows.Forms.CheckBox chkMoveByMouse;
    }
}

