namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class TableViewer
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
            System.Windows.Forms.ToolStripButton _SaveButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewer));
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripButton _CopyHashesButton;
            System.Windows.Forms.ToolStrip _TableToolStrip;
            System.Windows.Forms.ToolStripButton _LoadFromFileButton;
            System.Windows.Forms.ToolStripButton _SaveToFileButton;
            System.Windows.Forms.StatusStrip _StatusStrip;
            this._TableComboBox = new System.Windows.Forms.ComboBox();
            this._DataGrid = new System.Windows.Forms.DataGridView();
            this._HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            _MainToolStrip = new System.Windows.Forms.ToolStrip();
            _SaveButton = new System.Windows.Forms.ToolStripButton();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _CopyHashesButton = new System.Windows.Forms.ToolStripButton();
            _TableToolStrip = new System.Windows.Forms.ToolStrip();
            _LoadFromFileButton = new System.Windows.Forms.ToolStripButton();
            _SaveToFileButton = new System.Windows.Forms.ToolStripButton();
            _StatusStrip = new System.Windows.Forms.StatusStrip();
            _MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataGrid)).BeginInit();
            _TableToolStrip.SuspendLayout();
            _StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _MainToolStrip
            // 
            _MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SaveButton,
            _ToolStripSeparator1,
            _CopyHashesButton});
            _MainToolStrip.Location = new System.Drawing.Point(0, 0);
            _MainToolStrip.Name = "_MainToolStrip";
            _MainToolStrip.Size = new System.Drawing.Size(640, 25);
            _MainToolStrip.TabIndex = 0;
            _MainToolStrip.Text = "toolStrip1";
            // 
            // _SaveButton
            // 
            _SaveButton.Enabled = false;
            _SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveButton.Image")));
            _SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveButton.Name = "_SaveButton";
            _SaveButton.Size = new System.Drawing.Size(51, 22);
            _SaveButton.Text = "Save";
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _CopyHashesButton
            // 
            _CopyHashesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _CopyHashesButton.Image = ((System.Drawing.Image)(resources.GetObject("_CopyHashesButton.Image")));
            _CopyHashesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _CopyHashesButton.Name = "_CopyHashesButton";
            _CopyHashesButton.Size = new System.Drawing.Size(23, 22);
            _CopyHashesButton.Text = "Copy Hashes";
            _CopyHashesButton.Click += new System.EventHandler(this.OnCopyHashes);
            // 
            // _TableComboBox
            // 
            this._TableComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._TableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._TableComboBox.FormattingEnabled = true;
            this._TableComboBox.Location = new System.Drawing.Point(0, 25);
            this._TableComboBox.Name = "_TableComboBox";
            this._TableComboBox.Size = new System.Drawing.Size(640, 21);
            this._TableComboBox.TabIndex = 1;
            this._TableComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectTable);
            // 
            // _DataGrid
            // 
            this._DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DataGrid.Location = new System.Drawing.Point(0, 71);
            this._DataGrid.Name = "_DataGrid";
            this._DataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this._DataGrid.Size = new System.Drawing.Size(640, 227);
            this._DataGrid.TabIndex = 2;
            this._DataGrid.CurrentCellChanged += new System.EventHandler(this.OnCurrentCellChanged);
            this._DataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataError);
            // 
            // _TableToolStrip
            // 
            _TableToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _LoadFromFileButton,
            _SaveToFileButton});
            _TableToolStrip.Location = new System.Drawing.Point(0, 46);
            _TableToolStrip.Name = "_TableToolStrip";
            _TableToolStrip.Size = new System.Drawing.Size(640, 25);
            _TableToolStrip.TabIndex = 3;
            _TableToolStrip.Text = "toolStrip2";
            // 
            // _LoadFromFileButton
            // 
            _LoadFromFileButton.Enabled = false;
            _LoadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_LoadFromFileButton.Image")));
            _LoadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _LoadFromFileButton.Name = "_LoadFromFileButton";
            _LoadFromFileButton.Size = new System.Drawing.Size(105, 22);
            _LoadFromFileButton.Text = "Load From File";
            _LoadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // _SaveToFileButton
            // 
            _SaveToFileButton.Enabled = false;
            _SaveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveToFileButton.Image")));
            _SaveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveToFileButton.Name = "_SaveToFileButton";
            _SaveToFileButton.Size = new System.Drawing.Size(89, 22);
            _SaveToFileButton.Text = "Save To File";
            _SaveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // _StatusStrip
            // 
            _StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HintLabel});
            _StatusStrip.Location = new System.Drawing.Point(0, 298);
            _StatusStrip.Name = "_StatusStrip";
            _StatusStrip.Size = new System.Drawing.Size(640, 22);
            _StatusStrip.TabIndex = 4;
            _StatusStrip.Text = "statusStrip1";
            // 
            // _HintLabel
            // 
            this._HintLabel.Name = "_HintLabel";
            this._HintLabel.Size = new System.Drawing.Size(30, 17);
            this._HintLabel.Text = "Hint";
            // 
            // TableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this._DataGrid);
            this.Controls.Add(_StatusStrip);
            this.Controls.Add(_TableToolStrip);
            this.Controls.Add(this._TableComboBox);
            this.Controls.Add(_MainToolStrip);
            this.Name = "TableViewer";
            this.Text = "Table";
            _MainToolStrip.ResumeLayout(false);
            _MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataGrid)).EndInit();
            _TableToolStrip.ResumeLayout(false);
            _TableToolStrip.PerformLayout();
            _StatusStrip.ResumeLayout(false);
            _StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _TableComboBox;
        private System.Windows.Forms.DataGridView _DataGrid;
        private System.Windows.Forms.ToolStripStatusLabel _HintLabel;
    }
}