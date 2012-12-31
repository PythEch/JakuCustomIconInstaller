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

using System.IO;
using System.Linq;

namespace JakuIconInstaller
{
    // I am too lazy to translate this to C#
    // Instead I used PyInstaller
    // Original source code written in Python is available with "ipin.py" file.
    class PNGFixer
    {
        public void FixPNG(string app, string filename)
        {
            Stream fStream = File.OpenRead(filename);
            byte[] newPNG = new byte[8];
            fStream.Read(newPNG, 0, 8);
            fStream.Close();

            if ((newPNG[0] != 0x89) || (newPNG[1] != 0x50) || (newPNG[2] != 0x4e) || (newPNG[3] != 0x47) || (newPNG[4] != 0x0d) || (newPNG[5] != 0x0a) || (newPNG[6] != 0x1a) || (newPNG[7] != 0x0a))
                return;

            byte[] oldPNG = File.ReadAllBytes(filename);
            byte[] idatAcc;
            bool breakLoop = false;
            int chunkPos = newPNG.Length;

            while (chunkPos < oldPNG.Length)
            {
                bool skip = false;

                // Reading Chunk
                var chunkLength = oldPNG.Skip(chunkPos).Take(4);
                //chunkLength = 

                /*chunkLength = oldPNG[chunkPos:chunkPos+4]
        chunkLength = unpack(">L", chunkLength)[0]
        chunkType = oldPNG[chunkPos+4 : chunkPos+8]
        chunkData = oldPNG[chunkPos+8:chunkPos+8+chunkLength]
        chunkCRC = oldPNG[chunkPos+chunkLength+8:chunkPos+chunkLength+12]
        chunkCRC = unpack(">L", chunkCRC)[0]
        chunkPos += chunkLength + 12*/
            }
        }
    }
}