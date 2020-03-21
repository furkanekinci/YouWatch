using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class frmViewChrome : BaseForm
    {
        frmYouWatch YouWatch = null;
        frmHeader Header = null;
        HtmlDocument htmlDoc;

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


        private int SYSMENU_SHOW_HIDE_FORM_BORDER_ID = 0x1;
        private int SYSMENU_SHOW_HIDE_CONTROLS_ID = 0x2;
        private int SYSMENU_OPACITY_100_ID = 0x3;
        private int SYSMENU_OPACITY_80_ID = 0x4;
        private int SYSMENU_OPACITY_60_ID = 0x5;
        private int SYSMENU_OPACITY_40_ID = 0x6;
        private int SYSMENU_OPACITY_20_ID = 0x7;
        #endregion

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

            if ((m.Msg == WM_SYSCOMMAND))
            {
                if (((int)m.WParam == SYSMENU_SHOW_HIDE_FORM_BORDER_ID))
                {
                    if (this.FormBorderStyle == FormBorderStyle.Sizable)
                    {
                        this.Header.ShowBorder(false);
                    }
                    else
                    {
                        this.Header.ShowBorder(true);
                    }
                }
                else if (((int)m.WParam == SYSMENU_SHOW_HIDE_CONTROLS_ID))
                {
                    this.Header.ShowHide();
                }
                else if (((int)m.WParam == SYSMENU_OPACITY_100_ID))
                {
                    Header.SetOpacity(100);
                }
                else if (((int)m.WParam == SYSMENU_OPACITY_80_ID))
                {
                    Header.SetOpacity(80);
                }
                else if (((int)m.WParam == SYSMENU_OPACITY_60_ID))
                {
                    Header.SetOpacity(60);
                }
                else if (((int)m.WParam == SYSMENU_OPACITY_40_ID))
                {
                    Header.SetOpacity(40);
                }
                else if (((int)m.WParam == SYSMENU_OPACITY_20_ID))
                {
                    Header.SetOpacity(20);
                }
            }
        }

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

        public new void Show()
        {
            this.IsClosed = false;

            if (!this.TopMost)
            {
                this.TopMost = true;
                base.Show();
                this.TopMost = false;
            }
            else
            {
                base.Show();
            }
        }
        public void Show(frmYouWatch pYouWatch, frmHeader pHeader)
        {
            this.YouWatch = pYouWatch;
            this.Header = pHeader;
            this.IsClosed = false;

            if (!this.TopMost)
            {
                this.TopMost = true;
                base.Show();
                this.TopMost = false;
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

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_SHOW_HIDE_FORM_BORDER_ID, "Show/Hide Form Border");

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_SHOW_HIDE_CONTROLS_ID, "Show/Hide Controls");

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_OPACITY_100_ID, "Opacity: 100%");
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_OPACITY_80_ID, "Opacity: 80%");
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_OPACITY_60_ID, "Opacity: 60%");
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_OPACITY_40_ID, "Opacity: 40%");
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_OPACITY_20_ID, "Opacity: 20%");
        }


        public frmViewChrome()
        {
            InitializeComponent();

            wbbYouTube.ScriptErrorsSuppressed = false;
        }
        private void frmViewChrome_Load(object sender, EventArgs e)
        {
            if (wbbYouTube.Document != null)
            {
                htmlDoc = wbbYouTube.Document;

                htmlDoc.Click += htmlDoc_Click;

                htmlDoc.MouseDown += htmlDoc_MouseDown;

                htmlDoc.MouseMove += htmlDoc_MouseMove;

                htmlDoc.ContextMenuShowing += htmlDoc_ContextMenuShowing;
            }
        }
        private void frmViewChrome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!YouWatch.IsClosing)
            {
                this.IsClosed = true;
                this.Hide();

                e.Cancel = true;

                YouWatch.CheckForClose();
            }
        }

        private void wbbYouTube_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (wbbYouTube.Document != null)
            {
                htmlDoc = wbbYouTube.Document;

                htmlDoc.Click += htmlDoc_Click;

                htmlDoc.MouseDown += htmlDoc_MouseDown;

                htmlDoc.MouseMove += htmlDoc_MouseMove;

                htmlDoc.ContextMenuShowing += htmlDoc_ContextMenuShowing;
            }
        }

        void htmlDoc_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            // stop the right mouse Menu
            e.ReturnValue = false;
        }
        void htmlDoc_MouseMove(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        void htmlDoc_MouseDown(object sender, HtmlElementEventArgs e)
        {
            //Console.WriteLine("Mouse Down");
        }
        void htmlDoc_Click(object sender, HtmlElementEventArgs e)
        {
            //Console.WriteLine("Mouse Click");
            // stop mouse events moving on to the HTML doc

            e.ReturnValue = false;
        }
    }
}