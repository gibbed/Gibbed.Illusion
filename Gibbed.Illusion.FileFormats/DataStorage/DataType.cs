using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class DataType
    {
        public uint Unknown0;
        public string Unknown1;
        public uint Unknown2;

        public void Deserialize(SdsStream input)
        {
            this.Unknown0 = input.ReadValueU32();
            uint length = input.ReadValueU32();
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            this.Unknown1 = input.ReadString(length);
            this.Unknown2 = input.ReadValueU32();
        }
    }
}
