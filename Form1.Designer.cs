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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tileTypeCombo = new System.Windows.Forms.ComboBox();
            this.tileDataGroupBox = new System.Windows.Forms.GroupBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.dataTwoTextBox = new System.Windows.Forms.TextBox();
            this.dataTwoLabel = new System.Windows.Forms.Label();
            this.dataOneTextBox = new System.Windows.Forms.TextBox();
            this.dataOneLabel = new System.Windows.Forms.Label();
            this.tileData2ValueLabel = new System.Windows.Forms.Label();
            this.tileData2ValueTextBox = new System.Windows.Forms.TextBox();
            this.tileData1Combo = new System.Windows.Forms.ComboBox();
            this.currentLayerLabel = new System.Windows.Forms.Label();
            this.openStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveStripButton = new System.Windows.Forms.ToolStripButton();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.buildStripButton = new System.Windows.Forms.ToolStripButton();
            this.newLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.removeLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.glLoadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.layerWidthLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layerWidthTextBox = new System.Windows.Forms.TextBox();
            this.layerHeightTextBox = new System.Windows.Forms.TextBox();
            this.layerHeightLabel = new System.Windows.Forms.Label();
            this.maxTileWidthLabel = new System.Windows.Forms.Label();
            this.maxTileHeightLabel = new System.Windows.Forms.Label();
            this.maxTileWidthTextBox = new System.Windows.Forms.TextBox();
            this.maxTileHeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.topMenu.SuspendLayout();
            this.devPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tileDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tilePicker.Location = new System.Drawing.Point(930, 51);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(328, 238);
            this.tilePicker.TabIndex = 5;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(930, 456);
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
            this.layerSelectionBox.Location = new System.Drawing.Point(1006, 428);
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
            this.buildStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.tileTypeCombo.Location = new System.Drawing.Point(78, 20);
            this.tileTypeCombo.Name = "tileTypeCombo";
            this.tileTypeCombo.Size = new System.Drawing.Size(118, 21);
            this.tileTypeCombo.TabIndex = 11;
            // 
            // tileDataGroupBox
            // 
            this.tileDataGroupBox.Controls.Add(this.typeLabel);
            this.tileDataGroupBox.Controls.Add(this.dataTwoTextBox);
            this.tileDataGroupBox.Controls.Add(this.dataTwoLabel);
            this.tileDataGroupBox.Controls.Add(this.dataOneTextBox);
            this.tileDataGroupBox.Controls.Add(this.dataOneLabel);
            this.tileDataGroupBox.Controls.Add(this.tileData2ValueLabel);
            this.tileDataGroupBox.Controls.Add(this.tileData2ValueTextBox);
            this.tileDataGroupBox.Controls.Add(this.tileData1Combo);
            this.tileDataGroupBox.Controls.Add(this.tileTypeCombo);
            this.tileDataGroupBox.Location = new System.Drawing.Point(931, 295);
            this.tileDataGroupBox.Name = "tileDataGroupBox";
            this.tileDataGroupBox.Size = new System.Drawing.Size(326, 125);
            this.tileDataGroupBox.TabIndex = 15;
            this.tileDataGroupBox.TabStop = false;
            this.tileDataGroupBox.Text = "Tile Data";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(9, 23);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 15;
            this.typeLabel.Text = "Type:";
            // 
            // dataTwoTextBox
            // 
            this.dataTwoTextBox.Location = new System.Drawing.Point(175, 92);
            this.dataTwoTextBox.Name = "dataTwoTextBox";
            this.dataTwoTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataTwoTextBox.TabIndex = 14;
            // 
            // dataTwoLabel
            // 
            this.dataTwoLabel.AutoSize = true;
            this.dataTwoLabel.Location = new System.Drawing.Point(171, 76);
            this.dataTwoLabel.Name = "dataTwoLabel";
            this.dataTwoLabel.Size = new System.Drawing.Size(37, 13);
            this.dataTwoLabel.TabIndex = 13;
            this.dataTwoLabel.Text = "Value:";
            // 
            // dataOneTextBox
            // 
            this.dataOneTextBox.Location = new System.Drawing.Point(13, 92);
            this.dataOneTextBox.Name = "dataOneTextBox";
            this.dataOneTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataOneTextBox.TabIndex = 14;
            // 
            // dataOneLabel
            // 
            this.dataOneLabel.AutoSize = true;
            this.dataOneLabel.Location = new System.Drawing.Point(9, 76);
            this.dataOneLabel.Name = "dataOneLabel";
            this.dataOneLabel.Size = new System.Drawing.Size(37, 13);
            this.dataOneLabel.TabIndex = 13;
            this.dataOneLabel.Text = "Value:";
            // 
            // tileData2ValueLabel
            // 
            this.tileData2ValueLabel.AutoSize = true;
            this.tileData2ValueLabel.Location = new System.Drawing.Point(9, 50);
            this.tileData2ValueLabel.Name = "tileData2ValueLabel";
            this.tileData2ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.tileData2ValueLabel.TabIndex = 13;
            this.tileData2ValueLabel.Text = "Value:";
            // 
            // tileData2ValueTextBox
            // 
            this.tileData2ValueTextBox.Location = new System.Drawing.Point(78, 47);
            this.tileData2ValueTextBox.Name = "tileData2ValueTextBox";
            this.tileData2ValueTextBox.Size = new System.Drawing.Size(240, 20);
            this.tileData2ValueTextBox.TabIndex = 12;
            // 
            // tileData1Combo
            // 
            this.tileData1Combo.FormattingEnabled = true;
            this.tileData1Combo.Location = new System.Drawing.Point(200, 20);
            this.tileData1Combo.Name = "tileData1Combo";
            this.tileData1Combo.Size = new System.Drawing.Size(118, 21);
            this.tileData1Combo.TabIndex = 11;
            // 
            // currentLayerLabel
            // 
            this.currentLayerLabel.AutoSize = true;
            this.currentLayerLabel.Location = new System.Drawing.Point(929, 431);
            this.currentLayerLabel.Name = "currentLayerLabel";
            this.currentLayerLabel.Size = new System.Drawing.Size(73, 13);
            this.currentLayerLabel.TabIndex = 17;
            this.currentLayerLabel.Text = "Current Layer:";
            // 
            // openStripButton
            // 
            this.openStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openStripButton.Image = global::BlockEd.Properties.Resources.Open_6529;
            this.openStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openStripButton.Name = "openStripButton";
            this.openStripButton.Size = new System.Drawing.Size(23, 22);
            this.openStripButton.Text = "Open File (CTRL+O)";
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
            // newLayerPictureBox
            // 
            this.newLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.AddLayer;
            this.newLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newLayerPictureBox.Location = new System.Drawing.Point(1135, 428);
            this.newLayerPictureBox.Name = "newLayerPictureBox";
            this.newLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.newLayerPictureBox.TabIndex = 18;
            this.newLayerPictureBox.TabStop = false;
            // 
            // removeLayerPictureBox
            // 
            this.removeLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.RemoveLayer;
            this.removeLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeLayerPictureBox.Location = new System.Drawing.Point(1164, 428);
            this.removeLayerPictureBox.Name = "removeLayerPictureBox";
            this.removeLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.removeLayerPictureBox.TabIndex = 19;
            this.removeLayerPictureBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.glLoadSpeedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
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
            this.layerWidthLabel.Location = new System.Drawing.Point(7, 22);
            this.layerWidthLabel.Name = "layerWidthLabel";
            this.layerWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.layerWidthLabel.TabIndex = 21;
            this.layerWidthLabel.Text = "Width:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.layerHeightTextBox);
            this.groupBox1.Controls.Add(this.layerWidthTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.layerHeightLabel);
            this.groupBox1.Controls.Add(this.layerWidthLabel);
            this.groupBox1.Location = new System.Drawing.Point(1135, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 200);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layer Data";
            // 
            // layerWidthTextBox
            // 
            this.layerWidthTextBox.Location = new System.Drawing.Point(48, 19);
            this.layerWidthTextBox.Name = "layerWidthTextBox";
            this.layerWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerWidthTextBox.TabIndex = 22;
            // 
            // layerHeightTextBox
            // 
            this.layerHeightTextBox.Location = new System.Drawing.Point(48, 40);
            this.layerHeightTextBox.Name = "layerHeightTextBox";
            this.layerHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerHeightTextBox.TabIndex = 22;
            // 
            // layerHeightLabel
            // 
            this.layerHeightLabel.AutoSize = true;
            this.layerHeightLabel.Location = new System.Drawing.Point(4, 43);
            this.layerHeightLabel.Name = "layerHeightLabel";
            this.layerHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.layerHeightLabel.TabIndex = 21;
            this.layerHeightLabel.Text = "Height:";
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
            // maxTileHeightLabel
            // 
            this.maxTileHeightLabel.AutoSize = true;
            this.maxTileHeightLabel.Location = new System.Drawing.Point(1, 39);
            this.maxTileHeightLabel.Name = "maxTileHeightLabel";
            this.maxTileHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.maxTileHeightLabel.TabIndex = 21;
            this.maxTileHeightLabel.Text = "Height:";
            // 
            // maxTileWidthTextBox
            // 
            this.maxTileWidthTextBox.Location = new System.Drawing.Point(42, 15);
            this.maxTileWidthTextBox.Name = "maxTileWidthTextBox";
            this.maxTileWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileWidthTextBox.TabIndex = 23;
            // 
            // maxTileHeightTextBox
            // 
            this.maxTileHeightTextBox.Location = new System.Drawing.Point(42, 36);
            this.maxTileHeightTextBox.Name = "maxTileHeightTextBox";
            this.maxTileHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileHeightTextBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Z Depth:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Draw Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 172);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxTileWidthTextBox);
            this.groupBox2.Controls.Add(this.maxTileWidthLabel);
            this.groupBox2.Controls.Add(this.maxTileHeightTextBox);
            this.groupBox2.Controls.Add(this.maxTileHeightLabel);
            this.groupBox2.Location = new System.Drawing.Point(2, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 62);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.removeLayerPictureBox);
            this.Controls.Add(this.newLayerPictureBox);
            this.Controls.Add(this.currentLayerLabel);
            this.Controls.Add(this.tileDataGroupBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.layerSelectionBox);
            this.Controls.Add(this.glMiniMapControl);
            this.Controls.Add(this.devPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tilePicker);
            this.Controls.Add(this.glMapMain);
            this.Controls.Add(this.topMenu);
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
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox layerHeightTextBox;
        private System.Windows.Forms.TextBox layerWidthTextBox;
        private System.Windows.Forms.Label layerHeightLabel;
        private System.Windows.Forms.TextBox maxTileHeightTextBox;
        private System.Windows.Forms.TextBox maxTileWidthTextBox;
        private System.Windows.Forms.Label maxTileHeightLabel;
        private System.Windows.Forms.Label maxTileWidthLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

