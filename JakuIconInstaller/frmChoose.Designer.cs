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
    partial class frmChoose
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.ImageLocation = "tmp\\icon.png";
            this.picBox.Location = new System.Drawing.Point(12, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(48, 48);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(66, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Which app do you want to install this icon to?";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 292);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(305, 31);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 66);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(305, 220);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // frmChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 327);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose App";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmChoose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.ListView listView;
    }
}