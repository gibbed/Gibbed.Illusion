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
            this.textBox1.Text = xml.Content;

            this.XmlResource = xml;
        }

        private void OnSave(object sender, System.EventArgs e)
        {
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
