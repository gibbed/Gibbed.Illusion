namespace Gibbed.Illusion.ExploreSDS
{
    partial class ArchiveViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveViewer));
            this.entryTreeView = new System.Windows.Forms.TreeView();
            this.resourceMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewResourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveArchiveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewResourceButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.hintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveArchiveDialog = new System.Windows.Forms.SaveFileDialog();
            this.resourceMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // entryTreeView
            // 
            this.entryTreeView.ContextMenuStrip = this.resourceMenuStrip;
            this.entryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryTreeView.ImageIndex = 0;
            this.entryTreeView.ImageList = this.typeImageList;
            this.entryTreeView.Location = new System.Drawing.Point(0, 25);
            this.entryTreeView.Name = "entryTreeView";
            this.entryTreeView.SelectedImageIndex = 0;
            this.entryTreeView.Size = new System.Drawing.Size(480, 193);
            this.entryTreeView.TabIndex = 0;
            this.entryTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnOpenEntry1);
            this.entryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelectEntry);
            // 
            // resourceMenuStrip
            // 
            this.resourceMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewResourceMenuItem});
            this.resourceMenuStrip.Name = "entryMenuStrip";
            this.resourceMenuStrip.Size = new System.Drawing.Size(100, 26);
            // 
            // viewResourceMenuItem
            // 
            this.viewResourceMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewResourceMenuItem.Image")));
            this.viewResourceMenuItem.Name = "viewResourceMenuItem";
            this.viewResourceMenuItem.Size = new System.Drawing.Size(99, 22);
            this.viewResourceMenuItem.Text = "&View";
            this.viewResourceMenuItem.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // typeImageList
            // 
            this.typeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("typeImageList.ImageStream")));
            this.typeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.typeImageList.Images.SetKeyName(0, "Unknown");
            this.typeImageList.Images.SetKeyName(1, "SDS");
            this.typeImageList.Images.SetKeyName(2, "MemFile");
            this.typeImageList.Images.SetKeyName(3, "XML");
            this.typeImageList.Images.SetKeyName(4, "Table");
            this.typeImageList.Images.SetKeyName(5, "Script");
            this.typeImageList.Images.SetKeyName(6, "Texture");
            this.typeImageList.Images.SetKeyName(7, "Sound");
            this.typeImageList.Images.SetKeyName(8, "Cutscene");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveArchiveButton,
            this.toolStripSeparator1,
            this.viewResourceButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(480, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // saveArchiveButton
            // 
            this.saveArchiveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveArchiveButton.Image")));
            this.saveArchiveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveArchiveButton.Name = "saveArchiveButton";
            this.saveArchiveButton.Size = new System.Drawing.Size(94, 22);
            this.saveArchiveButton.Text = "Save Archive";
            this.saveArchiveButton.Click += new System.EventHandler(this.OnSaveArchive);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // viewResourceButton
            // 
            this.viewResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("viewResourceButton.Image")));
            this.viewResourceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewResourceButton.Name = "viewResourceButton";
            this.viewResourceButton.Size = new System.Drawing.Size(103, 22);
            this.viewResourceButton.Text = "View Resource";
            this.viewResourceButton.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hintLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 218);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(480, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // hintLabel
            // 
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(30, 17);
            this.hintLabel.Text = "Hint";
            // 
            // saveArchiveDialog
            // 
            this.saveArchiveDialog.DefaultExt = "sds";
            this.saveArchiveDialog.Filter = "Illusion SDS archives (*.sds)|*.sds|All Files (*.*)|*.*";
            // 
            // ArchiveViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this.entryTreeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArchiveViewer";
            this.Text = "Archive";
            this.resourceMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView entryTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ImageList typeImageList;
        private System.Windows.Forms.ContextMenuStrip resourceMenuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel hintLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton viewResourceButton;
        private System.Windows.Forms.ToolStripMenuItem viewResourceMenuItem;
        private System.Windows.Forms.ToolStripButton saveArchiveButton;
        private System.Windows.Forms.SaveFileDialog saveArchiveDialog;
    }
}