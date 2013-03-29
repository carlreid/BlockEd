namespace BlockEd
{
    partial class Form1
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
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.glMapMain = new OpenTK.GLControl();
            this.updateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tilePicker = new System.Windows.Forms.TabControl();
            this.glMiniMapControl = new OpenTK.GLControl();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.devPanel = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tileTypeLabel = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.layerSelectionBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buildStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ghostingStripButton = new System.Windows.Forms.ToolStripButton();
            this.tileTypeCombo = new System.Windows.Forms.ComboBox();
            this.tileDataGroupBox = new System.Windows.Forms.GroupBox();
            this.tileDataApplyChangesButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.dataTwoTextBox = new System.Windows.Forms.TextBox();
            this.dataTwoLabel = new System.Windows.Forms.Label();
            this.dataOneTextBox = new System.Windows.Forms.TextBox();
            this.dataOneLabel = new System.Windows.Forms.Label();
            this.tileData2ValueLabel = new System.Windows.Forms.Label();
            this.tileData2ValueTextBox = new System.Windows.Forms.TextBox();
            this.tileData1Combo = new System.Windows.Forms.ComboBox();
            this.currentLayerLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.numTilesLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.glLoadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.layerWidthLabel = new System.Windows.Forms.Label();
            this.layerDataGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxTileWidthTextBox = new System.Windows.Forms.TextBox();
            this.maxTileWidthLabel = new System.Windows.Forms.Label();
            this.maxTileHeightTextBox = new System.Windows.Forms.TextBox();
            this.maxTileHeightLabel = new System.Windows.Forms.Label();
            this.layerDrawTypeComboBox = new System.Windows.Forms.ComboBox();
            this.layerZDepthTextBox = new System.Windows.Forms.TextBox();
            this.layerHeightTextBox = new System.Windows.Forms.TextBox();
            this.layerWidthTextBox = new System.Windows.Forms.TextBox();
            this.layerDrawTypeLabel = new System.Windows.Forms.Label();
            this.layerZDepthLabel = new System.Windows.Forms.Label();
            this.layerHeightLabel = new System.Windows.Forms.Label();
            this.editControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.layerDataApplyChangesButton = new System.Windows.Forms.Button();
            this.moveLayerUpPictureBox = new System.Windows.Forms.PictureBox();
            this.moveLayerDownPictureBox = new System.Windows.Forms.PictureBox();
            this.removeLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.newLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.topMenu.SuspendLayout();
            this.devPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tileDataGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.layerDataGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.editControlsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerUpPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerDownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(1264, 24);
            this.topMenu.TabIndex = 0;
            this.topMenu.Text = "Top Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // glMapMain
            // 
            this.glMapMain.BackColor = System.Drawing.Color.Black;
            this.glMapMain.Location = new System.Drawing.Point(1, 51);
            this.glMapMain.Name = "glMapMain";
            this.glMapMain.Size = new System.Drawing.Size(922, 605);
            this.glMapMain.TabIndex = 1;
            this.glMapMain.VSync = false;
            this.glMapMain.Load += new System.EventHandler(this.glControl1_Load);
            this.glMapMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickGL);
            this.glMapMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownGL);
            this.glMapMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mousePanGL);
            this.glMapMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpGL);
            // 
            // updateButton
            // 
            this.updateButton.AccessibleDescription = "";
            this.updateButton.AccessibleName = "";
            this.updateButton.Location = new System.Drawing.Point(282, 27);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Draw GL";
            this.updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Gfx";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load Map";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tilePicker
            // 
            this.tilePicker.Location = new System.Drawing.Point(3, 9);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(328, 238);
            this.tilePicker.TabIndex = 5;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(3, 414);
            this.glMiniMapControl.Name = "glMiniMapControl";
            this.glMiniMapControl.Size = new System.Drawing.Size(200, 200);
            this.glMiniMapControl.TabIndex = 8;
            this.glMiniMapControl.VSync = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(841, 626);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Toggle Dev";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(191, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Load Gfx->GL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(29, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(328, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Load Data and Draw";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // devPanel
            // 
            this.devPanel.Controls.Add(this.button9);
            this.devPanel.Controls.Add(this.button8);
            this.devPanel.Controls.Add(this.button7);
            this.devPanel.Controls.Add(this.tileTypeLabel);
            this.devPanel.Controls.Add(this.button6);
            this.devPanel.Controls.Add(this.button1);
            this.devPanel.Controls.Add(this.button2);
            this.devPanel.Controls.Add(this.button5);
            this.devPanel.Controls.Add(this.button4);
            this.devPanel.Controls.Add(this.updateButton);
            this.devPanel.Location = new System.Drawing.Point(301, 248);
            this.devPanel.Name = "devPanel";
            this.devPanel.Size = new System.Drawing.Size(402, 250);
            this.devPanel.TabIndex = 10;
            this.devPanel.Visible = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(191, 139);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(101, 23);
            this.button9.TabIndex = 15;
            this.button9.Text = "Unserialize XML";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(191, 114);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Serialize to XML";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(110, 114);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "Save Map";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tileTypeLabel
            // 
            this.tileTypeLabel.AutoSize = true;
            this.tileTypeLabel.Location = new System.Drawing.Point(26, 149);
            this.tileTypeLabel.Name = "tileTypeLabel";
            this.tileTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.tileTypeLabel.TabIndex = 12;
            this.tileTypeLabel.Text = "Tile Types:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(29, 85);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(328, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Toggle XML Output";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // layerSelectionBox
            // 
            this.layerSelectionBox.FormattingEnabled = true;
            this.layerSelectionBox.Items.AddRange(new object[] {
            "Show All"});
            this.layerSelectionBox.Location = new System.Drawing.Point(79, 386);
            this.layerSelectionBox.Name = "layerSelectionBox";
            this.layerSelectionBox.Size = new System.Drawing.Size(124, 21);
            this.layerSelectionBox.TabIndex = 11;
            this.layerSelectionBox.Text = "Show All";
            this.layerSelectionBox.SelectedIndexChanged += new System.EventHandler(this.layerSelectionBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStripButton,
            this.saveStripButton,
            this.toolStripSeparator1,
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator2,
            this.buildStripButton,
            this.toolStripSeparator3,
            this.ghostingStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openStripButton
            // 
            this.openStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openStripButton.Image = global::BlockEd.Properties.Resources.Open_6529;
            this.openStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openStripButton.Name = "openStripButton";
            this.openStripButton.Size = new System.Drawing.Size(23, 22);
            this.openStripButton.Text = "Open File (CTRL+O)";
            this.openStripButton.Click += new System.EventHandler(this.openStripButton_Click);
            // 
            // saveStripButton
            // 
            this.saveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveStripButton.Image = global::BlockEd.Properties.Resources.Save_6530;
            this.saveStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveStripButton.Name = "saveStripButton";
            this.saveStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveStripButton.Text = "Save (CTRL+S)";
            this.saveStripButton.Click += new System.EventHandler(this.saveStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = global::BlockEd.Properties.Resources.Undo_16x;
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoStripButton.Text = "Undo (CTRL+Z)";
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = global::BlockEd.Properties.Resources.Redo_16x;
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(23, 22);
            this.redoStripButton.Text = "Redo (CTRL+Y)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buildStripButton
            // 
            this.buildStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buildStripButton.Image = global::BlockEd.Properties.Resources.StatusAnnotations_Play_32xLG_color;
            this.buildStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildStripButton.Name = "buildStripButton";
            this.buildStripButton.Size = new System.Drawing.Size(23, 22);
            this.buildStripButton.Text = "Test (F5)";
            this.buildStripButton.Click += new System.EventHandler(this.buildStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ghostingStripButton
            // 
            this.ghostingStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ghostingStripButton.Image = global::BlockEd.Properties.Resources.ToggleGhosting;
            this.ghostingStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ghostingStripButton.Name = "ghostingStripButton";
            this.ghostingStripButton.Size = new System.Drawing.Size(23, 22);
            this.ghostingStripButton.Text = "Toggle Layer Ghosting";
            this.ghostingStripButton.Click += new System.EventHandler(this.ghostingStripButton_Click);
            // 
            // tileTypeCombo
            // 
            this.tileTypeCombo.FormattingEnabled = true;
            this.tileTypeCombo.Items.AddRange(new object[] {
            "Pickup",
            "Change",
            "Power Effect",
            "Mob Spawn",
            "Replace",
            "Exit",
            "Teleport"});
            this.tileTypeCombo.Location = new System.Drawing.Point(78, 12);
            this.tileTypeCombo.Name = "tileTypeCombo";
            this.tileTypeCombo.Size = new System.Drawing.Size(118, 21);
            this.tileTypeCombo.TabIndex = 11;
            this.tileTypeCombo.SelectedIndexChanged += new System.EventHandler(this.tileTypeCombo_SelectedIndexChanged);
            // 
            // tileDataGroupBox
            // 
            this.tileDataGroupBox.Controls.Add(this.tileDataApplyChangesButton);
            this.tileDataGroupBox.Controls.Add(this.typeLabel);
            this.tileDataGroupBox.Controls.Add(this.dataTwoTextBox);
            this.tileDataGroupBox.Controls.Add(this.dataTwoLabel);
            this.tileDataGroupBox.Controls.Add(this.dataOneTextBox);
            this.tileDataGroupBox.Controls.Add(this.dataOneLabel);
            this.tileDataGroupBox.Controls.Add(this.tileData2ValueLabel);
            this.tileDataGroupBox.Controls.Add(this.tileData2ValueTextBox);
            this.tileDataGroupBox.Controls.Add(this.tileData1Combo);
            this.tileDataGroupBox.Controls.Add(this.tileTypeCombo);
            this.tileDataGroupBox.Location = new System.Drawing.Point(4, 253);
            this.tileDataGroupBox.Name = "tileDataGroupBox";
            this.tileDataGroupBox.Size = new System.Drawing.Size(326, 125);
            this.tileDataGroupBox.TabIndex = 15;
            this.tileDataGroupBox.TabStop = false;
            this.tileDataGroupBox.Text = "Tile Data";
            // 
            // tileDataApplyChangesButton
            // 
            this.tileDataApplyChangesButton.Location = new System.Drawing.Point(12, 97);
            this.tileDataApplyChangesButton.Name = "tileDataApplyChangesButton";
            this.tileDataApplyChangesButton.Size = new System.Drawing.Size(306, 25);
            this.tileDataApplyChangesButton.TabIndex = 16;
            this.tileDataApplyChangesButton.Text = "Apply Changes";
            this.tileDataApplyChangesButton.UseVisualStyleBackColor = true;
            this.tileDataApplyChangesButton.Click += new System.EventHandler(this.tileDataApplyChangesButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(9, 15);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 15;
            this.typeLabel.Text = "Type:";
            // 
            // dataTwoTextBox
            // 
            this.dataTwoTextBox.Location = new System.Drawing.Point(175, 75);
            this.dataTwoTextBox.Name = "dataTwoTextBox";
            this.dataTwoTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataTwoTextBox.TabIndex = 14;
            // 
            // dataTwoLabel
            // 
            this.dataTwoLabel.AutoSize = true;
            this.dataTwoLabel.Location = new System.Drawing.Point(171, 59);
            this.dataTwoLabel.Name = "dataTwoLabel";
            this.dataTwoLabel.Size = new System.Drawing.Size(37, 13);
            this.dataTwoLabel.TabIndex = 13;
            this.dataTwoLabel.Text = "Value:";
            // 
            // dataOneTextBox
            // 
            this.dataOneTextBox.Location = new System.Drawing.Point(13, 75);
            this.dataOneTextBox.Name = "dataOneTextBox";
            this.dataOneTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataOneTextBox.TabIndex = 14;
            // 
            // dataOneLabel
            // 
            this.dataOneLabel.AutoSize = true;
            this.dataOneLabel.Location = new System.Drawing.Point(9, 59);
            this.dataOneLabel.Name = "dataOneLabel";
            this.dataOneLabel.Size = new System.Drawing.Size(37, 13);
            this.dataOneLabel.TabIndex = 13;
            this.dataOneLabel.Text = "Value:";
            // 
            // tileData2ValueLabel
            // 
            this.tileData2ValueLabel.AutoSize = true;
            this.tileData2ValueLabel.Location = new System.Drawing.Point(9, 39);
            this.tileData2ValueLabel.Name = "tileData2ValueLabel";
            this.tileData2ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.tileData2ValueLabel.TabIndex = 13;
            this.tileData2ValueLabel.Text = "Value:";
            // 
            // tileData2ValueTextBox
            // 
            this.tileData2ValueTextBox.Location = new System.Drawing.Point(78, 36);
            this.tileData2ValueTextBox.Name = "tileData2ValueTextBox";
            this.tileData2ValueTextBox.Size = new System.Drawing.Size(240, 20);
            this.tileData2ValueTextBox.TabIndex = 12;
            // 
            // tileData1Combo
            // 
            this.tileData1Combo.FormattingEnabled = true;
            this.tileData1Combo.Location = new System.Drawing.Point(200, 12);
            this.tileData1Combo.Name = "tileData1Combo";
            this.tileData1Combo.Size = new System.Drawing.Size(118, 21);
            this.tileData1Combo.TabIndex = 11;
            this.tileData1Combo.SelectedIndexChanged += new System.EventHandler(this.tileData1Combo_SelectedIndexChanged);
            // 
            // currentLayerLabel
            // 
            this.currentLayerLabel.AutoSize = true;
            this.currentLayerLabel.Location = new System.Drawing.Point(2, 389);
            this.currentLayerLabel.Name = "currentLayerLabel";
            this.currentLayerLabel.Size = new System.Drawing.Size(73, 13);
            this.currentLayerLabel.TabIndex = 17;
            this.currentLayerLabel.Text = "Current Layer:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numTilesLoadedLabel,
            this.glLoadSpeedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // numTilesLoadedLabel
            // 
            this.numTilesLoadedLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.numTilesLoadedLabel.Name = "numTilesLoadedLabel";
            this.numTilesLoadedLabel.Size = new System.Drawing.Size(120, 17);
            this.numTilesLoadedLabel.Text = "Number of Tiles: N/A";
            // 
            // glLoadSpeedLabel
            // 
            this.glLoadSpeedLabel.Name = "glLoadSpeedLabel";
            this.glLoadSpeedLabel.Size = new System.Drawing.Size(98, 17);
            this.glLoadSpeedLabel.Text = "Rendered in: N/A";
            // 
            // layerWidthLabel
            // 
            this.layerWidthLabel.AutoSize = true;
            this.layerWidthLabel.Location = new System.Drawing.Point(7, 19);
            this.layerWidthLabel.Name = "layerWidthLabel";
            this.layerWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.layerWidthLabel.TabIndex = 21;
            this.layerWidthLabel.Text = "Width:";
            // 
            // layerDataGroupBox
            // 
            this.layerDataGroupBox.Controls.Add(this.groupBox2);
            this.layerDataGroupBox.Controls.Add(this.layerDrawTypeComboBox);
            this.layerDataGroupBox.Controls.Add(this.layerZDepthTextBox);
            this.layerDataGroupBox.Controls.Add(this.layerHeightTextBox);
            this.layerDataGroupBox.Controls.Add(this.layerWidthTextBox);
            this.layerDataGroupBox.Controls.Add(this.layerDrawTypeLabel);
            this.layerDataGroupBox.Controls.Add(this.layerZDepthLabel);
            this.layerDataGroupBox.Controls.Add(this.layerHeightLabel);
            this.layerDataGroupBox.Controls.Add(this.layerWidthLabel);
            this.layerDataGroupBox.Location = new System.Drawing.Point(208, 409);
            this.layerDataGroupBox.Name = "layerDataGroupBox";
            this.layerDataGroupBox.Size = new System.Drawing.Size(121, 210);
            this.layerDataGroupBox.TabIndex = 22;
            this.layerDataGroupBox.TabStop = false;
            this.layerDataGroupBox.Text = "Layer Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxTileWidthTextBox);
            this.groupBox2.Controls.Add(this.maxTileWidthLabel);
            this.groupBox2.Controls.Add(this.maxTileHeightTextBox);
            this.groupBox2.Controls.Add(this.maxTileHeightLabel);
            this.groupBox2.Location = new System.Drawing.Point(2, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 62);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile Size";
            // 
            // maxTileWidthTextBox
            // 
            this.maxTileWidthTextBox.Location = new System.Drawing.Point(42, 15);
            this.maxTileWidthTextBox.Name = "maxTileWidthTextBox";
            this.maxTileWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileWidthTextBox.TabIndex = 23;
            // 
            // maxTileWidthLabel
            // 
            this.maxTileWidthLabel.AutoSize = true;
            this.maxTileWidthLabel.Location = new System.Drawing.Point(4, 18);
            this.maxTileWidthLabel.Name = "maxTileWidthLabel";
            this.maxTileWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.maxTileWidthLabel.TabIndex = 21;
            this.maxTileWidthLabel.Text = "Width:";
            // 
            // maxTileHeightTextBox
            // 
            this.maxTileHeightTextBox.Location = new System.Drawing.Point(42, 36);
            this.maxTileHeightTextBox.Name = "maxTileHeightTextBox";
            this.maxTileHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileHeightTextBox.TabIndex = 23;
            // 
            // maxTileHeightLabel
            // 
            this.maxTileHeightLabel.AutoSize = true;
            this.maxTileHeightLabel.Location = new System.Drawing.Point(1, 39);
            this.maxTileHeightLabel.Name = "maxTileHeightLabel";
            this.maxTileHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.maxTileHeightLabel.TabIndex = 21;
            this.maxTileHeightLabel.Text = "Height:";
            // 
            // layerDrawTypeComboBox
            // 
            this.layerDrawTypeComboBox.FormattingEnabled = true;
            this.layerDrawTypeComboBox.Items.AddRange(new object[] {
            "Empty",
            "Copy",
            "Transparent"});
            this.layerDrawTypeComboBox.Location = new System.Drawing.Point(4, 159);
            this.layerDrawTypeComboBox.Name = "layerDrawTypeComboBox";
            this.layerDrawTypeComboBox.Size = new System.Drawing.Size(115, 21);
            this.layerDrawTypeComboBox.TabIndex = 25;
            // 
            // layerZDepthTextBox
            // 
            this.layerZDepthTextBox.Location = new System.Drawing.Point(48, 58);
            this.layerZDepthTextBox.Name = "layerZDepthTextBox";
            this.layerZDepthTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerZDepthTextBox.TabIndex = 24;
            // 
            // layerHeightTextBox
            // 
            this.layerHeightTextBox.Location = new System.Drawing.Point(48, 37);
            this.layerHeightTextBox.Name = "layerHeightTextBox";
            this.layerHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerHeightTextBox.TabIndex = 22;
            // 
            // layerWidthTextBox
            // 
            this.layerWidthTextBox.Location = new System.Drawing.Point(48, 16);
            this.layerWidthTextBox.Name = "layerWidthTextBox";
            this.layerWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerWidthTextBox.TabIndex = 22;
            // 
            // layerDrawTypeLabel
            // 
            this.layerDrawTypeLabel.AutoSize = true;
            this.layerDrawTypeLabel.Location = new System.Drawing.Point(4, 143);
            this.layerDrawTypeLabel.Name = "layerDrawTypeLabel";
            this.layerDrawTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.layerDrawTypeLabel.TabIndex = 21;
            this.layerDrawTypeLabel.Text = "Draw Type:";
            // 
            // layerZDepthLabel
            // 
            this.layerZDepthLabel.AutoSize = true;
            this.layerZDepthLabel.Location = new System.Drawing.Point(2, 61);
            this.layerZDepthLabel.Name = "layerZDepthLabel";
            this.layerZDepthLabel.Size = new System.Drawing.Size(49, 13);
            this.layerZDepthLabel.TabIndex = 21;
            this.layerZDepthLabel.Text = "Z Depth:";
            // 
            // layerHeightLabel
            // 
            this.layerHeightLabel.AutoSize = true;
            this.layerHeightLabel.Location = new System.Drawing.Point(4, 40);
            this.layerHeightLabel.Name = "layerHeightLabel";
            this.layerHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.layerHeightLabel.TabIndex = 21;
            this.layerHeightLabel.Text = "Height:";
            // 
            // editControlsGroupBox
            // 
            this.editControlsGroupBox.Controls.Add(this.layerDataApplyChangesButton);
            this.editControlsGroupBox.Controls.Add(this.moveLayerUpPictureBox);
            this.editControlsGroupBox.Controls.Add(this.moveLayerDownPictureBox);
            this.editControlsGroupBox.Controls.Add(this.tilePicker);
            this.editControlsGroupBox.Controls.Add(this.layerDataGroupBox);
            this.editControlsGroupBox.Controls.Add(this.glMiniMapControl);
            this.editControlsGroupBox.Controls.Add(this.layerSelectionBox);
            this.editControlsGroupBox.Controls.Add(this.removeLayerPictureBox);
            this.editControlsGroupBox.Controls.Add(this.tileDataGroupBox);
            this.editControlsGroupBox.Controls.Add(this.newLayerPictureBox);
            this.editControlsGroupBox.Controls.Add(this.currentLayerLabel);
            this.editControlsGroupBox.Location = new System.Drawing.Point(926, 40);
            this.editControlsGroupBox.Name = "editControlsGroupBox";
            this.editControlsGroupBox.Size = new System.Drawing.Size(334, 619);
            this.editControlsGroupBox.TabIndex = 23;
            this.editControlsGroupBox.TabStop = false;
            // 
            // layerDataApplyChangesButton
            // 
            this.layerDataApplyChangesButton.Location = new System.Drawing.Point(211, 591);
            this.layerDataApplyChangesButton.Name = "layerDataApplyChangesButton";
            this.layerDataApplyChangesButton.Size = new System.Drawing.Size(117, 25);
            this.layerDataApplyChangesButton.TabIndex = 17;
            this.layerDataApplyChangesButton.Text = "Apply Changes";
            this.layerDataApplyChangesButton.UseVisualStyleBackColor = true;
            // 
            // moveLayerUpPictureBox
            // 
            this.moveLayerUpPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.MoveLayerUp;
            this.moveLayerUpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveLayerUpPictureBox.Location = new System.Drawing.Point(295, 386);
            this.moveLayerUpPictureBox.Name = "moveLayerUpPictureBox";
            this.moveLayerUpPictureBox.Size = new System.Drawing.Size(23, 22);
            this.moveLayerUpPictureBox.TabIndex = 24;
            this.moveLayerUpPictureBox.TabStop = false;
            this.moveLayerUpPictureBox.Click += new System.EventHandler(this.moveLayerUpPictureBox_Click);
            // 
            // moveLayerDownPictureBox
            // 
            this.moveLayerDownPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.MoveLayerDown;
            this.moveLayerDownPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveLayerDownPictureBox.Location = new System.Drawing.Point(266, 386);
            this.moveLayerDownPictureBox.Name = "moveLayerDownPictureBox";
            this.moveLayerDownPictureBox.Size = new System.Drawing.Size(23, 22);
            this.moveLayerDownPictureBox.TabIndex = 23;
            this.moveLayerDownPictureBox.TabStop = false;
            this.moveLayerDownPictureBox.Click += new System.EventHandler(this.moveLayerDownPictureBox_Click);
            // 
            // removeLayerPictureBox
            // 
            this.removeLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.RemoveLayer;
            this.removeLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeLayerPictureBox.Location = new System.Drawing.Point(237, 386);
            this.removeLayerPictureBox.Name = "removeLayerPictureBox";
            this.removeLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.removeLayerPictureBox.TabIndex = 19;
            this.removeLayerPictureBox.TabStop = false;
            // 
            // newLayerPictureBox
            // 
            this.newLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.AddLayer;
            this.newLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newLayerPictureBox.Location = new System.Drawing.Point(208, 386);
            this.newLayerPictureBox.Name = "newLayerPictureBox";
            this.newLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.newLayerPictureBox.TabIndex = 18;
            this.newLayerPictureBox.TabStop = false;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(760, 626);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 24;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.editControlsGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.devPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.glMapMain);
            this.Controls.Add(this.topMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.topMenu;
            this.Name = "Form1";
            this.Text = "BlockEd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.editorClosing);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.devPanel.ResumeLayout(false);
            this.devPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tileDataGroupBox.ResumeLayout(false);
            this.tileDataGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.layerDataGroupBox.ResumeLayout(false);
            this.layerDataGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.editControlsGroupBox.ResumeLayout(false);
            this.editControlsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerUpPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerDownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private OpenTK.GLControl glMapMain;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tilePicker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private OpenTK.GLControl glMiniMapControl;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel devPanel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox layerSelectionBox;
        private System.Windows.Forms.Label tileTypeLabel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openStripButton;
        private System.Windows.Forms.ToolStripButton saveStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton undoStripButton;
        private System.Windows.Forms.ToolStripButton redoStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buildStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        internal System.Windows.Forms.ComboBox tileTypeCombo;
        internal System.Windows.Forms.TextBox tileData2ValueTextBox;
        internal System.Windows.Forms.ComboBox tileData1Combo;
        internal System.Windows.Forms.Label tileData2ValueLabel;
        internal System.Windows.Forms.GroupBox tileDataGroupBox;
        internal System.Windows.Forms.Label dataOneLabel;
        internal System.Windows.Forms.TextBox dataOneTextBox;
        internal System.Windows.Forms.TextBox dataTwoTextBox;
        internal System.Windows.Forms.Label dataTwoLabel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label currentLayerLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.PictureBox newLayerPictureBox;
        private System.Windows.Forms.PictureBox removeLayerPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel glLoadSpeedLabel;
        private System.Windows.Forms.Label layerWidthLabel;
        private System.Windows.Forms.GroupBox layerDataGroupBox;
        private System.Windows.Forms.TextBox layerHeightTextBox;
        private System.Windows.Forms.TextBox layerWidthTextBox;
        private System.Windows.Forms.Label layerHeightLabel;
        private System.Windows.Forms.TextBox maxTileHeightTextBox;
        private System.Windows.Forms.TextBox maxTileWidthTextBox;
        private System.Windows.Forms.Label maxTileHeightLabel;
        private System.Windows.Forms.Label maxTileWidthLabel;
        private System.Windows.Forms.ComboBox layerDrawTypeComboBox;
        private System.Windows.Forms.TextBox layerZDepthTextBox;
        private System.Windows.Forms.Label layerDrawTypeLabel;
        private System.Windows.Forms.Label layerZDepthLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox editControlsGroupBox;
        private System.Windows.Forms.ToolStripStatusLabel numTilesLoadedLabel;
        private System.Windows.Forms.PictureBox moveLayerDownPictureBox;
        private System.Windows.Forms.PictureBox moveLayerUpPictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ghostingStripButton;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button tileDataApplyChangesButton;
        private System.Windows.Forms.Button layerDataApplyChangesButton;
    }
}

