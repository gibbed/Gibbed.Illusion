using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class ScriptResource : IResourceType
    {
        public string Path;
        public List<ScriptData> Scripts = new List<ScriptData>();

        public void Serialize(DataStorage.FileHeader header, Stream output)
        {
            output.WriteStringU16(this.Path);
            output.WriteValueS32(this.Scripts.Count);
            foreach (var script in this.Scripts)
            {
                script.Serialize(header, output);
            }
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.Path = input.ReadStringU16();
            var count = input.ReadValueU32();
            this.Scripts.Clear();
            for (uint i = 0; i < count; i++)
            {
                var script = new ScriptData();
                script.Deserialize(header, input);
                this.Scripts.Add(script);
            }
        }
    }
}
