using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class BlockInfo
    {
        public bool Compressed;
        public long Offset;
        public uint CompressedSize;
        public uint UncompressedSize;
    }
}
