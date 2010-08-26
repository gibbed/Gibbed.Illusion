using System.IO;
using System.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class XmlViewer : Form
    {
        public FileFormats.ResourceTypes.XmlResource XmlResource;

        public XmlViewer()
        {
            this.InitializeComponent();
        }

        public void LoadFile(FileFormats.DataStorage.FileHeader header, Stream data)
        {
            var xml = new FileFormats.ResourceTypes.XmlResource();
            xml.Deserialize(header, data);

            this.Text += ": " + xml.Name + " (" + xml.Tag + ")";
            
            this.contentTextBox.Text = xml.Content;
            this.contentTextBox.Select(0, 0);

            this.XmlResource = xml;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var name = this.XmlResource.Name;
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
                output.Write(this.XmlResource.Content);
            }
        }
    }
}
