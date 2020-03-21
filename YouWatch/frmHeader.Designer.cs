namespace YouWatch
{
    partial class frmHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeader));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnGOWeb = new System.Windows.Forms.Button();
            this.btnHideControls = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnGO = new System.Windows.Forms.Button();
            this.trkBar_Opacity = new System.Windows.Forms.TrackBar();
            this.chkShowBorder = new System.Windows.Forms.CheckBox();
            this.chkShowInTaskbar = new System.Windows.Forms.CheckBox();
            this.chkKeepTopOn = new System.Windows.Forms.CheckBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar_Opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnGOWeb);
            this.pnlTop.Controls.Add(this.btnHideControls);
            this.pnlTop.Controls.Add(this.btnCenter);
            this.pnlTop.Controls.Add(this.btnList);
            this.pnlTop.Controls.Add(this.btnGO);
            this.pnlTop.Controls.Add(this.trkBar_Opacity);
            this.pnlTop.Controls.Add(this.chkShowBorder);
            this.pnlTop.Controls.Add(this.chkShowInTaskbar);
            this.pnlTop.Controls.Add(this.chkKeepTopOn);
            this.pnlTop.Controls.Add(this.lblURL);
            this.pnlTop.Controls.Add(this.txtURL);
            this.pnlTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(529, 95);
            this.pnlTop.TabIndex = 2;
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // btnGOWeb
            // 
            this.btnGOWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGOWeb.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGOWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGOWeb.Image = global::YouWatch.Properties.Resources.iconfinder_you_tube_social_media_logo_1078778;
            this.btnGOWeb.Location = new System.Drawing.Point(488, 5);
            this.btnGOWeb.Name = "btnGOWeb";
            this.btnGOWeb.Size = new System.Drawing.Size(35, 31);
            this.btnGOWeb.TabIndex = 1;
            this.btnGOWeb.TabStop = false;
            this.btnGOWeb.UseVisualStyleBackColor = true;
            this.btnGOWeb.Click += new System.EventHandler(this.btnGOWeb_Click);
            // 
            // btnHideControls
            // 
            this.btnHideControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideControls.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHideControls.Image = global::YouWatch.Properties.Resources.iconfinder_view_hide_3671903;
            this.btnHideControls.Location = new System.Drawing.Point(491, 62);
            this.btnHideControls.Name = "btnHideControls";
            this.btnHideControls.Size = new System.Drawing.Size(35, 22);
            this.btnHideControls.TabIndex = 1;
            this.btnHideControls.TabStop = false;
            this.btnHideControls.UseVisualStyleBackColor = true;
            this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCenter.Image = global::YouWatch.Properties.Resources.iconfinder_ic_vertical_align_center_48px_352193;
            this.btnCenter.Location = new System.Drawing.Point(3, 62);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(35, 22);
            this.btnCenter.TabIndex = 1;
            this.btnCenter.TabStop = false;
            this.btnCenter.Text = "•";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnList.Image = global::YouWatch.Properties.Resources.iconfinder_list_118647;
            this.btnList.Location = new System.Drawing.Point(45, 5);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(35, 31);
            this.btnList.TabIndex = 1;
            this.btnList.TabStop = false;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnGO
            // 
            this.btnGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGO.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGO.Image = global::YouWatch.Properties.Resources.iconfinder_tv_show_172610;
            this.btnGO.Location = new System.Drawing.Point(451, 5);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(35, 31);
            this.btnGO.TabIndex = 1;
            this.btnGO.TabStop = false;
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // trkBar_Opacity
            // 
            this.trkBar_Opacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkBar_Opacity.AutoSize = false;
            this.trkBar_Opacity.Cursor = System.Windows.Forms.Cursors.Default;
            this.trkBar_Opacity.Location = new System.Drawing.Point(45, 55);
            this.trkBar_Opacity.Maximum = 100;
            this.trkBar_Opacity.Minimum = 20;
            this.trkBar_Opacity.Name = "trkBar_Opacity";
            this.trkBar_Opacity.Size = new System.Drawing.Size(436, 29);
            this.trkBar_Opacity.TabIndex = 7;
            this.trkBar_Opacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trkBar_Opacity.Value = 100;
            this.trkBar_Opacity.Scroll += new System.EventHandler(this.trkBar_Opacity_Scroll);
            // 
            // chkShowBorder
            // 
            this.chkShowBorder.AutoSize = true;
            this.chkShowBorder.Checked = true;
            this.chkShowBorder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBorder.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowBorder.Location = new System.Drawing.Point(45, 41);
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
            this.chkShowInTaskbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowInTaskbar.Location = new System.Drawing.Point(138, 41);
            this.chkShowInTaskbar.Name = "chkShowInTaskbar";
            this.chkShowInTaskbar.Size = new System.Drawing.Size(106, 17);
            this.chkShowInTaskbar.TabIndex = 3;
            this.chkShowInTaskbar.Text = "Show in Taskbar";
            this.chkShowInTaskbar.UseVisualStyleBackColor = true;
            this.chkShowInTaskbar.CheckedChanged += new System.EventHandler(this.chkShowInTaskbar_CheckedChanged);
            // 
            // chkKeepTopOn
            // 
            this.chkKeepTopOn.AutoSize = true;
            this.chkKeepTopOn.Checked = true;
            this.chkKeepTopOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepTopOn.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkKeepTopOn.Location = new System.Drawing.Point(250, 41);
            this.chkKeepTopOn.Name = "chkKeepTopOn";
            this.chkKeepTopOn.Size = new System.Drawing.Size(73, 17);
            this.chkKeepTopOn.TabIndex = 4;
            this.chkKeepTopOn.Text = "Keep Top";
            this.chkKeepTopOn.UseVisualStyleBackColor = true;
            this.chkKeepTopOn.CheckedChanged += new System.EventHandler(this.chkKeepTopOn_CheckedChanged);
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblURL.Location = new System.Drawing.Point(9, 12);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(36, 17);
            this.lblURL.TabIndex = 2;
            this.lblURL.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtURL.Location = new System.Drawing.Point(81, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(368, 29);
            this.txtURL.TabIndex = 0;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtURL_KeyDown);
            this.txtURL.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtURL_MouseDoubleClick);
            // 
            // frmHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 95);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHeader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouWatch";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHeader_FormClosing);
            this.Load += new System.EventHandler(this.frmHeader_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkBar_Opacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TrackBar trkBar_Opacity;
        private System.Windows.Forms.CheckBox chkShowBorder;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnGOWeb;
        private System.Windows.Forms.CheckBox chkShowInTaskbar;
        private System.Windows.Forms.CheckBox chkKeepTopOn;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnHideControls;
        private System.Windows.Forms.Button btnList;
        public System.Windows.Forms.TextBox txtURL;
    }
}