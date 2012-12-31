// Jaku Theme Custom Icon Installer 0.9b
// Copyright (C) 2012-2013, PythEch
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace JakuIconInstaller
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.wBrowser = new System.Windows.Forms.WebBrowser();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRespring = new System.Windows.Forms.Button();
            this.lblPlug = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jakuRepoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(-3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "This free software will help you download icons from JakuRepo and install them to" +
    " your iDevice.\r\nHave Fun!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wBrowser
            // 
            this.wBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wBrowser.Location = new System.Drawing.Point(8, 85);
            this.wBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wBrowser.Name = "wBrowser";
            this.wBrowser.Size = new System.Drawing.Size(449, 298);
            this.wBrowser.TabIndex = 3;
            this.wBrowser.Url = new System.Uri("http://mobi.jakurepo.com/", System.UriKind.Absolute);
            this.wBrowser.Visible = false;
            this.wBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wBrowser_DocumentCompleted);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(8, 389);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(449, 31);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse From Local Computer";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnRespring_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(8, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(449, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnRespring
            // 
            this.btnRespring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRespring.Enabled = false;
            this.btnRespring.Location = new System.Drawing.Point(8, 426);
            this.btnRespring.Name = "btnRespring";
            this.btnRespring.Size = new System.Drawing.Size(449, 31);
            this.btnRespring.TabIndex = 7;
            this.btnRespring.Text = "Respring iDevice";
            this.btnRespring.UseVisualStyleBackColor = true;
            this.btnRespring.Click += new System.EventHandler(this.btnRespring_Click);
            // 
            // lblPlug
            // 
            this.lblPlug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlug.Location = new System.Drawing.Point(8, 206);
            this.lblPlug.Name = "lblPlug";
            this.lblPlug.Size = new System.Drawing.Size(449, 56);
            this.lblPlug.TabIndex = 8;
            this.lblPlug.Text = "Please plug your iDevice in via USB cable!\r\nWaiting for your iDevice...";
            this.lblPlug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jakuRepoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jakuRepoToolStripMenuItem
            // 
            this.jakuRepoToolStripMenuItem.Name = "jakuRepoToolStripMenuItem";
            this.jakuRepoToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.jakuRepoToolStripMenuItem.Text = "JakuRepo";
            this.jakuRepoToolStripMenuItem.Click += new System.EventHandler(this.jakuRepoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 463);
            this.Controls.Add(this.lblPlug);
            this.Controls.Add(this.btnRespring);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.wBrowser);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(485, 502);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jaku Custom Icon Installer 0.9b";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser wBrowser;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRespring;
        private System.Windows.Forms.Label lblPlug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jakuRepoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

