using System.IO;

namespace Gibbed.Illusion.FileFormats
{
    public interface IResourceType
    {
        void Deserialize(DataStorage.FileHeader header, Stream input);
    }
}
