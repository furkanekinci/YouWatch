using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class frmHeader : BaseForm
    {
        frmYouWatch YouWatch = null;
        frmView View = new frmView();
        frmList List = new frmList();

        #region Shortcut
        const int WM_HOTKEY1 = 786;
        const int WM_HOTKEY2 = 0x0312;

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void ShowHide()
        {
            if (this.IsClosed)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }
        #endregion

        #region Move By Mouse
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }


        private string LastSessionFilePath = "LastSession.dat";

        string YoutubeURLPattern = "https://www.youtube.com/embed/{0}?";
        string EmbedCodePattern = "<html><head><meta http-equiv='X-UA-Compatible' content='IE=edge'><style>*{margin:0px;padding:0px;}</style></head><iframe style='position:absolute; left:0; top:0; width:100%; height:100%' src='@URL@&autoplay=1&showinfo=1&controls=1&autohide=1' frameborder='0' allowfullscreen></iframe></html>";

        private void LoadLastSession()
        {
            if (File.Exists(this.LastSessionFilePath))
            {
                try
                {
                    string lastSession = File.ReadAllText(this.LastSessionFilePath);

                    string[] settings = lastSession.Split('#');
                    string controlName = string.Empty;
                    object value = null;

                    for (int i = 0; i < settings.Length; i++)
                    {
                        try
                        {
                            controlName = settings[i].Split('|')[0];
                            value = settings[i].Split('|')[1];

                            Control cont = this.Controls.Find(controlName, true)[0];

                            if (cont.GetType() == typeof(TextBox))
                            {
                                (cont as TextBox).Text = Convert.ToString(value);
                            }
                            else if (cont.GetType() == typeof(CheckBox))
                            {
                                (cont as CheckBox).Checked = Convert.ToBoolean(value);
                            }
                            else if (cont.GetType() == typeof(TrackBar))
                            {
                                (cont as TrackBar).Value = Convert.ToInt32(value);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void SaveSession()
        {
            try
            {
                string settings = string.Empty;
                settings += string.Format("{0}|{1}#", txtURL.Name, txtURL.Text);
                settings += string.Format("{0}|{1}#", chkShowBorder.Name, chkShowBorder.Checked);
                settings += string.Format("{0}|{1}#", trkBar_Opacity.Name, trkBar_Opacity.Value);

                File.WriteAllText(this.LastSessionFilePath, settings);
            }
            catch
            {

            }
        }

        private string GenerateEmbedCode(string pURL)
        {
            var uri = new Uri(pURL);

            var query = HttpUtility.ParseQueryString(uri.Query);

            #region Video ID
            var videoID = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                videoID = query["v"];
            }
            else
            {
                videoID = uri.Segments.Last();
            }
            #endregion

            string lastURL = string.Format(YoutubeURLPattern, videoID);

            #region Time
            string time = string.Empty;

            if (query.AllKeys.Contains("t"))
            {
                time = query["t"];
            }
            #endregion

            if (!string.IsNullOrEmpty(time))
            {
                lastURL = lastURL + "&start=" + time;
            }

            #region List
            string list = string.Empty;

            if (query.AllKeys.Contains("list"))
            {
                list = query["list"];
            }
            #endregion

            if (!string.IsNullOrEmpty(list))
            {
                lastURL = lastURL + "&list=" + list;
            }

            string embedCode = EmbedCodePattern.Replace("@URL@", lastURL);

            return embedCode;
        }
        public void ShowVideo(string pURL, bool pUseEmbed = true)
        {
            if (!string.IsNullOrEmpty(pURL))
            {
                if (General.IsUrlValidForYouTube(pURL))
                {
                    pURL = pURL.Replace("#", "&");

                    if (pUseEmbed)
                    {
                        string embedCode = GenerateEmbedCode(pURL);

                        if (!embedCode.Trim().StartsWith("<html>"))
                        {
                            View.wbbYouTube.DocumentText = "<html>" + embedCode + "</html>";
                        }
                        else
                        {
                            View.wbbYouTube.DocumentText = embedCode;
                        }
                    }
                    else
                    {
                        View.wbbYouTube.Navigate(pURL);
                    }

                    View.wbbYouTube.ScriptErrorsSuppressed = true;

                    this.SaveSession();
                }
                else
                {
                    MessageBox.Show("URL is not matched with YouTube!");
                }
            }
        }

        public void SetOpacity(int pValue)
        {
            trkBar_Opacity.Value = pValue;
            trkBar_Opacity_Scroll(this, new EventArgs());
        }

        public new void Show()
        {
            this.IsClosed = false;

            if (!this.TopMost)
            {
                this.TopMost = true;
                this.View.TopMost = this.TopMost;
                base.Show();
                this.TopMost = false;
                this.View.TopMost = this.TopMost;
            }
            else
            {
                base.Show();
            }
        }
        public void Show(frmYouWatch pYouWatch, frmView pView)
        {
            this.YouWatch = pYouWatch;
            this.View = pView;
            this.IsClosed = false;

            if (!this.TopMost)
            {
                this.TopMost = true;
                this.View.TopMost = this.TopMost;
                base.Show();
                this.TopMost = false;
                this.View.TopMost = this.TopMost;
            }
            else
            {
                base.Show();
            }
        }
        public void Close(bool pForHide = false)
        {
            this.IsClosed = true;
            this.IsHidden = pForHide;

            this.Hide();
        }

        public void ShowBorder(bool pValue)
        {
            chkShowBorder.Checked = pValue;
        }
        public void ShowHideBorder()
        {
            chkShowBorder.Checked = !chkShowBorder.Checked;
        }


        public frmHeader()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void frmHeader_Load(object sender, EventArgs e)
        {
            this.View.Show(YouWatch, this);

            this.View.Left = this.Left;
            this.View.Top = this.Top + this.Height;
            this.View.Width = this.Width;

            RegisterHotKey(this.Handle, (Int32)KeyModifier.Alt, 1, (int)Keys.Space);

            LoadLastSession();

            if (string.IsNullOrEmpty(txtURL.Text))
            {
                txtURL.Text = General.ReadURLFromClipboard();
            }

            ShowVideo(txtURL.Text);
        }
        private void frmHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!YouWatch.IsClosing)
            {
                this.IsClosed = true;
                this.Hide();

                e.Cancel = true;

                YouWatch.CheckForClose();
            }
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ShowVideo(txtURL.Text);
            }
        }
        private void txtURL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtURL.Text = General.ReadURLFromClipboard();
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtURL.Text.Trim()))
            {
                txtURL.Text = General.ReadURLFromClipboard();
            }

            ShowVideo(txtURL.Text);
        }
        private void btnGOWeb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtURL.Text.Trim()))
            {
                txtURL.Text = General.ReadURLFromClipboard();
            }

            ShowVideo(txtURL.Text, false);
        }

        private void trkBar_Opacity_Scroll(object sender, EventArgs e)
        {
            View.Opacity = trkBar_Opacity.Value / (double)100;
        }

        private void chkShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowBorder.Checked)
            {
                this.View.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.View.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void chkShowInTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            this.View.ShowInTaskbar = chkShowInTaskbar.Checked;
        }

        private void chkKeepTopOn_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkKeepTopOn.Checked;
            this.View.TopMost = this.TopMost;
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            if (!this.View.IsClosed
                && !this.View.IsHidden)
            {
                this.View.Left = this.Left;
                this.View.Top = this.Top + this.Height;
                this.View.Width = this.Width;
            }
        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            this.Close(true);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (!List.Visible)
            {
                List.Show(this.YouWatch, this);
            }
            else
            {
                List.Close(true);
            }
        }
    }
}