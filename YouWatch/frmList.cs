using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace YouWatch
{
    public partial class frmList : BaseForm
    {
        frmYouWatch YouWatch = null;
        frmHeader Header = null;

        string FilePath = "";
        List<string> urls = new List<string>();

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

        private void LoadURLs()
        {
            this.FilePath = Application.StartupPath + "\\URLs.txt";

            if (!File.Exists(this.FilePath))
            {
                File.Create(this.FilePath).Close();
            }

            urls = File.ReadLines(this.FilePath).ToList();

            lbxList.Items.AddRange(urls.ToArray());
        }

        private void SaveFile(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }

            File.WriteAllLines(FilePath, lbxList.Items.Cast<string>());
        }

        public frmList()
        {
            InitializeComponent();
        }
        private void frmList_Load(object sender, EventArgs e)
        {
            LoadURLs();
        }
        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!YouWatch.IsClosing)
            {
                this.IsClosed = true;
                this.Hide();

                e.Cancel = true;

                YouWatch.CheckForClose();
            }
        }

        private void btnAddCurrentURL_Click(object sender, EventArgs e)
        {
            lbxList.Items.Add(this.Header.txtURL.Text);

            SaveFile(this.FilePath);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxList.SelectedIndex > -1)
            {
                lbxList.Items.RemoveAt(lbxList.SelectedIndex);

                SaveFile(this.FilePath);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (lbxList.SelectedIndex > -1)
            {
                this.Header.txtURL.Text = lbxList.Items[lbxList.SelectedIndex].ToString();
                this.Header.ShowVideo(lbxList.Items[lbxList.SelectedIndex].ToString());
            }
        }
    }
}
