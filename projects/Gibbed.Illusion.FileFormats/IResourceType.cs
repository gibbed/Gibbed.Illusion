using System.IO;

namespace Gibbed.Illusion.FileFormats
{
    public interface IResourceType
    {
        void Serialize(DataStorage.FileHeader header, Stream output);
        void Deserialize(DataStorage.FileHeader header, Stream input);
    }
}
