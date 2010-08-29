using System.IO;
using System.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class XmlViewer : Form
    {
        public FileFormats.SdsMemory.Entry Entry;
        public FileFormats.ResourceTypes.XmlResource Resource;

        public XmlViewer()
        {
            this.InitializeComponent();
        }

        public void LoadFile(FileFormats.SdsMemory.Entry entry)
        {
            var xml = new FileFormats.ResourceTypes.XmlResource();
            xml.Deserialize(entry.Header, entry.Data);

            this.Text += ": " + xml.Name + " (" + xml.Tag + ")";
            
            this.contentTextBox.Text = xml.Content;
            this.contentTextBox.Select(0, 0);

            this.Entry = entry;
            this.Resource = xml;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var data = new MemoryStream();
            this.Resource.Serialize(this.Entry.Header, data);
            this.Entry.Data = data;
        }

        private void OnSaveToFile(object sender, System.EventArgs e)
        {
            var name = this.Resource.Name;
            if (name.StartsWith("/") == true)
            {
                name = name.Substring(1);
            }
            name = name.Replace("/", "\\");
            name = Path.ChangeExtension(name, ".xml");

            this.saveFileDialog.FileName = name;
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = new StreamWriter(this.saveFileDialog.FileName))
            {
                output.Write(this.Resource.Content);
            }
        }
    }
}
