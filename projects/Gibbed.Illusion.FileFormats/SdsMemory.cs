using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gibbed.Illusion.FileFormats
{
    public class SdsMemory
    {
        public DataStorage.ArchiveHeader Header;
        private string Platform;

        public List<DataStorage.ResourceTypeReference> ResourceTypes =
            new List<DataStorage.ResourceTypeReference>();

        public string Xml;

        public List<Entry> Entries =
            new List<Entry>();

        public class Entry
        {
            public DataStorage.FileHeader Header;
            public uint TypeId { get { return this.Header.TypeId; } }
            public string Description { get; internal set; }
            public MemoryStream Data;
        }
    }
}
