namespace YouWatch
{
    partial class frmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            this.wbbYouTube = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbbYouTube
            // 
            this.wbbYouTube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbbYouTube.Location = new System.Drawing.Point(0, 0);
            this.wbbYouTube.Margin = new System.Windows.Forms.Padding(0);
            this.wbbYouTube.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbYouTube.Name = "wbbYouTube";
            this.wbbYouTube.ScrollBarsEnabled = false;
            this.wbbYouTube.Size = new System.Drawing.Size(402, 286);
            this.wbbYouTube.TabIndex = 1;
            this.wbbYouTube.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbbYouTube_DocumentCompleted);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 286);
            this.Controls.Add(this.wbbYouTube);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmView";
            this.Text = "YouWatch";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmView_FormClosing);
            this.Load += new System.EventHandler(this.frmView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser wbbYouTube;
    }
}