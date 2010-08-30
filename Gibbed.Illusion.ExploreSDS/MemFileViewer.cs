using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class MemFileViewer : Form
    {
        public FileFormats.SdsMemory.Entry Entry;
        public FileFormats.ResourceTypes.MemFileResource Resource;

        public MemFileViewer()
        {
            this.InitializeComponent();
        }

        public void LoadFile(FileFormats.SdsMemory.Entry entry)
        {
            var resource = new FileFormats.ResourceTypes.MemFileResource();
            resource.Deserialize(entry.Header, entry.Data);

            this.Text += ": " + resource.Name;
            this.hexBox.ByteProvider = new DynamicByteProvider(resource.Data);
            this.hexBox.ReadOnly = true;

            this.Entry = entry;
            this.Resource = resource;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var data = new MemoryStream();
            this.Resource.Serialize(this.Entry.Header, data);
            this.Entry.Data = data;
        }

        private void OnSaveToFile(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.saveFileDialog.FileName) == true)
            {
                var name = this.Resource.Name;
                if (name.StartsWith("/") == true)
                {
                    name = name.Substring(1);
                }
                name = name.Replace("/", "\\");
                //name = Path.ChangeExtension(name, ".xml");

                this.saveFileDialog.FileName = name;
            }

            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                output.Write(this.Resource.Data, 0, this.Resource.Data.Length);
            }
        }

        private void OnLoadFromFile(object sender, System.EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var input = File.Open(
                this.openFileDialog.FileName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                this.Resource.Data = new byte[input.Length];
                input.Read(this.Resource.Data, 0, this.Resource.Data.Length);
                this.hexBox.ByteProvider = new DynamicByteProvider(this.Resource.Data);
            }
        }
    }
}
