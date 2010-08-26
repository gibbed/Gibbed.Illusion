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

        private void OnWindowCascade(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void OnWindowTileVertical(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void OnWindowTileHorizontal(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void OnWindowArrangeIcons(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void OnWindowCloseAll(object sender, EventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
