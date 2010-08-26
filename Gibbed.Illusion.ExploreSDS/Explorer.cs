using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            archive.Load(path);
            archive.Show();
        }
    }
}
