using System;
using System.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class Explorer : Form
    {
        public Explorer()
        {
            this.InitializeComponent();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openArchiveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var path = this.openArchiveDialog.FileName;
            var archive = new ArchiveViewer() { MdiParent = this };
            archive.LoadArchive(path);
            archive.Show();
        }
    }
}
