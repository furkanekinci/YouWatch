namespace YouWatch
{
    partial class frmYouWatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYouWatch));
            this.ctxMnu_Systray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nicSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMnu_Systray.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxMnu_Systray
            // 
            this.ctxMnu_Systray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.showHideViewToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.ctxMnu_Systray.Name = "ctxMnu_Systray";
            this.ctxMnu_Systray.Size = new System.Drawing.Size(182, 76);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showHideToolStripMenuItem.Text = "Show/Hide Controls";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.showHideToolStripMenuItem_Click);
            // 
            // showHideViewToolStripMenuItem
            // 
            this.showHideViewToolStripMenuItem.Name = "showHideViewToolStripMenuItem";
            this.showHideViewToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showHideViewToolStripMenuItem.Text = "Show/Hide View";
            this.showHideViewToolStripMenuItem.Click += new System.EventHandler(this.showHideViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // nicSystemTray
            // 
            this.nicSystemTray.ContextMenuStrip = this.ctxMnu_Systray;
            this.nicSystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("nicSystemTray.Icon")));
            this.nicSystemTray.Text = "YouWatch";
            this.nicSystemTray.Visible = true;
            this.nicSystemTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nicSystemTray_MouseDoubleClick);
            // 
            // frmYouWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 85);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYouWatch";
            this.ShowInTaskbar = false;
            this.Text = "YouWatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmYouWatch_Load);
            this.Shown += new System.EventHandler(this.frmYouWatch_Shown);
            this.ctxMnu_Systray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMnu_Systray;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon nicSystemTray;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHideViewToolStripMenuItem;
    }
}