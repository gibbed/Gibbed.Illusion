namespace Gibbed.Mafia2.ResourceExplorer
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
            System.Windows.Forms.ContextMenuStrip _ResourceMenuStrip;
            System.Windows.Forms.ToolStripMenuItem _ViewResourceMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveViewer));
            System.Windows.Forms.ImageList _TypeImageList;
            System.Windows.Forms.ToolStrip _ToolStrip;
            System.Windows.Forms.ToolStripButton _SaveArchiveButton;
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripButton _ViewResourceButton;
            System.Windows.Forms.StatusStrip _StatusStrip;
            this._EntryTreeView = new System.Windows.Forms.TreeView();
            this._HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._SaveArchiveDialog = new System.Windows.Forms.SaveFileDialog();
            _ResourceMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            _ViewResourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _TypeImageList = new System.Windows.Forms.ImageList(this.components);
            _ToolStrip = new System.Windows.Forms.ToolStrip();
            _SaveArchiveButton = new System.Windows.Forms.ToolStripButton();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _ViewResourceButton = new System.Windows.Forms.ToolStripButton();
            _StatusStrip = new System.Windows.Forms.StatusStrip();
            _ResourceMenuStrip.SuspendLayout();
            _ToolStrip.SuspendLayout();
            _StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _EntryTreeView
            // 
            this._EntryTreeView.ContextMenuStrip = _ResourceMenuStrip;
            this._EntryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._EntryTreeView.ImageIndex = 0;
            this._EntryTreeView.ImageList = _TypeImageList;
            this._EntryTreeView.Location = new System.Drawing.Point(0, 25);
            this._EntryTreeView.Name = "_EntryTreeView";
            this._EntryTreeView.SelectedImageIndex = 0;
            this._EntryTreeView.Size = new System.Drawing.Size(480, 193);
            this._EntryTreeView.TabIndex = 0;
            this._EntryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelectEntry);
            this._EntryTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnOpenEntry1);
            // 
            // _ResourceMenuStrip
            // 
            _ResourceMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _ViewResourceMenuItem});
            _ResourceMenuStrip.Name = "entryMenuStrip";
            _ResourceMenuStrip.Size = new System.Drawing.Size(100, 26);
            // 
            // _ViewResourceMenuItem
            // 
            _ViewResourceMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_ViewResourceMenuItem.Image")));
            _ViewResourceMenuItem.Name = "_ViewResourceMenuItem";
            _ViewResourceMenuItem.Size = new System.Drawing.Size(99, 22);
            _ViewResourceMenuItem.Text = "&View";
            _ViewResourceMenuItem.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // _TypeImageList
            // 
            _TypeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_TypeImageList.ImageStream")));
            _TypeImageList.TransparentColor = System.Drawing.Color.Transparent;
            _TypeImageList.Images.SetKeyName(0, "Unknown");
            _TypeImageList.Images.SetKeyName(1, "SDS");
            _TypeImageList.Images.SetKeyName(2, "MemFile");
            _TypeImageList.Images.SetKeyName(3, "XML");
            _TypeImageList.Images.SetKeyName(4, "Table");
            _TypeImageList.Images.SetKeyName(5, "Script");
            _TypeImageList.Images.SetKeyName(6, "Texture");
            _TypeImageList.Images.SetKeyName(7, "Sound");
            _TypeImageList.Images.SetKeyName(8, "Cutscene");
            // 
            // _ToolStrip
            // 
            _ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SaveArchiveButton,
            _ToolStripSeparator1,
            _ViewResourceButton});
            _ToolStrip.Location = new System.Drawing.Point(0, 0);
            _ToolStrip.Name = "_ToolStrip";
            _ToolStrip.Size = new System.Drawing.Size(480, 25);
            _ToolStrip.TabIndex = 1;
            _ToolStrip.Text = "toolStrip1";
            // 
            // _SaveArchiveButton
            // 
            _SaveArchiveButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveArchiveButton.Image")));
            _SaveArchiveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveArchiveButton.Name = "_SaveArchiveButton";
            _SaveArchiveButton.Size = new System.Drawing.Size(94, 22);
            _SaveArchiveButton.Text = "Save Archive";
            _SaveArchiveButton.Click += new System.EventHandler(this.OnSaveArchive);
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _ViewResourceButton
            // 
            _ViewResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("_ViewResourceButton.Image")));
            _ViewResourceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _ViewResourceButton.Name = "_ViewResourceButton";
            _ViewResourceButton.Size = new System.Drawing.Size(103, 22);
            _ViewResourceButton.Text = "View Resource";
            _ViewResourceButton.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // _StatusStrip
            // 
            _StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HintLabel});
            _StatusStrip.Location = new System.Drawing.Point(0, 218);
            _StatusStrip.Name = "_StatusStrip";
            _StatusStrip.Size = new System.Drawing.Size(480, 22);
            _StatusStrip.TabIndex = 2;
            _StatusStrip.Text = "statusStrip1";
            // 
            // _HintLabel
            // 
            this._HintLabel.Name = "_HintLabel";
            this._HintLabel.Size = new System.Drawing.Size(30, 17);
            this._HintLabel.Text = "Hint";
            // 
            // _SaveArchiveDialog
            // 
            this._SaveArchiveDialog.DefaultExt = "sds";
            this._SaveArchiveDialog.Filter = "Illusion SDS archives (*.sds)|*.sds|All Files (*.*)|*.*";
            // 
            // ArchiveViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this._EntryTreeView);
            this.Controls.Add(_StatusStrip);
            this.Controls.Add(_ToolStrip);
            this.Name = "ArchiveViewer";
            this.Text = "Archive";
            _ResourceMenuStrip.ResumeLayout(false);
            _ToolStrip.ResumeLayout(false);
            _ToolStrip.PerformLayout();
            _StatusStrip.ResumeLayout(false);
            _StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView _EntryTreeView;
        private System.Windows.Forms.ToolStripStatusLabel _HintLabel;
        private System.Windows.Forms.SaveFileDialog _SaveArchiveDialog;
    }
}