using System;
using System.Drawing;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class frmYouWatch : BaseForm
    {
        public bool IsClosing = false;

        public frmHeader Header = new frmHeader();
        public frmView View = new frmView();

        internal void CheckForClose()
        {
            if (Header.IsClosed && !Header.IsHidden && View.IsClosed && !View.IsHidden)
            {
                this.IsClosing = true;
                Application.Exit();
            }
        }

        public frmYouWatch()
        {
            InitializeComponent();

            nicSystemTray.Text = this.Text;
            nicSystemTray.Icon = this.Icon;
        }
        private void frmYouWatch_Load(object sender, EventArgs e)
        {
            Header.Show(this, View);
        }
        private void frmYouWatch_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nicSystemTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!Header.IsClosed
                    || !View.IsClosed)
                {
                    Header.Close(true);
                    View.Close(true);
                }
                else if (Header.IsClosed
                    && View.IsClosed)
                {
                    Header.Show();
                    Header.WindowState = FormWindowState.Normal;

                    View.Show();
                    View.BringToFront();
                    View.WindowState = FormWindowState.Normal;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Header.Show();
                Header.WindowState = FormWindowState.Normal;

                View.Show();
                View.BringToFront();
                View.WindowState = FormWindowState.Normal;

                Header.Left = (Screen.PrimaryScreen.WorkingArea.Width - Header.Width) / 2;
                Header.Top = (Screen.PrimaryScreen.WorkingArea.Height - Header.Height) / 2;

                View.Left = Header.Left;
                View.Top = Header.Top + Header.Height;
                View.Width = Header.Width;
            }
        }

        private void showHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Header.ShowHide();
        }
        private void showHideViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.View.ShowHide();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsClosing = true;
            Application.Exit();
        }
    }
}
