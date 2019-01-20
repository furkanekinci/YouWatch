using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class frmMain : Form
    {
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY2 || m.Msg == WM_HOTKEY2)
            {
                if (m.WParam.ToInt32() == (Int32)KeyModifier.Alt)
                {
                    Process currentProcess = Process.GetCurrentProcess();
                    IntPtr hWnd = currentProcess.MainWindowHandle;

                    SetForegroundWindow(hWnd);

                    SetFocus(new HandleRef(null, hWnd));
                }
            }

            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_SHOW_HIDE_CONTROLS_ID))
            {
                pnlTop.Visible = ControlsPanelVisible = !ControlsPanelVisible;
            }
        }
        #endregion

        #region Add Menu
        // P/Invoke constants
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);


        private int SYSMENU_SHOW_HIDE_CONTROLS_ID = 0x1;
        #endregion

        #region Focus
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        // SetFocus will just focus the keyboard on your application, but not bring your process to front.
        // You don't need it here, SetForegroundWindow does the same.
        // Just for documentation.
        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(HandleRef hWnd);
        #endregion

        Size BeforeSize;

        double Ratio = 0;

        int timCounter = 0;

        bool KeepRatio = false;
        bool IsMoving = false;
        bool ShowBorder = true;
        bool IsResized = false;

        bool ControlsPanelVisible = true;

        string YoutubeURLPattern = "https://www.youtube.com/embed/{0}?";
        string EmbedCodePattern = "<html><head><meta http-equiv='X-UA-Compatible' content='IE=edge'><style>*{margin:0px;padding:0px;}</style></head><iframe style='position:absolute; left:0; top:0; width:100%; height:100%' src='@URL@&autoplay=1&showinfo=1&controls=1&autohide=1' frameborder='0' allowfullscreen></iframe></html>";

        private void ShowControls()
        {
            if (this.ControlsPanelVisible)
            {
                pnlTop.Visible = true;
            }

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            if (!chkShowBorder.Checked)
            {
                if (this.Top < 0)
                {
                    this.Top = 0;
                }

                if (this.Left + this.Width > SystemInformation.VirtualScreen.Width)
                {
                    this.Left = SystemInformation.VirtualScreen.Width - this.Width;
                }
            }

            this.Refresh();
        }
        private void HideControls()
        {
            pnlTop.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            timCounter = 0;
            timHider.Enabled = false;

            this.Refresh();
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

        private bool IsUrlValidForYouTube(string pURL)
        {
            string pattern = @"^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.?be)\/.+$";

            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return reg.IsMatch(pURL);
        }

        private void ShowVideo(string pURL)
        {
            if (!string.IsNullOrEmpty(pURL))
            {
                if (IsUrlValidForYouTube(pURL))
                {
                    pURL = pURL.Replace("#", "&");

                    string embedCode = GenerateEmbedCode(pURL);

                    wbbYouTube.DocumentText = "<html>" + embedCode + "</html>";
                    wbbYouTube.ScriptErrorsSuppressed = true;
                }
                else
                {
                    MessageBox.Show("URL is not matched with YouTube!");
                }
            }
        }

        private string ReadURLFromClipboard()
        {
            string clip = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clip))
            {
                if (!IsUrlValidForYouTube(clip))
                {
                    clip = string.Empty;
                }
            }

            return clip;
        }

        #region Mouse Move
        public delegate void MouseMovedEvent();

        public class GlobalMouseHandler : IMessageFilter
        {
            private const int WM_MOUSEMOVE = 0x0200;

            public event MouseMovedEvent TheMouseMoved;

            #region IMessageFilter Members

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
                    if (TheMouseMoved != null)
                    {
                        TheMouseMoved();
                    }
                }
                // Always allow message to continue to the next filter control
                return false;
            }

            #endregion
        }
        #endregion

        private void MoveForm()
        {
            int diff = 20;

            Point p = Cursor.Position;

            if (Math.Abs(this.Left - p.X) < diff)
            {
                this.Left = this.Left + diff;
            }
            else if (Math.Abs((this.Left + this.Width) - p.X) < diff)
            {
                this.Left = this.Left - diff;
            }

            if (Math.Abs(this.Top - p.Y) < diff)
            {
                this.Top = this.Top + diff;
            }
            else if (Math.Abs((this.Top + this.Height) - p.Y) < diff)
            {
                this.Top = this.Top - diff;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_SHOW_HIDE_CONTROLS_ID, "Show/Hide Controls");
        }

        public frmMain()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(frmMain_MouseMoved);
            Application.AddMessageFilter(gmh);

            InitializeComponent();

            wbbYouTube.ScriptErrorsSuppressed = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, (Int32)KeyModifier.Alt, 1, (int)Keys.Space);

            txtURL.Text = ReadURLFromClipboard();

            ShowVideo(txtURL.Text);
        }
        private void frmMain_ResizeBegin(object sender, EventArgs e)
        {
            this.BeforeSize = this.Size;

            IsMoving = true;
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.IsResized = true;
        }
        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            IsMoving = false;

            if (this.IsResized && this.KeepRatio)
            {
                if (this.Height > this.BeforeSize.Height)
                {
                    this.Width = this.Width + Convert.ToInt32(this.Width * (1 - this.Ratio));
                }
                else if (this.Width > this.BeforeSize.Width)
                {
                    this.Height = this.Height + Convert.ToInt32(this.Height * (1 - this.Ratio));
                }
                else if (this.Height < this.BeforeSize.Height)
                {
                    this.Width = this.Width - Convert.ToInt32(this.Width * (1 - this.Ratio));
                }
                else if (this.Width < this.BeforeSize.Width)
                {
                    this.Height = this.Height - Convert.ToInt32(this.Height * (1 - this.Ratio));
                }
            }

            this.IsResized = false;
        }
        private void frmMain_MouseMoved()
        {
            timCounter = 0;

            if (!timHider.Enabled)
            {
                timHider.Enabled = true;
            }
        }
        private void frmMain_MouseEnter(object sender, EventArgs e)
        {
            if (chkMoveByMouse.Checked && this.FormBorderStyle == FormBorderStyle.None)
            {
                MoveForm();
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
        }

        private void lblURL_MouseClick(object sender, MouseEventArgs e)
        {
            txtURL.Text = ReadURLFromClipboard();

            ShowVideo(txtURL.Text);
        }

        private void chkShowBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowBorder.Checked)
            {
                ShowControls();

                chkMoveByMouse.Checked = chkMoveByMouse.Enabled = false;

                this.ShowBorder = true;
            }
            else
            {
                chkMoveByMouse.Enabled = true;

                this.ShowBorder = false;
            }
        }
        private void chkShowInTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = chkShowInTaskbar.Checked;
        }
        private void chkKeepTopOn_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkKeepTopOn.Checked;
        }
        private void chkKeepRatio_CheckedChanged(object sender, EventArgs e)
        {
            this.Ratio = Convert.ToDouble(this.Height) / Convert.ToDouble(this.Width);

            this.KeepRatio = chkKeepRatio.Checked;
        }

        private void timHider_Tick(object sender, EventArgs e)
        {
            if (!this.IsMoving)
            {
                timCounter++;

                var curPos = this.PointToClient(Cursor.Position);

                int curX = curPos.X;
                int curY = curPos.Y;

                if (timCounter == 1)
                {
                    if ((curX > 0 && curX < this.Width) && (curY > 0 && curY < this.Height))
                    {
                        ShowControls();
                    }
                    else if (!this.ShowBorder)
                    {
                        HideControls();
                    }
                }
                else if (timCounter > 5)
                {
                    if ((curX < 0 || curX > this.Width) || (curY < 0 || curY > this.Height))
                    {
                        if (!this.ShowBorder)
                        {
                            HideControls();
                        }
                    }
                }
            }
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ShowVideo(txtURL.Text);
            }
        }

        private void lblCloseControls_Click(object sender, EventArgs e)
        {
            pnlTop.Visible = ControlsPanelVisible = false;
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtURL.Text.Trim()))
            {
                txtURL.Text = ReadURLFromClipboard();
            }

            ShowVideo(txtURL.Text);
        }

        private void wbbYouTube_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbbYouTube.Document.Body.MouseOver += new HtmlElementEventHandler(wbbYouTube_Body_MouseOver);
        }
        private void wbbYouTube_Body_MouseOver(object sender, HtmlElementEventArgs e)
        {
            if (chkMoveByMouse.Checked && this.FormBorderStyle == FormBorderStyle.None)
            {
                MoveForm();
            }
        }

        private void trkBar_Opacity_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trkBar_Opacity.Value / (double)100;
        }
    }
}
