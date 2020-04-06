namespace YouWatch
{
    partial class frmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            this.lbxList = new System.Windows.Forms.ListBox();
            this.btnAddCurrentURL = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxList
            // 
            this.lbxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbxList.FormattingEnabled = true;
            this.lbxList.ItemHeight = 20;
            this.lbxList.Location = new System.Drawing.Point(12, 12);
            this.lbxList.Name = "lbxList";
            this.lbxList.Size = new System.Drawing.Size(514, 484);
            this.lbxList.TabIndex = 0;
            this.lbxList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxList_MouseDoubleClick);
            // 
            // btnAddCurrentURL
            // 
            this.btnAddCurrentURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCurrentURL.Location = new System.Drawing.Point(12, 504);
            this.btnAddCurrentURL.Name = "btnAddCurrentURL";
            this.btnAddCurrentURL.Size = new System.Drawing.Size(75, 23);
            this.btnAddCurrentURL.TabIndex = 1;
            this.btnAddCurrentURL.Text = "Add Current";
            this.btnAddCurrentURL.UseVisualStyleBackColor = true;
            this.btnAddCurrentURL.Click += new System.EventHandler(this.btnAddCurrentURL_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(93, 504);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(451, 504);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 539);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddCurrentURL);
            this.Controls.Add(this.lbxList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmList";
            this.Text = "List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmList_FormClosing);
            this.Load += new System.EventHandler(this.frmList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxList;
        private System.Windows.Forms.Button btnAddCurrentURL;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOpen;
    }
}