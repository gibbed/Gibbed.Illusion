namespace Gibbed.Illusion.ExploreSDS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewer));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyHashesButton = new System.Windows.Forms.ToolStripButton();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.tableToolStrip = new System.Windows.Forms.ToolStrip();
            this.loadFromFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveToFileButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.toolStripSeparator1,
            this.copyHashesButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(480, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // copyHashesButton
            // 
            this.copyHashesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyHashesButton.Image = ((System.Drawing.Image)(resources.GetObject("copyHashesButton.Image")));
            this.copyHashesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyHashesButton.Name = "copyHashesButton";
            this.copyHashesButton.Size = new System.Drawing.Size(23, 22);
            this.copyHashesButton.Text = "Copy Hashes";
            this.copyHashesButton.Click += new System.EventHandler(this.OnCopyHashes);
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(0, 25);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(480, 21);
            this.comboBox.TabIndex = 1;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectTable);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 71);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(480, 169);
            this.dataGridView.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 22);
            this.saveButton.Text = "Save";
            // 
            // tableToolStrip
            // 
            this.tableToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromFileButton,
            this.saveToFileButton});
            this.tableToolStrip.Location = new System.Drawing.Point(0, 46);
            this.tableToolStrip.Name = "tableToolStrip";
            this.tableToolStrip.Size = new System.Drawing.Size(480, 25);
            this.tableToolStrip.TabIndex = 3;
            this.tableToolStrip.Text = "toolStrip2";
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Enabled = false;
            this.loadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("loadFromFileButton.Image")));
            this.loadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(105, 22);
            this.loadFromFileButton.Text = "Load From File";
            this.loadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Enabled = false;
            this.saveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToFileButton.Image")));
            this.saveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(89, 22);
            this.saveToFileButton.Text = "Save To File";
            this.saveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // TableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tableToolStrip);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "TableViewer";
            this.Text = "Table";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableToolStrip.ResumeLayout(false);
            this.tableToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton copyHashesButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip tableToolStrip;
        private System.Windows.Forms.ToolStripButton loadFromFileButton;
        private System.Windows.Forms.ToolStripButton saveToFileButton;
    }
}