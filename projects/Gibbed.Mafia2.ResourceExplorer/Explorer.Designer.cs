namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class Explorer
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
            System.Windows.Forms.ToolStrip _MainToolStrip;
            System.Windows.Forms.ToolStripButton _OpenArchiveButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            System.Windows.Forms.MenuStrip _MenuStrip;
            System.Windows.Forms.ToolStripMenuItem _FileMenu;
            System.Windows.Forms.ToolStripMenuItem _OpenMenuItem;
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator3;
            System.Windows.Forms.ToolStripMenuItem _ExitMenuItem;
            System.Windows.Forms.ToolStripMenuItem _WindowsMenu;
            System.Windows.Forms.ToolStripMenuItem _CloseAllMenuItem;
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripMenuItem _CascadeMenuItem;
            System.Windows.Forms.ToolStripMenuItem _TileVerticalMenuItem;
            System.Windows.Forms.ToolStripMenuItem _TileHorizontalMenuItem;
            System.Windows.Forms.ToolStripMenuItem _ArrangeIconsMenuItem;
            this._OpenArchiveDialog = new System.Windows.Forms.OpenFileDialog();
            _MainToolStrip = new System.Windows.Forms.ToolStrip();
            _OpenArchiveButton = new System.Windows.Forms.ToolStripButton();
            _MenuStrip = new System.Windows.Forms.MenuStrip();
            _FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            _OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            _ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _WindowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            _CloseAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _CascadeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _TileVerticalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _TileHorizontalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _ArrangeIconsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _MainToolStrip.SuspendLayout();
            _MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _OpenArchiveDialog
            // 
            this._OpenArchiveDialog.DefaultExt = "sds";
            this._OpenArchiveDialog.Filter = "Illusion SDS archives (*.sds)|*.sds|All Files (*.*)|*.*";
            this._OpenArchiveDialog.Multiselect = true;
            // 
            // _MainToolStrip
            // 
            _MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _OpenArchiveButton});
            _MainToolStrip.Location = new System.Drawing.Point(0, 24);
            _MainToolStrip.Name = "_MainToolStrip";
            _MainToolStrip.Size = new System.Drawing.Size(800, 25);
            _MainToolStrip.TabIndex = 3;
            _MainToolStrip.Text = "toolStrip1";
            // 
            // _OpenArchiveButton
            // 
            _OpenArchiveButton.Image = ((System.Drawing.Image)(resources.GetObject("_OpenArchiveButton.Image")));
            _OpenArchiveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _OpenArchiveButton.Name = "_OpenArchiveButton";
            _OpenArchiveButton.Size = new System.Drawing.Size(79, 22);
            _OpenArchiveButton.Text = "Open SDS";
            _OpenArchiveButton.Click += new System.EventHandler(this.OnOpen);
            // 
            // _MenuStrip
            // 
            _MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _FileMenu,
            _WindowsMenu});
            _MenuStrip.Location = new System.Drawing.Point(0, 0);
            _MenuStrip.MdiWindowListItem = _WindowsMenu;
            _MenuStrip.Name = "_MenuStrip";
            _MenuStrip.Size = new System.Drawing.Size(800, 24);
            _MenuStrip.TabIndex = 5;
            _MenuStrip.Text = "MenuStrip";
            // 
            // _FileMenu
            // 
            _FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _OpenMenuItem,
            _ToolStripSeparator3,
            _ExitMenuItem});
            _FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            _FileMenu.Name = "_FileMenu";
            _FileMenu.Size = new System.Drawing.Size(37, 20);
            _FileMenu.Text = "&File";
            // 
            // _OpenMenuItem
            // 
            _OpenMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_OpenMenuItem.Image")));
            _OpenMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            _OpenMenuItem.Name = "_OpenMenuItem";
            _OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            _OpenMenuItem.Size = new System.Drawing.Size(152, 22);
            _OpenMenuItem.Text = "&Open";
            _OpenMenuItem.Click += new System.EventHandler(this.OnOpen);
            // 
            // _ToolStripSeparator3
            // 
            _ToolStripSeparator3.Name = "_ToolStripSeparator3";
            _ToolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // _ExitMenuItem
            // 
            _ExitMenuItem.Name = "_ExitMenuItem";
            _ExitMenuItem.Size = new System.Drawing.Size(152, 22);
            _ExitMenuItem.Text = "E&xit";
            _ExitMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // _WindowsMenu
            // 
            _WindowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _CloseAllMenuItem,
            _ToolStripSeparator1,
            _CascadeMenuItem,
            _TileVerticalMenuItem,
            _TileHorizontalMenuItem,
            _ArrangeIconsMenuItem});
            _WindowsMenu.Name = "_WindowsMenu";
            _WindowsMenu.Size = new System.Drawing.Size(68, 20);
            _WindowsMenu.Text = "&Windows";
            // 
            // _CloseAllMenuItem
            // 
            _CloseAllMenuItem.Name = "_CloseAllMenuItem";
            _CloseAllMenuItem.Size = new System.Drawing.Size(152, 22);
            _CloseAllMenuItem.Text = "C&lose All";
            _CloseAllMenuItem.Click += new System.EventHandler(this.OnWindowCloseAll);
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // _CascadeMenuItem
            // 
            _CascadeMenuItem.Name = "_CascadeMenuItem";
            _CascadeMenuItem.Size = new System.Drawing.Size(152, 22);
            _CascadeMenuItem.Text = "&Cascade";
            _CascadeMenuItem.Click += new System.EventHandler(this.OnWindowCascade);
            // 
            // _TileVerticalMenuItem
            // 
            _TileVerticalMenuItem.Name = "_TileVerticalMenuItem";
            _TileVerticalMenuItem.Size = new System.Drawing.Size(152, 22);
            _TileVerticalMenuItem.Text = "Tile &Vertical";
            _TileVerticalMenuItem.Click += new System.EventHandler(this.OnWindowTileVertical);
            // 
            // _TileHorizontalMenuItem
            // 
            _TileHorizontalMenuItem.Name = "_TileHorizontalMenuItem";
            _TileHorizontalMenuItem.Size = new System.Drawing.Size(152, 22);
            _TileHorizontalMenuItem.Text = "Tile &Horizontal";
            _TileHorizontalMenuItem.Click += new System.EventHandler(this.OnWindowTileHorizontal);
            // 
            // _ArrangeIconsMenuItem
            // 
            _ArrangeIconsMenuItem.Name = "_ArrangeIconsMenuItem";
            _ArrangeIconsMenuItem.Size = new System.Drawing.Size(152, 22);
            _ArrangeIconsMenuItem.Text = "&Arrange Icons";
            _ArrangeIconsMenuItem.Click += new System.EventHandler(this.OnWindowArrangeIcons);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(_MainToolStrip);
            this.Controls.Add(_MenuStrip);
            this.IsMdiContainer = true;
            this.Name = "Explorer";
            this.Text = "Mafia 2 Resource Explorer";
            _MainToolStrip.ResumeLayout(false);
            _MainToolStrip.PerformLayout();
            _MenuStrip.ResumeLayout(false);
            _MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog _OpenArchiveDialog;
    }
}

