using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class MemFileViewer : Form
    {
        public FileFormats.ResourceTypes.MemFileResource MemFileResource;

        public MemFileViewer()
        {
            InitializeComponent();
        }

        public void LoadFile(FileFormats.DataStorage.FileHeader header, Stream data)
        {
            var memFile = new FileFormats.ResourceTypes.MemFileResource();
            memFile.Deserialize(header, data);

            this.Text += ": " + memFile.Name;
            this.hexBox.ByteProvider = new DynamicByteProvider(memFile.Data);
            this.hexBox.ReadOnly = true;

            this.MemFileResource = memFile;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var name = this.MemFileResource.Name;
            if (name.StartsWith("/") == true)
            {
                name = name.Substring(1);
            }
            name = name.Replace("/", "\\");
            //name = Path.ChangeExtension(name, ".xml");

            this.saveFileDialog.FileName = name;
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                output.Write(this.MemFileResource.Data, 0, this.MemFileResource.Data.Length);
            }
        }
    }
}
