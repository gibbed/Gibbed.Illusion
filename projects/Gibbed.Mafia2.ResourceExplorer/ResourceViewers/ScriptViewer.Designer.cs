namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class ScriptViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptViewer));
            System.Windows.Forms.ToolStripButton _LoadFromFileButton;
            System.Windows.Forms.ToolStripButton _SaveToFileButton;
            this._ScriptComboBox = new System.Windows.Forms.ComboBox();
            this._HexBox = new Be.Windows.Forms.HexBox();
            this._ScriptToolStrip = new System.Windows.Forms.ToolStrip();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            _MainToolStrip = new System.Windows.Forms.ToolStrip();
            _SaveButton = new System.Windows.Forms.ToolStripButton();
            _LoadFromFileButton = new System.Windows.Forms.ToolStripButton();
            _SaveToFileButton = new System.Windows.Forms.ToolStripButton();
            _MainToolStrip.SuspendLayout();
            this._ScriptToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _MainToolStrip
            // 
            _MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SaveButton});
            _MainToolStrip.Location = new System.Drawing.Point(0, 0);
            _MainToolStrip.Name = "_MainToolStrip";
            _MainToolStrip.Size = new System.Drawing.Size(640, 25);
            _MainToolStrip.TabIndex = 0;
            _MainToolStrip.Text = "toolStrip1";
            // 
            // _SaveButton
            // 
            _SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveButton.Image")));
            _SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveButton.Name = "_SaveButton";
            _SaveButton.Size = new System.Drawing.Size(51, 22);
            _SaveButton.Text = "Save";
            _SaveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // _ScriptComboBox
            // 
            this._ScriptComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._ScriptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ScriptComboBox.FormattingEnabled = true;
            this._ScriptComboBox.Location = new System.Drawing.Point(0, 25);
            this._ScriptComboBox.Name = "_ScriptComboBox";
            this._ScriptComboBox.Size = new System.Drawing.Size(640, 21);
            this._ScriptComboBox.TabIndex = 1;
            this._ScriptComboBox.SelectedValueChanged += new System.EventHandler(this.OnSelectScript);
            // 
            // _HexBox
            // 
            this._HexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._HexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._HexBox.InfoForeColor = System.Drawing.Color.Empty;
            this._HexBox.LineInfoVisible = true;
            this._HexBox.Location = new System.Drawing.Point(0, 71);
            this._HexBox.Name = "_HexBox";
            this._HexBox.ReadOnly = true;
            this._HexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this._HexBox.Size = new System.Drawing.Size(640, 169);
            this._HexBox.StringViewVisible = true;
            this._HexBox.TabIndex = 2;
            this._HexBox.UseFixedBytesPerLine = true;
            this._HexBox.VScrollBarVisible = true;
            // 
            // _ScriptToolStrip
            // 
            this._ScriptToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _LoadFromFileButton,
            _SaveToFileButton});
            this._ScriptToolStrip.Location = new System.Drawing.Point(0, 46);
            this._ScriptToolStrip.Name = "_ScriptToolStrip";
            this._ScriptToolStrip.Size = new System.Drawing.Size(640, 25);
            this._ScriptToolStrip.TabIndex = 3;
            this._ScriptToolStrip.Text = "toolStrip2";
            // 
            // _LoadFromFileButton
            // 
            _LoadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_LoadFromFileButton.Image")));
            _LoadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _LoadFromFileButton.Name = "_LoadFromFileButton";
            _LoadFromFileButton.Size = new System.Drawing.Size(105, 22);
            _LoadFromFileButton.Text = "Load From File";
            _LoadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // _SaveToFileButton
            // 
            _SaveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveToFileButton.Image")));
            _SaveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveToFileButton.Name = "_SaveToFileButton";
            _SaveToFileButton.Size = new System.Drawing.Size(89, 22);
            _SaveToFileButton.Text = "Save To File";
            _SaveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.DefaultExt = "lua";
            this._SaveFileDialog.Filter = "Lua Scripts (*.lua)|*.lua|All Files (*.*)|*.*";
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.DefaultExt = "lua";
            this._OpenFileDialog.Filter = "Lua Scripts (*.lua)|*.lua|All Files (*.*)|*.*";
            // 
            // ScriptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 240);
            this.Controls.Add(this._HexBox);
            this.Controls.Add(this._ScriptToolStrip);
            this.Controls.Add(this._ScriptComboBox);
            this.Controls.Add(_MainToolStrip);
            this.Name = "ScriptViewer";
            this.Text = "Script";
            _MainToolStrip.ResumeLayout(false);
            _MainToolStrip.PerformLayout();
            this._ScriptToolStrip.ResumeLayout(false);
            this._ScriptToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _ScriptComboBox;
        private Be.Windows.Forms.HexBox _HexBox;
        private System.Windows.Forms.ToolStrip _ScriptToolStrip;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
    }
}