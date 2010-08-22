using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class Header
    {
        public string Magic;
        public uint Version;
        public string Platform;

        public void Deserialize(SdsStream input)
        {
            this.Magic = input.ReadString(4);
            this.Version = input.ReadValueU32();
            this.Platform = input.ReadString(4);
        }
    }
}
