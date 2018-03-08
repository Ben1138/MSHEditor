namespace MSHEditor {
    partial class EditorForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.logBox = new System.Windows.Forms.TextBox();
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkMSHIntegrityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMaterialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMaterialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeModelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSegmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSegmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mshView = new System.Windows.Forms.TreeView();
            this.inspector = new System.Windows.Forms.PropertyGrid();
            this.glControl1 = new OpenTK.GLControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.drawModeSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sensitivitySlider = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPickColorGL = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.topMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(3, 3);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(1155, 112);
            this.logBox.TabIndex = 1;
            this.logBox.WordWrap = false;
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.checkToolStripMenuItem,
            this.materialToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.segmentToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(1184, 24);
            this.topMenu.TabIndex = 2;
            this.topMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMSHToolStripMenuItem,
            this.saveMSHToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMSHToolStripMenuItem
            // 
            this.openMSHToolStripMenuItem.Name = "openMSHToolStripMenuItem";
            this.openMSHToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openMSHToolStripMenuItem.Text = "Open MSH";
            this.openMSHToolStripMenuItem.Click += new System.EventHandler(this.openMSHToolStripMenuItem_Click);
            // 
            // saveMSHToolStripMenuItem
            // 
            this.saveMSHToolStripMenuItem.Name = "saveMSHToolStripMenuItem";
            this.saveMSHToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveMSHToolStripMenuItem.Text = "Save MSH";
            this.saveMSHToolStripMenuItem.Click += new System.EventHandler(this.saveMSHToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkMSHIntegrityToolStripMenuItem});
            this.checkToolStripMenuItem.Enabled = false;
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.checkToolStripMenuItem.Text = "Check";
            // 
            // checkMSHIntegrityToolStripMenuItem
            // 
            this.checkMSHIntegrityToolStripMenuItem.Name = "checkMSHIntegrityToolStripMenuItem";
            this.checkMSHIntegrityToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.checkMSHIntegrityToolStripMenuItem.Text = "Check MSH Integrity";
            this.checkMSHIntegrityToolStripMenuItem.Click += new System.EventHandler(this.checkMSHIntegrityToolStripMenuItem_Click);
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMaterialMenuItem,
            this.removeMaterialMenuItem});
            this.materialToolStripMenuItem.Enabled = false;
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.materialToolStripMenuItem.Text = "Material";
            // 
            // addMaterialMenuItem
            // 
            this.addMaterialMenuItem.Name = "addMaterialMenuItem";
            this.addMaterialMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addMaterialMenuItem.Text = "Add New";
            this.addMaterialMenuItem.Click += new System.EventHandler(this.addMaterialMenuItem_Click);
            // 
            // removeMaterialMenuItem
            // 
            this.removeMaterialMenuItem.Enabled = false;
            this.removeMaterialMenuItem.Name = "removeMaterialMenuItem";
            this.removeMaterialMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeMaterialMenuItem.Text = "Remove Selected";
            this.removeMaterialMenuItem.Click += new System.EventHandler(this.removeMaterialMenuItem_Click);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModelMenuItem,
            this.removeModelMenuItem});
            this.modelToolStripMenuItem.Enabled = false;
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.modelToolStripMenuItem.Text = "Model";
            // 
            // addModelMenuItem
            // 
            this.addModelMenuItem.Name = "addModelMenuItem";
            this.addModelMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addModelMenuItem.Text = "Add New";
            this.addModelMenuItem.Visible = false;
            this.addModelMenuItem.Click += new System.EventHandler(this.addModelMenuItem_Click);
            // 
            // removeModelMenuItem
            // 
            this.removeModelMenuItem.Enabled = false;
            this.removeModelMenuItem.Name = "removeModelMenuItem";
            this.removeModelMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeModelMenuItem.Text = "Remove Selected";
            this.removeModelMenuItem.Click += new System.EventHandler(this.removeModelMenuItem_Click);
            // 
            // segmentToolStripMenuItem
            // 
            this.segmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSegmentMenuItem,
            this.removeSegmentMenuItem});
            this.segmentToolStripMenuItem.Enabled = false;
            this.segmentToolStripMenuItem.Name = "segmentToolStripMenuItem";
            this.segmentToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.segmentToolStripMenuItem.Text = "Segment";
            this.segmentToolStripMenuItem.Visible = false;
            // 
            // addSegmentMenuItem
            // 
            this.addSegmentMenuItem.Name = "addSegmentMenuItem";
            this.addSegmentMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addSegmentMenuItem.Text = "Add Segment";
            // 
            // removeSegmentMenuItem
            // 
            this.removeSegmentMenuItem.Enabled = false;
            this.removeSegmentMenuItem.Name = "removeSegmentMenuItem";
            this.removeSegmentMenuItem.Size = new System.Drawing.Size(167, 22);
            this.removeSegmentMenuItem.Text = "Remove Segment";
            // 
            // mshView
            // 
            this.mshView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mshView.Enabled = false;
            this.mshView.ItemHeight = 18;
            this.mshView.Location = new System.Drawing.Point(3, 3);
            this.mshView.Name = "mshView";
            this.mshView.PathSeparator = ".";
            this.mshView.Size = new System.Drawing.Size(246, 488);
            this.mshView.TabIndex = 3;
            this.mshView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // inspector
            // 
            this.inspector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inspector.Enabled = false;
            this.inspector.Location = new System.Drawing.Point(3, 3);
            this.inspector.Name = "inspector";
            this.inspector.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.inspector.Size = new System.Drawing.Size(314, 488);
            this.inspector.TabIndex = 5;
            this.inspector.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // glControl1
            // 
            this.glControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(3, 36);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(569, 428);
            this.glControl1.TabIndex = 6;
            this.glControl1.VSync = false;
            this.glControl1.SizeChanged += new System.EventHandler(this.glControl1_SizeChanged);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inspector);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.drawModeSelect);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.sensitivitySlider);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonPickColorGL);
            this.splitContainer1.Panel2.Controls.Add(this.glControl1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(899, 494);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 7;
            // 
            // drawModeSelect
            // 
            this.drawModeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.drawModeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drawModeSelect.Items.AddRange(new object[] {
            "Point",
            "Wireframe",
            "Textured"});
            this.drawModeSelect.Location = new System.Drawing.Point(422, 470);
            this.drawModeSelect.Name = "drawModeSelect";
            this.drawModeSelect.Size = new System.Drawing.Size(150, 21);
            this.drawModeSelect.TabIndex = 12;
            this.drawModeSelect.SelectedIndexChanged += new System.EventHandler(this.drawModeSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Left Mouse: Rotate        Right Mouse: Translate        Mouse Wheel: Zoom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mouse Sensitivity:";
            // 
            // sensitivitySlider
            // 
            this.sensitivitySlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensitivitySlider.AutoSize = false;
            this.sensitivitySlider.Location = new System.Drawing.Point(272, 3);
            this.sensitivitySlider.Maximum = 100;
            this.sensitivitySlider.Minimum = 1;
            this.sensitivitySlider.Name = "sensitivitySlider";
            this.sensitivitySlider.Size = new System.Drawing.Size(300, 27);
            this.sensitivitySlider.TabIndex = 9;
            this.sensitivitySlider.TickFrequency = 10;
            this.sensitivitySlider.Value = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reset Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPickColorGL
            // 
            this.buttonPickColorGL.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPickColorGL.Location = new System.Drawing.Point(3, 3);
            this.buttonPickColorGL.Name = "buttonPickColorGL";
            this.buttonPickColorGL.Size = new System.Drawing.Size(69, 23);
            this.buttonPickColorGL.TabIndex = 7;
            this.buttonPickColorGL.UseVisualStyleBackColor = false;
            this.buttonPickColorGL.Click += new System.EventHandler(this.buttonPickColorGL_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mshView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1154, 494);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 8;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(12, 27);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.logBox);
            this.splitContainer3.Size = new System.Drawing.Size(1160, 622);
            this.splitContainer3.SplitterDistance = 500;
            this.splitContainer3.TabIndex = 6;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.topMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.topMenu;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSH Editor";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sensitivitySlider)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMSHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView mshView;
        private System.Windows.Forms.PropertyGrid inspector;
        private System.Windows.Forms.ToolStripMenuItem saveMSHToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkMSHIntegrityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMaterialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMaterialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeModelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSegmentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSegmentMenuItem;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button buttonPickColorGL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar sensitivitySlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drawModeSelect;
    }
}

