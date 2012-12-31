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

using Microsoft.Win32;
using MobileDevice;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JakuIconInstaller
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static iPhone iDevice = new iPhone();

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
        int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetCueText(Control control, string text)
        {
            SendMessage(control.Handle, EM_SETCUEBANNER, 0, text);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Ancient Windows APIs which is not supported with .NET by default
            // Who cares when you can use APIs by yourself anyways...
            SetCueText(txtSearch, "Type and press 'Enter' to search...");
            iDevice.Connect += iDevice_Connected;
            iDevice.Disconnect += iDevice_Disconnected;
        }

        private readonly string ApplicationSupportDirectory = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Apple Inc.\Apple Application Support", "InstallDir", Environment.CurrentDirectory).ToString();

        private void iDevice_Connected(object sender, ConnectEventArgs e)
        {
            if (new[] { "iPhone1,1", "iPhone1,2", "iPhone2,1", "iPod1,1", "iPod2,1", "iPod3,1" }.Contains(iDevice.DeviceProductType) || iDevice.DeviceProductType.StartsWith("iPad", true, System.Globalization.CultureInfo.CreateSpecificCulture("en")))
                lblPlug.Text = "An iDevice has been plugged in!\r\nHowever, Jaku Theme does not support your device yet!";
            else if (!iDevice.IsJailbreak)
                lblPlug.Text = "Your iDevice must be jailbroken in order to install custom themes!";
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblPlug.Visible = false;
                    wBrowser.Visible = true;
                    btnBrowse.Enabled = true;
                    btnRespring.Enabled = true;
                    txtSearch.Enabled = true;
                    // User Apps
                    foreach (var dir in iDevice.GetDirectories("/var/mobile/Applications"))
                        foreach (var dir2 in iDevice.GetDirectories("/var/mobile/Applications/" + dir))
                            if (dir2.EndsWith(".app"))
                            {
                                string finalPath = "/var/mobile/Applications/" + dir + "/" + dir2;
                                getFile(finalPath + "/Info.plist", "tmp\\Info.plist"); // Get Info.plist so we can continue
                                // Use iTunes PlUtil from iTunes Libraries to convert bplist to plist
                                ProcessStartInfo procStartInfo = new ProcessStartInfo(Path.Combine(ApplicationSupportDirectory, "plutil.exe"), @"-convert xml1 """ +
                                    Path.Combine(Environment.CurrentDirectory, "tmp\\Info.plist") + @"""")
                                {
                                    UseShellExecute = false,
                                    CreateNoWindow = true,
                                    RedirectStandardOutput = true,
                                    Verb = "runas"
                                };
                                var p = new Process();
                                p.StartInfo = procStartInfo;
                                p.Start();
                                string output = p.StandardOutput.ReadToEnd();
                                p.WaitForExit();
                                //MessageBox.Show(output);
                                Plist plist = new Plist();
                                plist.Load("tmp\\Info.plist"); //now load
                                dynamic search;
                                // get icon names, download them until we found perfect 114x114 image size
                                if (plist.ContainsKey("CFBundleIconFiles"))
                                    search = plist["CFBundleIconFiles"];
                                else
                                    search = plist["CFBundleIcons"]["CFBundlePrimaryIcon"]["CFBundleIconFiles"];
                                foreach (var item in search)
                                {
                                    string appName = plist["CFBundleDisplayName"];
                                    string bundleName = plist["CFBundleIdentifier"];
                                    getFile(finalPath + "/" + item, "tmp\\" + appName + ".png");
                                    using (Bitmap bitmap = new Bitmap("tmp\\" + appName + ".png"))
                                        if (bitmap.Height == 114)
                                        {
                                            Data.dictIcon[appName] = new string[] { item, bundleName }; //1st: icon name, 2nd: bundle name
                                            break;
                                        }
                                }
                            }
                    // Start iPIN to de-optimize PNGs
                    Process p2 = new Process();
                    p2.StartInfo.CreateNoWindow = true;
                    p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p2.StartInfo.FileName = "tmp\\ipin.exe";
                    p2.Start();
                });
            }

        }
        private void iDevice_Disconnected(object sender, ConnectEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblPlug.Text = "Please plug your iDevice in via USB cable!\r\nWaiting for your iDevice...";
                lblPlug.Visible = true;
                wBrowser.Visible = false;
                wBrowser.Navigate("http://mobi.jakurepo.com/");
                btnBrowse.Enabled = false;
                btnRespring.Enabled = false;
                txtSearch.Enabled = false;
            });
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                wBrowser.Navigate("http://mobi.jakurepo.com/search.php?q=" + txtSearch.Text);
        }
    
        private void wBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Index page has some nice icons too, we don't want to download them...
            if (wBrowser.Url.ToString().Contains(".php") && !wBrowser.Url.ToString().Contains("index.php"))
            {
                HtmlElementCollection tags = wBrowser.Document.Links;
                foreach (HtmlElement element in tags)
                    // Yeah, this is their class attribute.
                    if (element.GetAttribute("className") == "ui-link-inherit")
                    {
                        element.SetAttribute("onclick", ""); // Removes the site's click handler
                        element.Click -= new HtmlElementEventHandler(element_Click); //Removes previous handlers so we can be sure that only one handler is fired
                        element.Click += new HtmlElementEventHandler(element_Click); //Injects our event handler
                    }
            }
        }
        private void element_Click(object sender, HtmlElementEventArgs e)
        {
            string url = ((HtmlElement)sender).GetElementsByTagName("img")[0].GetAttribute("src");
            if (!Directory.Exists("tmp"))
                Directory.CreateDirectory("tmp");
            var fileName = "tmp\\icon.png";
            // Redownload...
            // It was hard to save the image from cache so I do it this way
            // If the images were downloaded  directly from JakuRepo's server, I would try the hard and
            // more efficent way, but we are downloading from imgur, imageshack etc. So I don't care.
            //
            // If you just want to save some bandwith or improve my version, check this out:
            // http://stackoverflow.com/questions/2566898/save-images-in-webbrowser-control-without-redownloading-them-from-the-internet
            using (WebClient wClient = new WebClient()) {
                wClient.DownloadFileAsync(new Uri(url), fileName);
                wClient.DownloadFileCompleted += new AsyncCompletedEventHandler(installIcon);
            }
        }
        // Read Text File And Save It To The Memory 
        // iPhone --> PC
        private string readTextFile(string path)
        {
            string retString = String.Empty;
            using (var iFile = iPhoneFile.OpenRead(iDevice, path))
            using (StreamReader reader = new StreamReader(iFile))
                retString = reader.ReadToEnd();

            return retString;
        }
        // iPhone --> PC
        private void getFile(string source, string dest)
        {
            if (File.Exists(dest))
                File.Delete(dest);
            using (var iFile = iPhoneFile.OpenRead(iDevice, source))
            using (FileStream writeStream = File.OpenWrite(dest))
            {
                byte[] buffer = new Byte[2048];
                int bytesRead;

                while ((bytesRead = iFile.Read(buffer, 0, 2048)) > 0)
                    writeStream.Write(buffer, 0, bytesRead);
            }
        }
        

        private void installIcon(object sender, AsyncCompletedEventArgs e)
        {
            new frmChoose().ShowDialog();
        }

        private void btnRespring_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is feature is not implemented yet!", "Unsupported Feature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jakuRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.jakurepo.com/");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2012-2013, PythEch\r\n\r\nVersion: 0.9b\r\n\r\nLibraries used:\r\nzlib\r\nMobileDevice (Modified)\r\niPhone PNG Images Normalizer v1.1\r\n\r\nYou can check the source code for more detail.\r\nThis program is a freeware and released under GNU General Public License Version 3.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
