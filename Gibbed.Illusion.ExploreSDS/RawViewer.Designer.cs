namespace Gibbed.Illusion.ExploreSDS
{
    partial class RawViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawViewer));
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.loadFromFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveToFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // hexBox
            // 
            this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Location = new System.Drawing.Point(0, 25);
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.Size = new System.Drawing.Size(640, 215);
            this.hexBox.StringViewVisible = true;
            this.hexBox.TabIndex = 2;
            this.hexBox.UseFixedBytesPerLine = true;
            this.hexBox.VScrollBarVisible = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromFileButton,
            this.saveToFileButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(640, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("loadFromFileButton.Image")));
            this.loadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(105, 22);
            this.loadFromFileButton.Text = "Load From File";
            this.loadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToFileButton.Image")));
            this.saveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(89, 22);
            this.saveToFileButton.Text = "Save To File";
            this.saveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "All Files (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All Files (*.*)|*.*";
            // 
            // RawViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 240);
            this.Controls.Add(this.hexBox);
            this.Controls.Add(this.toolStrip);
            this.Name = "RawViewer";
            this.Text = "Raw";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton loadFromFileButton;
        private System.Windows.Forms.ToolStripButton saveToFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}