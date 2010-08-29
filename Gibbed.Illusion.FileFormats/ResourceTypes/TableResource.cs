using System;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class TableResource : IResourceType
    {
        public List<TableData> Tables =
            new List<TableData>();

        public void Serialize(DataStorage.FileHeader header, Stream input)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            uint count = input.ReadValueU32();
            this.Tables.Clear();
            for (uint i = 0; i < count; i++)
            {
                var table = new TableData();
                table.Deserialize(header, input);
                this.Tables.Add(table);
            }
        }
    }
}
