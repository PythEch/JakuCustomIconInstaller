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

using MobileDevice;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JakuIconInstaller
{
    public partial class frmChoose : Form
    {
        public frmChoose()
        {
            InitializeComponent();
        }

        static iPhone iDevice = new iPhone();

        // Special Thanks: http://stackoverflow.com/questions/1101149/displaying-thumbnail-icons-128x128-pixels-or-larger-in-a-grid-in-listview

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }

        public void ListView_SetSpacing(ListView listview, short cx, short cy)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            // http://msdn.microsoft.com/en-us/library/bb761176(VS.85).aspx
            // minimum spacing = 4
            SendMessage(listview.Handle, LVM_SETICONSPACING,
            IntPtr.Zero, (IntPtr)MakeLong(cx, cy));

            // http://msdn.microsoft.com/en-us/library/bb775085(VS.85).aspx
        }

        private void frmChoose_Load(object sender, EventArgs e)
        {
            // Simply load icons and set spacing
            ListView_SetSpacing(this.listView, 48 + 12, 48 + 4 + 20);
            ImageList iList = new ImageList();
            
            iList.ColorDepth = ColorDepth.Depth24Bit; // High Quality!
            iList.ImageSize = new Size(48, 48); // Reasonable Size
            int n = 0;
            foreach (var dict in Data.dictIcon)
            {
                iList.Images.Add(new Bitmap("tmp\\" + dict.Key + ".png"));
                ListViewItem text = new ListViewItem(dict.Key);
                text.ImageIndex = n;
                listView.Items.Add(text);
                n++;
            }
            listView.LargeImageList = iList;
        }

        // PC --> iPhone
        private void sendFile(string source, string dest)
        {
            iDevice.DeleteFile(dest); //it automaticly checks if file exists then deletes
            using (FileStream readStream = File.OpenRead(source))
            using (var iFile = iPhoneFile.OpenWrite(iDevice, dest))
            {
                byte[] buffer = new Byte[2048];
                int bytesRead;

                while ((bytesRead = readStream.Read(buffer, 0, 2048)) > 0)
                    iFile.Write(buffer, 0, bytesRead);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            // In this version user must respring by him/herself
            // Later I will add respring via OpenSSH feature.
            string appName = listView.SelectedItems[0].Text;
            string iconName = Data.dictIcon[appName][0];
            string bundleName = Data.dictIcon[appName][1];
            if (iDevice.Exists("/Library/Themes/Jaku Essentials.theme/Bundles"))
            {
                iDevice.CreateDirectory("/Library/Themes/Jaku Essentials.theme/Bundles/"+bundleName);
                sendFile("tmp\\icon.png", "/Library/Themes/Jaku Essentials.theme/Bundles/" + bundleName + "/" + iconName);
                // Delete cache, sometimes only respringing is not the solution.
                foreach (var item in iDevice.GetFiles("/var/mobile/Library/Caches/com.apple.IconsCache"))
                    if (item.StartsWith(bundleName))
                        iDevice.DeleteFile("/var/mobile/Library/Caches/com.apple.IconsCache/"+item);
                MessageBox.Show("The icon has been installed!\r\nYou have to respring your iDevice in order to see changes!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show(@"Make sure you have installed Jaku Theme!\r\n""Jaku Essentials.theme"" not found!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
