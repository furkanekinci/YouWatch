using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

                if (pnlTop.Visible)
                {
                    this.Height = this.Height + pnlTop.Height;
                }
                else
                {
                    this.Height = this.Height - pnlTop.Height;
                }
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

        #region Move By Mouse
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private string LastSessionFilePath = "LastSession.dat";

        Size BeforeSize;

        int timCounter = 0;

        bool KeepRatio = false;
        bool IsMoving = false;
        bool ShowBorder = true;
        bool IsResized = false;

        bool ControlsPanelVisible = true;

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
                settings += string.Format("{0}|{1}#", chkShowInTaskbar.Name, chkShowInTaskbar.Checked);
                settings += string.Format("{0}|{1}#", chkKeepTopOn.Name, chkKeepTopOn.Checked);
                settings += string.Format("{0}|{1}#", chkKeepRatio.Name, chkKeepRatio.Checked);
                settings += string.Format("{0}|{1}#", chkMoveByMouse.Name, chkMoveByMouse.Checked);
                settings += string.Format("{0}|{1}#", trkBar_Opacity.Name, trkBar_Opacity.Value);

                File.WriteAllText(this.LastSessionFilePath, settings);
            }
            catch
            {

            }
        }

        private void SetRatio()
        {
            if (this.ControlsPanelVisible)
            {
                if (this.Height != this.BeforeSize.Height)
                {
                    this.Width = Convert.ToInt32((this.Height - 120) * 1.78M);
                }
                else if (this.Width != this.BeforeSize.Width)
                {
                    this.Height = Convert.ToInt32((this.Width / 1.78M) + 120);
                }
            }
            else
            {
                if (this.Height != this.BeforeSize.Height)
                {
                    this.Width = Convert.ToInt32((this.Height - 34) * 1.78M);
                }
                else if (this.Width != this.BeforeSize.Width)
                {
                    this.Height = Convert.ToInt32((this.Width / 1.78M) + 34);
                }
            }
        }

        private void ShowControls()
        {
            if (this.ControlsPanelVisible && !pnlTop.Visible)
            {
                pnlTop.Visible = true;

                if (this.FormBorderStyle == FormBorderStyle.Sizable)
                {
                    this.Left = this.Left - 8;

                    this.Top = this.Top - pnlTop.Height - 32;
                    this.Height = this.Height + pnlTop.Height;
                }
                else
                {
                    this.Top = this.Top - pnlTop.Height;
                    this.Height = this.Height + pnlTop.Height;
                }
            }

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
            if (pnlTop.Visible)
            {
                pnlTop.Visible = false;

                if (this.FormBorderStyle == FormBorderStyle.Sizable)
                {
                    this.Left = this.Left + 8;

                    this.Top = this.Top + pnlTop.Height + 32;
                    this.Height = this.Height - pnlTop.Height;
                }
                else
                {

                    this.Top = this.Top + pnlTop.Height;
                    this.Height = this.Height - pnlTop.Height;
                }
            }

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

                    if (!embedCode.Trim().StartsWith("<html>"))
                    {
                        wbbYouTube.DocumentText = "<html>" + embedCode + "</html>";
                    }
                    else
                    {
                        wbbYouTube.DocumentText = embedCode;
                    }

                    wbbYouTube.ScriptErrorsSuppressed = true;

                    this.SaveSession();
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

            LoadLastSession();

            if (string.IsNullOrEmpty(txtURL.Text))
            {
                txtURL.Text = ReadURLFromClipboard();
            }

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
                SetRatio();
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
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSession();
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
                this.Top -= 27;
                this.Left -= 8;

                this.FormBorderStyle = FormBorderStyle.Sizable;

                ShowControls();

                chkMoveByMouse.Checked = chkMoveByMouse.Enabled = false;

                this.ShowBorder = true;
            }
            else
            {
                this.Top += 27;
                this.Left += 8;

                this.FormBorderStyle = FormBorderStyle.None;

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
            this.KeepRatio = chkKeepRatio.Checked;

            if (this.KeepRatio)
            {
                this.SetRatio();
            }
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
            this.Height = this.Height - pnlTop.Height;
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

        private void txtURL_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtURL.Text = ReadURLFromClipboard();
            }
        }

        private void trkBar_Opacity_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = trkBar_Opacity.Value / (double)100;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            pnlTop.Visible = ControlsPanelVisible = false;
            this.Height = this.Height - pnlTop.Height;
        }
    }
}
