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

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JakuIconInstaller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("tmp"))
                Directory.CreateDirectory("tmp");
            ExtractResource("JakuIconInstaller.ipin.exe", "tmp\\ipin.exe");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
        private static void ExtractResource(string resName, string dizin)
        {
            //Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Get the resource stream
            Stream resourceStream = assembly.GetManifestResourceStream(resName);

            //Read the raw bytes of the resource
            byte[] resourcesBuffer = new byte[resourceStream.Length];

            resourceStream.Read(resourcesBuffer, 0, resourcesBuffer.Length);
            resourceStream.Close();

            BinaryWriter writer = new BinaryWriter(File.Open(dizin, FileMode.OpenOrCreate, FileAccess.Write));
            writer.Write(resourcesBuffer);
            writer.Close();
        }
    }
}
