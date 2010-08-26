using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gibbed.Helpers;
using System.IO;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    /*
    public class MemFileResource : IResourceType
    {
        public IEnumerable<DataStorage.FileEntry> GetFiles(DataStorage.FileHeader info, long offset, Stream input)
        {
            uint length = input.ReadValueU32();
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            string name = input.ReadStringASCII(length);
            if (input.ReadValueU32() != 1)
            {
                throw new InvalidOperationException();
            }

            uint size = input.ReadValueU32();

            return new DataStorage.FileEntry[] { new DataStorage.FileEntry()
            {
                Name = name,
                Offset = input.Position,
                Size = size,
            }};
        }
    }
    */
}
