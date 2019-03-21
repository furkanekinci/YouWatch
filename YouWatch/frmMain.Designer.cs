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
            this.trkBar_Opacity = new System.Windows.Forms.TrackBar();
            this.chkMoveByMouse = new System.Windows.Forms.CheckBox();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.chkShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.chkKeepRatio = new System.Windows.Forms.CheckBox();
            this.chkKeepTopOn = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnHideControls = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.timHider = new System.Windows.Forms.Timer(this.components);
            this.wbbYouTube = new System.Windows.Forms.WebBrowser();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar_Opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtURL.Location = new System.Drawing.Point(45, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(446, 29);
            this.txtURL.TabIndex = 0;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtURL_KeyDown);
            this.txtURL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtURL_MouseDoubleClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.trkBar_Opacity);
            this.pnlTop.Controls.Add(this.chkMoveByMouse);
            this.pnlTop.Controls.Add(this.chkShowBorder);
            this.pnlTop.Controls.Add(this.chkShowInTaskbar);
            this.pnlTop.Controls.Add(this.chkKeepRatio);
            this.pnlTop.Controls.Add(this.chkKeepTopOn);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.btnHideControls);
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnGO);
            this.pnlTop.Controls.Add(this.lblURL);
            this.pnlTop.Controls.Add(this.txtURL);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(621, 88);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // trkBar_Opacity
            // 
            this.trkBar_Opacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkBar_Opacity.AutoSize = false;
            this.trkBar_Opacity.Location = new System.Drawing.Point(12, 60);
            this.trkBar_Opacity.Maximum = 100;
            this.trkBar_Opacity.Minimum = 20;
            this.trkBar_Opacity.Name = "trkBar_Opacity";
            this.trkBar_Opacity.Size = new System.Drawing.Size(597, 23);
            this.trkBar_Opacity.TabIndex = 7;
            this.trkBar_Opacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.ttp.SetToolTip(this.trkBar_Opacity, "Change form\'s opacity.");
            this.trkBar_Opacity.Value = 100;
            this.trkBar_Opacity.ValueChanged += new System.EventHandler(this.trkBar_Opacity_ValueChanged);
            // 
            // chkMoveByMouse
            // 
            this.chkMoveByMouse.AutoSize = true;
            this.chkMoveByMouse.Enabled = false;
            this.chkMoveByMouse.Location = new System.Drawing.Point(376, 38);
            this.chkMoveByMouse.Name = "chkMoveByMouse";
            this.chkMoveByMouse.Size = new System.Drawing.Size(103, 17);
            this.chkMoveByMouse.TabIndex = 6;
            this.chkMoveByMouse.Text = "Move By Mouse";
            this.chkMoveByMouse.UseVisualStyleBackColor = true;
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Checked = true;
            this.chkShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBorder.Location = new System.Drawing.Point(12, 38);
            this.chkShowBorder.Name = "chkShowBorder";
            this.chkShowBorder.Size = new System.Drawing.Size(87, 17);
            this.chkShowBorder.TabIndex = 2;
            this.chkShowBorder.Text = "Show Border";
            this.chkShowBorder.UseVisualStyleBackColor = true;
            this.chkShowBorder.CheckedChanged += new System.EventHandler(this.chkShowBorder_CheckedChanged);
            // 
            // chkShowInTaskbar
            // 
            this.chkShowInTaskbar.AutoSize = true;
            this.chkShowInTaskbar.Checked = true;
            this.chkShowInTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowInTaskbar.Location = new System.Drawing.Point(105, 38);
            this.chkShowInTaskbar.Name = "chkShowInTaskbar";
            this.chkShowInTaskbar.Size = new System.Drawing.Size(106, 17);
            this.chkShowInTaskbar.TabIndex = 3;
            this.chkShowInTaskbar.Text = "Show in Taskbar";
            this.chkShowInTaskbar.UseVisualStyleBackColor = true;
            this.chkShowInTaskbar.CheckedChanged += new System.EventHandler(this.chkShowInTaskbar_CheckedChanged);
            // 
            // chkKeepRatio
            // 
            this.chkKeepRatio.AutoSize = true;
            this.chkKeepRatio.Location = new System.Drawing.Point(296, 38);
            this.chkKeepRatio.Name = "chkKeepRatio";
            this.chkKeepRatio.Size = new System.Drawing.Size(79, 17);
            this.chkKeepRatio.TabIndex = 5;
            this.chkKeepRatio.Text = "Keep Ratio";
            this.chkKeepRatio.UseVisualStyleBackColor = true;
            this.chkKeepRatio.CheckedChanged += new System.EventHandler(this.chkKeepRatio_CheckedChanged);
            // 
            // chkKeepTopOn
            // 
            this.chkKeepTopOn.AutoSize = true;
            this.chkKeepTopOn.Checked = true;
            this.chkKeepTopOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepTopOn.Location = new System.Drawing.Point(217, 38);
            this.chkKeepTopOn.Name = "chkKeepTopOn";
            this.chkKeepTopOn.Size = new System.Drawing.Size(73, 17);
            this.chkKeepTopOn.TabIndex = 4;
            this.chkKeepTopOn.Text = "Keep Top";
            this.chkKeepTopOn.UseVisualStyleBackColor = true;
            this.chkKeepTopOn.CheckedChanged += new System.EventHandler(this.chkKeepTopOn_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClose.Location = new System.Drawing.Point(596, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "⛝";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMaximize.Location = new System.Drawing.Point(573, 6);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(23, 20);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "↗";
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnHideControls
            // 
            this.btnHideControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHideControls.Location = new System.Drawing.Point(527, 6);
            this.btnHideControls.Name = "btnHideControls";
            this.btnHideControls.Size = new System.Drawing.Size(23, 20);
            this.btnHideControls.TabIndex = 1;
            this.btnHideControls.Text = "▲";
            this.btnHideControls.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHideControls.UseVisualStyleBackColor = true;
            this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMinimize.Location = new System.Drawing.Point(550, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 20);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "↙";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnGO
            // 
            this.btnGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGO.Location = new System.Drawing.Point(491, 6);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(35, 29);
            this.btnGO.TabIndex = 1;
            this.btnGO.Text = "📺";
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
            this.wbbYouTube.Location = new System.Drawing.Point(0, 88);
            this.wbbYouTube.Margin = new System.Windows.Forms.Padding(0);
            this.wbbYouTube.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbYouTube.Name = "wbbYouTube";
            this.wbbYouTube.ScrollBarsEnabled = false;
            this.wbbYouTube.Size = new System.Drawing.Size(621, 287);
            this.wbbYouTube.TabIndex = 0;
            this.wbbYouTube.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbbYouTube_DocumentCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 375);
            this.Controls.Add(this.wbbYouTube);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouWatch";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeBegin += new System.EventHandler(this.frmMain_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseEnter += new System.EventHandler(this.frmMain_MouseEnter);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar_Opacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.CheckBox chkKeepTopOn;
        private System.Windows.Forms.Timer timHider;
        private System.Windows.Forms.WebBrowser wbbYouTube;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.CheckBox chkKeepRatio;
        private System.Windows.Forms.CheckBox chkShowInTaskbar;
        private System.Windows.Forms.CheckBox chkMoveByMouse;
        private System.Windows.Forms.ToolTip ttp;
        private System.Windows.Forms.TrackBar trkBar_Opacity;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnHideControls;
        private System.Windows.Forms.Button btnMinimize;
    }
}

