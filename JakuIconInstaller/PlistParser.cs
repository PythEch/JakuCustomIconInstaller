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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace JakuIconInstaller
{
    public class Plist : Dictionary<string, dynamic>
    {
        public void Load(string filename)
        {
            this.Clear();

            var xdoc = XDocument.Load(filename);
            var plist = xdoc.Element("plist");
            var dict = plist.Element("dict");

            var dictElements = dict.Elements();
            Parse(this, dictElements);
        }

        private void Parse(Plist dict, IEnumerable<XElement> elements)
        {
            for (int i = 0; i < elements.Count(); i+= 2)
            {
                var plistVal = elements.ElementAt(i +1);
                var plistKey = elements.ElementAt(i);

                dict[plistKey.Value] =ParseValue(plistVal);
            }
        }

        private dynamic ParseValue(XElement plistVal)
        {
            switch (plistVal.Name.ToString())
            {
                case "true":
                    return true;
                case "false":
                    return false;
                case "string":
                    return plistVal.Value;
                case "integer":
                    return Convert.ToInt32(plistVal.Value);
                case "real":
                    return Convert.ToSingle(plistVal.Value);
                case "array":
                    return this.ParseArray(plistVal.Elements());
                case "dict":
                    Plist plist = new Plist();
                    this.Parse(plist,plistVal.Elements());
                    return plist;
            }
            return null;
        }

        private List<dynamic> ParseArray(IEnumerable<XElement> plistElements)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (XElement x in plistElements)
            {
                dynamic val = ParseValue(x);
                list.Add(val);
            }

            return list;
        }
    }
}