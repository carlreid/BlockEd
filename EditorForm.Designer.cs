namespace BlockEd
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tileTypeCombo = new System.Windows.Forms.ComboBox();
            this.tileDataApplyChangesButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.dataTwoLabel = new System.Windows.Forms.Label();
            this.tileData2ValueTextBox = new System.Windows.Forms.MaskedTextBox();
            this.dataTwoTextBox = new System.Windows.Forms.MaskedTextBox();
            this.dataOneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.dataOneLabel = new System.Windows.Forms.Label();
            this.tileData2ValueLabel = new System.Windows.Forms.Label();
            this.tileData1Combo = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.numTilesLoadedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.glLoadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.layerWidthLabel = new System.Windows.Forms.Label();
            this.layerNameTextBox = new System.Windows.Forms.MaskedTextBox();
            this.layerHeightTextBox = new System.Windows.Forms.MaskedTextBox();
            this.layerOffsetYTextBox = new System.Windows.Forms.MaskedTextBox();
            this.layerOffsetXTextBox = new System.Windows.Forms.MaskedTextBox();
            this.layerWidthTextBox = new System.Windows.Forms.MaskedTextBox();
            this.layerNameLabel = new System.Windows.Forms.Label();
            this.layerZDepthTextBox = new System.Windows.Forms.NumericUpDown();
            this.layerOffsetYLabel = new System.Windows.Forms.Label();
            this.layerOffsetXLabel = new System.Windows.Forms.Label();
            this.layerDataApplyChangesButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxTileWidthTextBox = new System.Windows.Forms.MaskedTextBox();
            this.maxTileHeightTextBox = new System.Windows.Forms.MaskedTextBox();
            this.maxTileWidthLabel = new System.Windows.Forms.Label();
            this.maxTileHeightLabel = new System.Windows.Forms.Label();
            this.layerDrawTypeComboBox = new System.Windows.Forms.ComboBox();
            this.layerDrawTypeLabel = new System.Windows.Forms.Label();
            this.layerZDepthLabel = new System.Windows.Forms.Label();
            this.layerHeightLabel = new System.Windows.Forms.Label();
            this.editControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.levelSelectionBox = new System.Windows.Forms.ComboBox();
            this.dataTabControl = new System.Windows.Forms.TabControl();
            this.tileDataPage = new System.Windows.Forms.TabPage();
            this.layerDataPage = new System.Windows.Forms.TabPage();
            this.levelDataPage = new System.Windows.Forms.TabPage();
            this.exitPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.levelExitYTextBox = new System.Windows.Forms.MaskedTextBox();
            this.levelExitYPosition = new System.Windows.Forms.Label();
            this.levelExitXTextBox = new System.Windows.Forms.MaskedTextBox();
            this.levelExitXPosition = new System.Windows.Forms.Label();
            this.startPositionGroupBox = new System.Windows.Forms.GroupBox();
            this.levelStartYTextBox = new System.Windows.Forms.MaskedTextBox();
            this.levelStartYLabel = new System.Windows.Forms.Label();
            this.levelStartXTextBox = new System.Windows.Forms.MaskedTextBox();
            this.levelStartXLabel = new System.Windows.Forms.Label();
            this.levelNameTextBox = new System.Windows.Forms.TextBox();
            this.levelNameLabel = new System.Windows.Forms.Label();
            this.levelIDTextBox = new System.Windows.Forms.MaskedTextBox();
            this.levelIDLabel = new System.Windows.Forms.Label();
            this.levelApplyChangesButton = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.saveTimer = new System.Windows.Forms.Timer(this.components);
            this.gameDataPage = new System.Windows.Forms.TabPage();
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.gameDataApplyChangesButton = new System.Windows.Forms.Button();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveStripButton = new System.Windows.Forms.ToolStripButton();
            this.undoStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.buildStripButton = new System.Windows.Forms.ToolStripButton();
            this.ghostingStripButton = new System.Windows.Forms.ToolStripButton();
            this.boundsStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveLayerDownPictureBox = new System.Windows.Forms.PictureBox();
            this.moveLayerUpPictureBox = new System.Windows.Forms.PictureBox();
            this.newLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.removeLayerPictureBox = new System.Windows.Forms.PictureBox();
            this.removeLevelPictureBox = new System.Windows.Forms.PictureBox();
            this.newLevelPictureBox = new System.Windows.Forms.PictureBox();
            this.topMenu.SuspendLayout();
            this.devPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerZDepthTextBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.editControlsGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dataTabControl.SuspendLayout();
            this.tileDataPage.SuspendLayout();
            this.layerDataPage.SuspendLayout();
            this.levelDataPage.SuspendLayout();
            this.exitPositionGroupBox.SuspendLayout();
            this.startPositionGroupBox.SuspendLayout();
            this.gameDataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerDownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerUpPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLevelPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLevelPictureBox)).BeginInit();
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
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
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
            // glMapMain
            // 
            this.glMapMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glMapMain.BackColor = System.Drawing.Color.Black;
            this.glMapMain.Location = new System.Drawing.Point(1, 51);
            this.glMapMain.Name = "glMapMain";
            this.glMapMain.Size = new System.Drawing.Size(922, 605);
            this.glMapMain.TabIndex = 1;
            this.glMapMain.Visible = false;
            this.glMapMain.VSync = false;
            this.glMapMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownGL);
            this.glMapMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mousePanGL);
            this.glMapMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpGL);
            // 
            // updateButton
            // 
            this.updateButton.AccessibleDescription = "";
            this.updateButton.AccessibleName = "";
            this.updateButton.Location = new System.Drawing.Point(258, 7);
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
            this.button1.Location = new System.Drawing.Point(5, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Gfx";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(86, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load Map";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tilePicker
            // 
            this.tilePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilePicker.Location = new System.Drawing.Point(3, 9);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(328, 194);
            this.tilePicker.TabIndex = 5;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(6, 436);
            this.glMiniMapControl.Name = "glMiniMapControl";
            this.glMiniMapControl.Size = new System.Drawing.Size(180, 180);
            this.glMiniMapControl.TabIndex = 8;
            this.glMiniMapControl.Visible = false;
            this.glMiniMapControl.VSync = false;
            this.glMiniMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glMiniMapClick);
            this.glMiniMapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glMiniMapMouseMove);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(841, 626);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Toggle Dev";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Load Gfx->GL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(5, 36);
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
            this.devPanel.Location = new System.Drawing.Point(12, 496);
            this.devPanel.Name = "devPanel";
            this.devPanel.Size = new System.Drawing.Size(340, 154);
            this.devPanel.TabIndex = 10;
            this.devPanel.Visible = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(232, 94);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(101, 23);
            this.button9.TabIndex = 15;
            this.button9.Text = "Unserialize XML";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(125, 94);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Serialize to XML";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(5, 94);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(114, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "Save Map";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tileTypeLabel
            // 
            this.tileTypeLabel.AutoSize = true;
            this.tileTypeLabel.Location = new System.Drawing.Point(2, 129);
            this.tileTypeLabel.Name = "tileTypeLabel";
            this.tileTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.tileTypeLabel.TabIndex = 12;
            this.tileTypeLabel.Text = "Tile Types:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(5, 65);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(328, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Toggle XML Output";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // layerSelectionBox
            // 
            this.layerSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.layerSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerSelectionBox.Enabled = false;
            this.layerSelectionBox.FormattingEnabled = true;
            this.layerSelectionBox.Items.AddRange(new object[] {
            "Show All"});
            this.layerSelectionBox.Location = new System.Drawing.Point(6, 19);
            this.layerSelectionBox.Name = "layerSelectionBox";
            this.layerSelectionBox.Size = new System.Drawing.Size(124, 21);
            this.layerSelectionBox.TabIndex = 11;
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
            this.ghostingStripButton,
            this.boundsStripButton});
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tileTypeCombo
            // 
            this.tileTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileTypeCombo.FormattingEnabled = true;
            this.tileTypeCombo.Items.AddRange(new object[] {
            "Pickup",
            "Change",
            "Power Effect",
            "Mob Spawn",
            "Replace",
            "Exit",
            "Teleport"});
            this.tileTypeCombo.Location = new System.Drawing.Point(77, 4);
            this.tileTypeCombo.Name = "tileTypeCombo";
            this.tileTypeCombo.Size = new System.Drawing.Size(118, 21);
            this.tileTypeCombo.TabIndex = 11;
            this.tileTypeCombo.SelectedIndexChanged += new System.EventHandler(this.tileTypeCombo_SelectedIndexChanged);
            // 
            // tileDataApplyChangesButton
            // 
            this.tileDataApplyChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileDataApplyChangesButton.Location = new System.Drawing.Point(9, 167);
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
            this.typeLabel.Location = new System.Drawing.Point(8, 7);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 15;
            this.typeLabel.Text = "Type:";
            // 
            // dataTwoLabel
            // 
            this.dataTwoLabel.AutoSize = true;
            this.dataTwoLabel.Location = new System.Drawing.Point(170, 51);
            this.dataTwoLabel.Name = "dataTwoLabel";
            this.dataTwoLabel.Size = new System.Drawing.Size(37, 13);
            this.dataTwoLabel.TabIndex = 13;
            this.dataTwoLabel.Text = "Value:";
            // 
            // tileData2ValueTextBox
            // 
            this.tileData2ValueTextBox.AllowPromptAsInput = false;
            this.tileData2ValueTextBox.Location = new System.Drawing.Point(77, 28);
            this.tileData2ValueTextBox.Mask = "00000";
            this.tileData2ValueTextBox.Name = "tileData2ValueTextBox";
            this.tileData2ValueTextBox.PromptChar = ' ';
            this.tileData2ValueTextBox.Size = new System.Drawing.Size(240, 20);
            this.tileData2ValueTextBox.TabIndex = 25;
            this.tileData2ValueTextBox.ValidatingType = typeof(int);
            // 
            // dataTwoTextBox
            // 
            this.dataTwoTextBox.AllowPromptAsInput = false;
            this.dataTwoTextBox.Location = new System.Drawing.Point(173, 67);
            this.dataTwoTextBox.Mask = "00000";
            this.dataTwoTextBox.Name = "dataTwoTextBox";
            this.dataTwoTextBox.PromptChar = ' ';
            this.dataTwoTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataTwoTextBox.TabIndex = 25;
            this.dataTwoTextBox.ValidatingType = typeof(int);
            // 
            // dataOneTextBox
            // 
            this.dataOneTextBox.AllowPromptAsInput = false;
            this.dataOneTextBox.Location = new System.Drawing.Point(11, 67);
            this.dataOneTextBox.Mask = "00000";
            this.dataOneTextBox.Name = "dataOneTextBox";
            this.dataOneTextBox.PromptChar = ' ';
            this.dataOneTextBox.Size = new System.Drawing.Size(143, 20);
            this.dataOneTextBox.TabIndex = 25;
            this.dataOneTextBox.ValidatingType = typeof(int);
            // 
            // dataOneLabel
            // 
            this.dataOneLabel.AutoSize = true;
            this.dataOneLabel.Location = new System.Drawing.Point(8, 51);
            this.dataOneLabel.Name = "dataOneLabel";
            this.dataOneLabel.Size = new System.Drawing.Size(37, 13);
            this.dataOneLabel.TabIndex = 13;
            this.dataOneLabel.Text = "Value:";
            // 
            // tileData2ValueLabel
            // 
            this.tileData2ValueLabel.AutoSize = true;
            this.tileData2ValueLabel.Location = new System.Drawing.Point(8, 31);
            this.tileData2ValueLabel.Name = "tileData2ValueLabel";
            this.tileData2ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.tileData2ValueLabel.TabIndex = 13;
            this.tileData2ValueLabel.Text = "Value:";
            // 
            // tileData1Combo
            // 
            this.tileData1Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileData1Combo.FormattingEnabled = true;
            this.tileData1Combo.Location = new System.Drawing.Point(199, 4);
            this.tileData1Combo.Name = "tileData1Combo";
            this.tileData1Combo.Size = new System.Drawing.Size(118, 21);
            this.tileData1Combo.TabIndex = 11;
            this.tileData1Combo.SelectedIndexChanged += new System.EventHandler(this.tileData1Combo_SelectedIndexChanged);
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
            this.layerWidthLabel.Location = new System.Drawing.Point(177, 8);
            this.layerWidthLabel.Name = "layerWidthLabel";
            this.layerWidthLabel.Size = new System.Drawing.Size(67, 13);
            this.layerWidthLabel.TabIndex = 21;
            this.layerWidthLabel.Text = "Layer Width:";
            // 
            // layerNameTextBox
            // 
            this.layerNameTextBox.Location = new System.Drawing.Point(89, 47);
            this.layerNameTextBox.Name = "layerNameTextBox";
            this.layerNameTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerNameTextBox.TabIndex = 25;
            // 
            // layerHeightTextBox
            // 
            this.layerHeightTextBox.AllowPromptAsInput = false;
            this.layerHeightTextBox.Location = new System.Drawing.Point(244, 26);
            this.layerHeightTextBox.Mask = "000";
            this.layerHeightTextBox.Name = "layerHeightTextBox";
            this.layerHeightTextBox.PromptChar = ' ';
            this.layerHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerHeightTextBox.TabIndex = 25;
            this.layerHeightTextBox.ValidatingType = typeof(int);
            this.layerHeightTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.layerWidthHeightValidate);
            // 
            // layerOffsetYTextBox
            // 
            this.layerOffsetYTextBox.AllowPromptAsInput = false;
            this.layerOffsetYTextBox.Location = new System.Drawing.Point(89, 26);
            this.layerOffsetYTextBox.Mask = "000";
            this.layerOffsetYTextBox.Name = "layerOffsetYTextBox";
            this.layerOffsetYTextBox.PromptChar = ' ';
            this.layerOffsetYTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerOffsetYTextBox.TabIndex = 25;
            this.layerOffsetYTextBox.ValidatingType = typeof(int);
            // 
            // layerOffsetXTextBox
            // 
            this.layerOffsetXTextBox.AllowPromptAsInput = false;
            this.layerOffsetXTextBox.Location = new System.Drawing.Point(89, 5);
            this.layerOffsetXTextBox.Mask = "000";
            this.layerOffsetXTextBox.Name = "layerOffsetXTextBox";
            this.layerOffsetXTextBox.PromptChar = ' ';
            this.layerOffsetXTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerOffsetXTextBox.TabIndex = 25;
            this.layerOffsetXTextBox.ValidatingType = typeof(int);
            // 
            // layerWidthTextBox
            // 
            this.layerWidthTextBox.AllowPromptAsInput = false;
            this.layerWidthTextBox.Location = new System.Drawing.Point(244, 5);
            this.layerWidthTextBox.Mask = "000";
            this.layerWidthTextBox.Name = "layerWidthTextBox";
            this.layerWidthTextBox.PromptChar = ' ';
            this.layerWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerWidthTextBox.TabIndex = 25;
            this.layerWidthTextBox.ValidatingType = typeof(int);
            this.layerWidthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.layerWidthHeightValidate);
            // 
            // layerNameLabel
            // 
            this.layerNameLabel.AutoSize = true;
            this.layerNameLabel.Location = new System.Drawing.Point(47, 50);
            this.layerNameLabel.Name = "layerNameLabel";
            this.layerNameLabel.Size = new System.Drawing.Size(38, 13);
            this.layerNameLabel.TabIndex = 31;
            this.layerNameLabel.Text = "Name:";
            // 
            // layerZDepthTextBox
            // 
            this.layerZDepthTextBox.Location = new System.Drawing.Point(244, 48);
            this.layerZDepthTextBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.layerZDepthTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layerZDepthTextBox.Name = "layerZDepthTextBox";
            this.layerZDepthTextBox.Size = new System.Drawing.Size(70, 20);
            this.layerZDepthTextBox.TabIndex = 30;
            this.layerZDepthTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // layerOffsetYLabel
            // 
            this.layerOffsetYLabel.AutoSize = true;
            this.layerOffsetYLabel.Location = new System.Drawing.Point(8, 29);
            this.layerOffsetYLabel.Name = "layerOffsetYLabel";
            this.layerOffsetYLabel.Size = new System.Drawing.Size(77, 13);
            this.layerOffsetYLabel.TabIndex = 27;
            this.layerOffsetYLabel.Text = "Layer Offset Y:";
            // 
            // layerOffsetXLabel
            // 
            this.layerOffsetXLabel.AutoSize = true;
            this.layerOffsetXLabel.Location = new System.Drawing.Point(8, 8);
            this.layerOffsetXLabel.Name = "layerOffsetXLabel";
            this.layerOffsetXLabel.Size = new System.Drawing.Size(77, 13);
            this.layerOffsetXLabel.TabIndex = 26;
            this.layerOffsetXLabel.Text = "Layer Offset X:";
            // 
            // layerDataApplyChangesButton
            // 
            this.layerDataApplyChangesButton.Location = new System.Drawing.Point(9, 167);
            this.layerDataApplyChangesButton.Name = "layerDataApplyChangesButton";
            this.layerDataApplyChangesButton.Size = new System.Drawing.Size(306, 25);
            this.layerDataApplyChangesButton.TabIndex = 17;
            this.layerDataApplyChangesButton.Text = "Apply Changes";
            this.layerDataApplyChangesButton.UseVisualStyleBackColor = true;
            this.layerDataApplyChangesButton.Click += new System.EventHandler(this.layerDataApplyChangesButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxTileWidthTextBox);
            this.groupBox2.Controls.Add(this.maxTileHeightTextBox);
            this.groupBox2.Controls.Add(this.maxTileWidthLabel);
            this.groupBox2.Controls.Add(this.maxTileHeightLabel);
            this.groupBox2.Location = new System.Drawing.Point(8, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 44);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Max Tile Size";
            // 
            // maxTileWidthTextBox
            // 
            this.maxTileWidthTextBox.AllowPromptAsInput = false;
            this.maxTileWidthTextBox.Location = new System.Drawing.Point(81, 15);
            this.maxTileWidthTextBox.Mask = "0000";
            this.maxTileWidthTextBox.Name = "maxTileWidthTextBox";
            this.maxTileWidthTextBox.PromptChar = ' ';
            this.maxTileWidthTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileWidthTextBox.TabIndex = 25;
            this.maxTileWidthTextBox.ValidatingType = typeof(int);
            // 
            // maxTileHeightTextBox
            // 
            this.maxTileHeightTextBox.AllowPromptAsInput = false;
            this.maxTileHeightTextBox.Location = new System.Drawing.Point(199, 15);
            this.maxTileHeightTextBox.Mask = "0000";
            this.maxTileHeightTextBox.Name = "maxTileHeightTextBox";
            this.maxTileHeightTextBox.PromptChar = ' ';
            this.maxTileHeightTextBox.Size = new System.Drawing.Size(70, 20);
            this.maxTileHeightTextBox.TabIndex = 25;
            this.maxTileHeightTextBox.ValidatingType = typeof(int);
            // 
            // maxTileWidthLabel
            // 
            this.maxTileWidthLabel.AutoSize = true;
            this.maxTileWidthLabel.Location = new System.Drawing.Point(43, 18);
            this.maxTileWidthLabel.Name = "maxTileWidthLabel";
            this.maxTileWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.maxTileWidthLabel.TabIndex = 21;
            this.maxTileWidthLabel.Text = "Width:";
            // 
            // maxTileHeightLabel
            // 
            this.maxTileHeightLabel.AutoSize = true;
            this.maxTileHeightLabel.Location = new System.Drawing.Point(158, 18);
            this.maxTileHeightLabel.Name = "maxTileHeightLabel";
            this.maxTileHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.maxTileHeightLabel.TabIndex = 21;
            this.maxTileHeightLabel.Text = "Height:";
            // 
            // layerDrawTypeComboBox
            // 
            this.layerDrawTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layerDrawTypeComboBox.FormattingEnabled = true;
            this.layerDrawTypeComboBox.Items.AddRange(new object[] {
            "Empty",
            "Copy",
            "Transparent"});
            this.layerDrawTypeComboBox.Location = new System.Drawing.Point(133, 130);
            this.layerDrawTypeComboBox.Name = "layerDrawTypeComboBox";
            this.layerDrawTypeComboBox.Size = new System.Drawing.Size(115, 21);
            this.layerDrawTypeComboBox.TabIndex = 25;
            // 
            // layerDrawTypeLabel
            // 
            this.layerDrawTypeLabel.AutoSize = true;
            this.layerDrawTypeLabel.Location = new System.Drawing.Point(67, 133);
            this.layerDrawTypeLabel.Name = "layerDrawTypeLabel";
            this.layerDrawTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.layerDrawTypeLabel.TabIndex = 21;
            this.layerDrawTypeLabel.Text = "Draw Type:";
            // 
            // layerZDepthLabel
            // 
            this.layerZDepthLabel.AutoSize = true;
            this.layerZDepthLabel.Location = new System.Drawing.Point(195, 50);
            this.layerZDepthLabel.Name = "layerZDepthLabel";
            this.layerZDepthLabel.Size = new System.Drawing.Size(49, 13);
            this.layerZDepthLabel.TabIndex = 21;
            this.layerZDepthLabel.Text = "Z Depth:";
            // 
            // layerHeightLabel
            // 
            this.layerHeightLabel.AutoSize = true;
            this.layerHeightLabel.Location = new System.Drawing.Point(174, 29);
            this.layerHeightLabel.Name = "layerHeightLabel";
            this.layerHeightLabel.Size = new System.Drawing.Size(70, 13);
            this.layerHeightLabel.TabIndex = 21;
            this.layerHeightLabel.Text = "Layer Height:";
            // 
            // editControlsGroupBox
            // 
            this.editControlsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editControlsGroupBox.Controls.Add(this.groupBox3);
            this.editControlsGroupBox.Controls.Add(this.groupBox1);
            this.editControlsGroupBox.Controls.Add(this.dataTabControl);
            this.editControlsGroupBox.Controls.Add(this.glMiniMapControl);
            this.editControlsGroupBox.Controls.Add(this.tilePicker);
            this.editControlsGroupBox.Location = new System.Drawing.Point(926, 40);
            this.editControlsGroupBox.Name = "editControlsGroupBox";
            this.editControlsGroupBox.Size = new System.Drawing.Size(334, 619);
            this.editControlsGroupBox.TabIndex = 23;
            this.editControlsGroupBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.moveLayerDownPictureBox);
            this.groupBox3.Controls.Add(this.moveLayerUpPictureBox);
            this.groupBox3.Controls.Add(this.newLayerPictureBox);
            this.groupBox3.Controls.Add(this.removeLayerPictureBox);
            this.groupBox3.Controls.Add(this.layerSelectionBox);
            this.groupBox3.Location = new System.Drawing.Point(192, 534);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 76);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Layer";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.levelSelectionBox);
            this.groupBox1.Controls.Add(this.removeLevelPictureBox);
            this.groupBox1.Controls.Add(this.newLevelPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(192, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 76);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // levelSelectionBox
            // 
            this.levelSelectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.levelSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelSelectionBox.FormattingEnabled = true;
            this.levelSelectionBox.Items.AddRange(new object[] {
            "Show All"});
            this.levelSelectionBox.Location = new System.Drawing.Point(6, 19);
            this.levelSelectionBox.Name = "levelSelectionBox";
            this.levelSelectionBox.Size = new System.Drawing.Size(124, 21);
            this.levelSelectionBox.TabIndex = 11;
            this.levelSelectionBox.SelectedIndexChanged += new System.EventHandler(this.levelSelectionBox_SelectedIndexChanged);
            // 
            // dataTabControl
            // 
            this.dataTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTabControl.Controls.Add(this.tileDataPage);
            this.dataTabControl.Controls.Add(this.layerDataPage);
            this.dataTabControl.Controls.Add(this.levelDataPage);
            this.dataTabControl.Controls.Add(this.gameDataPage);
            this.dataTabControl.Location = new System.Drawing.Point(4, 205);
            this.dataTabControl.Name = "dataTabControl";
            this.dataTabControl.SelectedIndex = 0;
            this.dataTabControl.Size = new System.Drawing.Size(330, 225);
            this.dataTabControl.TabIndex = 25;
            // 
            // tileDataPage
            // 
            this.tileDataPage.Controls.Add(this.tileDataApplyChangesButton);
            this.tileDataPage.Controls.Add(this.typeLabel);
            this.tileDataPage.Controls.Add(this.tileTypeCombo);
            this.tileDataPage.Controls.Add(this.tileData2ValueLabel);
            this.tileDataPage.Controls.Add(this.dataOneTextBox);
            this.tileDataPage.Controls.Add(this.tileData2ValueTextBox);
            this.tileDataPage.Controls.Add(this.dataTwoLabel);
            this.tileDataPage.Controls.Add(this.dataTwoTextBox);
            this.tileDataPage.Controls.Add(this.dataOneLabel);
            this.tileDataPage.Controls.Add(this.tileData1Combo);
            this.tileDataPage.Location = new System.Drawing.Point(4, 22);
            this.tileDataPage.Name = "tileDataPage";
            this.tileDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.tileDataPage.Size = new System.Drawing.Size(322, 199);
            this.tileDataPage.TabIndex = 1;
            this.tileDataPage.Text = "Tile Data";
            this.tileDataPage.UseVisualStyleBackColor = true;
            // 
            // layerDataPage
            // 
            this.layerDataPage.Controls.Add(this.layerNameTextBox);
            this.layerDataPage.Controls.Add(this.layerOffsetXTextBox);
            this.layerDataPage.Controls.Add(this.layerZDepthLabel);
            this.layerDataPage.Controls.Add(this.layerDrawTypeLabel);
            this.layerDataPage.Controls.Add(this.layerOffsetXLabel);
            this.layerDataPage.Controls.Add(this.layerDrawTypeComboBox);
            this.layerDataPage.Controls.Add(this.layerOffsetYLabel);
            this.layerDataPage.Controls.Add(this.layerWidthTextBox);
            this.layerDataPage.Controls.Add(this.layerNameLabel);
            this.layerDataPage.Controls.Add(this.layerHeightTextBox);
            this.layerDataPage.Controls.Add(this.layerHeightLabel);
            this.layerDataPage.Controls.Add(this.groupBox2);
            this.layerDataPage.Controls.Add(this.layerDataApplyChangesButton);
            this.layerDataPage.Controls.Add(this.layerOffsetYTextBox);
            this.layerDataPage.Controls.Add(this.layerZDepthTextBox);
            this.layerDataPage.Controls.Add(this.layerWidthLabel);
            this.layerDataPage.Location = new System.Drawing.Point(4, 22);
            this.layerDataPage.Name = "layerDataPage";
            this.layerDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.layerDataPage.Size = new System.Drawing.Size(322, 199);
            this.layerDataPage.TabIndex = 0;
            this.layerDataPage.Text = "Layer Data";
            this.layerDataPage.UseVisualStyleBackColor = true;
            // 
            // levelDataPage
            // 
            this.levelDataPage.Controls.Add(this.exitPositionGroupBox);
            this.levelDataPage.Controls.Add(this.startPositionGroupBox);
            this.levelDataPage.Controls.Add(this.levelNameTextBox);
            this.levelDataPage.Controls.Add(this.levelNameLabel);
            this.levelDataPage.Controls.Add(this.levelIDTextBox);
            this.levelDataPage.Controls.Add(this.levelIDLabel);
            this.levelDataPage.Controls.Add(this.levelApplyChangesButton);
            this.levelDataPage.Location = new System.Drawing.Point(4, 22);
            this.levelDataPage.Name = "levelDataPage";
            this.levelDataPage.Size = new System.Drawing.Size(322, 199);
            this.levelDataPage.TabIndex = 2;
            this.levelDataPage.Text = "Level Data";
            this.levelDataPage.UseVisualStyleBackColor = true;
            // 
            // exitPositionGroupBox
            // 
            this.exitPositionGroupBox.Controls.Add(this.levelExitYTextBox);
            this.exitPositionGroupBox.Controls.Add(this.levelExitYPosition);
            this.exitPositionGroupBox.Controls.Add(this.levelExitXTextBox);
            this.exitPositionGroupBox.Controls.Add(this.levelExitXPosition);
            this.exitPositionGroupBox.Location = new System.Drawing.Point(173, 61);
            this.exitPositionGroupBox.Name = "exitPositionGroupBox";
            this.exitPositionGroupBox.Size = new System.Drawing.Size(121, 77);
            this.exitPositionGroupBox.TabIndex = 29;
            this.exitPositionGroupBox.TabStop = false;
            this.exitPositionGroupBox.Text = "Exit Position";
            // 
            // levelExitYTextBox
            // 
            this.levelExitYTextBox.AllowPromptAsInput = false;
            this.levelExitYTextBox.Location = new System.Drawing.Point(36, 48);
            this.levelExitYTextBox.Mask = "00000";
            this.levelExitYTextBox.Name = "levelExitYTextBox";
            this.levelExitYTextBox.PromptChar = ' ';
            this.levelExitYTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelExitYTextBox.TabIndex = 26;
            this.levelExitYTextBox.ValidatingType = typeof(int);
            // 
            // levelExitYPosition
            // 
            this.levelExitYPosition.AutoSize = true;
            this.levelExitYPosition.Location = new System.Drawing.Point(13, 51);
            this.levelExitYPosition.Name = "levelExitYPosition";
            this.levelExitYPosition.Size = new System.Drawing.Size(17, 13);
            this.levelExitYPosition.TabIndex = 19;
            this.levelExitYPosition.Text = "Y:";
            // 
            // levelExitXTextBox
            // 
            this.levelExitXTextBox.AllowPromptAsInput = false;
            this.levelExitXTextBox.Location = new System.Drawing.Point(36, 22);
            this.levelExitXTextBox.Mask = "00000";
            this.levelExitXTextBox.Name = "levelExitXTextBox";
            this.levelExitXTextBox.PromptChar = ' ';
            this.levelExitXTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelExitXTextBox.TabIndex = 26;
            this.levelExitXTextBox.ValidatingType = typeof(int);
            // 
            // levelExitXPosition
            // 
            this.levelExitXPosition.AutoSize = true;
            this.levelExitXPosition.Location = new System.Drawing.Point(13, 25);
            this.levelExitXPosition.Name = "levelExitXPosition";
            this.levelExitXPosition.Size = new System.Drawing.Size(17, 13);
            this.levelExitXPosition.TabIndex = 19;
            this.levelExitXPosition.Text = "X:";
            // 
            // startPositionGroupBox
            // 
            this.startPositionGroupBox.Controls.Add(this.levelStartYTextBox);
            this.startPositionGroupBox.Controls.Add(this.levelStartYLabel);
            this.startPositionGroupBox.Controls.Add(this.levelStartXTextBox);
            this.startPositionGroupBox.Controls.Add(this.levelStartXLabel);
            this.startPositionGroupBox.Location = new System.Drawing.Point(26, 61);
            this.startPositionGroupBox.Name = "startPositionGroupBox";
            this.startPositionGroupBox.Size = new System.Drawing.Size(121, 77);
            this.startPositionGroupBox.TabIndex = 28;
            this.startPositionGroupBox.TabStop = false;
            this.startPositionGroupBox.Text = "Start Position";
            // 
            // levelStartYTextBox
            // 
            this.levelStartYTextBox.AllowPromptAsInput = false;
            this.levelStartYTextBox.Location = new System.Drawing.Point(36, 48);
            this.levelStartYTextBox.Mask = "00000";
            this.levelStartYTextBox.Name = "levelStartYTextBox";
            this.levelStartYTextBox.PromptChar = ' ';
            this.levelStartYTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelStartYTextBox.TabIndex = 26;
            this.levelStartYTextBox.ValidatingType = typeof(int);
            // 
            // levelStartYLabel
            // 
            this.levelStartYLabel.AutoSize = true;
            this.levelStartYLabel.Location = new System.Drawing.Point(13, 51);
            this.levelStartYLabel.Name = "levelStartYLabel";
            this.levelStartYLabel.Size = new System.Drawing.Size(17, 13);
            this.levelStartYLabel.TabIndex = 19;
            this.levelStartYLabel.Text = "Y:";
            // 
            // levelStartXTextBox
            // 
            this.levelStartXTextBox.AllowPromptAsInput = false;
            this.levelStartXTextBox.Location = new System.Drawing.Point(36, 22);
            this.levelStartXTextBox.Mask = "00000";
            this.levelStartXTextBox.Name = "levelStartXTextBox";
            this.levelStartXTextBox.PromptChar = ' ';
            this.levelStartXTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelStartXTextBox.TabIndex = 26;
            this.levelStartXTextBox.ValidatingType = typeof(int);
            // 
            // levelStartXLabel
            // 
            this.levelStartXLabel.AutoSize = true;
            this.levelStartXLabel.Location = new System.Drawing.Point(13, 25);
            this.levelStartXLabel.Name = "levelStartXLabel";
            this.levelStartXLabel.Size = new System.Drawing.Size(17, 13);
            this.levelStartXLabel.TabIndex = 19;
            this.levelStartXLabel.Text = "X:";
            // 
            // levelNameTextBox
            // 
            this.levelNameTextBox.Location = new System.Drawing.Point(219, 28);
            this.levelNameTextBox.Name = "levelNameTextBox";
            this.levelNameTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelNameTextBox.TabIndex = 27;
            // 
            // levelNameLabel
            // 
            this.levelNameLabel.AutoSize = true;
            this.levelNameLabel.Location = new System.Drawing.Point(178, 31);
            this.levelNameLabel.Name = "levelNameLabel";
            this.levelNameLabel.Size = new System.Drawing.Size(38, 13);
            this.levelNameLabel.TabIndex = 19;
            this.levelNameLabel.Text = "Name:";
            // 
            // levelIDTextBox
            // 
            this.levelIDTextBox.AllowPromptAsInput = false;
            this.levelIDTextBox.Location = new System.Drawing.Point(67, 28);
            this.levelIDTextBox.Mask = "00000";
            this.levelIDTextBox.Name = "levelIDTextBox";
            this.levelIDTextBox.PromptChar = ' ';
            this.levelIDTextBox.Size = new System.Drawing.Size(70, 20);
            this.levelIDTextBox.TabIndex = 26;
            this.levelIDTextBox.ValidatingType = typeof(int);
            // 
            // levelIDLabel
            // 
            this.levelIDLabel.AutoSize = true;
            this.levelIDLabel.Location = new System.Drawing.Point(40, 30);
            this.levelIDLabel.Name = "levelIDLabel";
            this.levelIDLabel.Size = new System.Drawing.Size(21, 13);
            this.levelIDLabel.TabIndex = 19;
            this.levelIDLabel.Text = "ID:";
            // 
            // levelApplyChangesButton
            // 
            this.levelApplyChangesButton.Location = new System.Drawing.Point(9, 167);
            this.levelApplyChangesButton.Name = "levelApplyChangesButton";
            this.levelApplyChangesButton.Size = new System.Drawing.Size(306, 25);
            this.levelApplyChangesButton.TabIndex = 17;
            this.levelApplyChangesButton.Text = "Apply Changes";
            this.levelApplyChangesButton.UseVisualStyleBackColor = true;
            this.levelApplyChangesButton.Click += new System.EventHandler(this.levelApplyChangesButton_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(760, 626);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 24;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // saveTimer
            // 
            this.saveTimer.Interval = 60000;
            this.saveTimer.Tick += new System.EventHandler(this.saveTimer_Tick);
            // 
            // gameDataPage
            // 
            this.gameDataPage.Controls.Add(this.gameDataApplyChangesButton);
            this.gameDataPage.Controls.Add(this.gameNameTextBox);
            this.gameDataPage.Controls.Add(this.gameNameLabel);
            this.gameDataPage.Location = new System.Drawing.Point(4, 22);
            this.gameDataPage.Name = "gameDataPage";
            this.gameDataPage.Size = new System.Drawing.Size(322, 199);
            this.gameDataPage.TabIndex = 3;
            this.gameDataPage.Text = "Game Data";
            this.gameDataPage.UseVisualStyleBackColor = true;
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Location = new System.Drawing.Point(13, 14);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(69, 13);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "Game Name:";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Location = new System.Drawing.Point(88, 11);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.Size = new System.Drawing.Size(226, 20);
            this.gameNameTextBox.TabIndex = 1;
            // 
            // gameDataApplyChangesButton
            // 
            this.gameDataApplyChangesButton.Location = new System.Drawing.Point(9, 167);
            this.gameDataApplyChangesButton.Name = "gameDataApplyChangesButton";
            this.gameDataApplyChangesButton.Size = new System.Drawing.Size(306, 25);
            this.gameDataApplyChangesButton.TabIndex = 18;
            this.gameDataApplyChangesButton.Text = "Apply Changes";
            this.gameDataApplyChangesButton.UseVisualStyleBackColor = true;
            this.gameDataApplyChangesButton.Click += new System.EventHandler(this.gameDataApplyChangesButton_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
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
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Enabled = false;
            this.undoStripButton.Image = global::BlockEd.Properties.Resources.Undo_16x;
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(32, 22);
            this.undoStripButton.Text = "Undo (CTRL+Z)";
            this.undoStripButton.ButtonClick += new System.EventHandler(this.undoStripButton_ButtonClick);
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Enabled = false;
            this.redoStripButton.Image = global::BlockEd.Properties.Resources.Redo_16x;
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(32, 22);
            this.redoStripButton.Text = "toolStripSplitButton1";
            this.redoStripButton.ToolTipText = "Redo (CTRL + Y)";
            this.redoStripButton.ButtonClick += new System.EventHandler(this.redoStripButton_ButtonClick);
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
            // boundsStripButton
            // 
            this.boundsStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boundsStripButton.Image = ((System.Drawing.Image)(resources.GetObject("boundsStripButton.Image")));
            this.boundsStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boundsStripButton.Name = "boundsStripButton";
            this.boundsStripButton.Size = new System.Drawing.Size(23, 22);
            this.boundsStripButton.Text = "Toggle Bounds Display";
            this.boundsStripButton.Click += new System.EventHandler(this.boundsStripButton_Click);
            // 
            // moveLayerDownPictureBox
            // 
            this.moveLayerDownPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveLayerDownPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.MoveLayerDown;
            this.moveLayerDownPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveLayerDownPictureBox.Enabled = false;
            this.moveLayerDownPictureBox.Location = new System.Drawing.Point(70, 48);
            this.moveLayerDownPictureBox.Name = "moveLayerDownPictureBox";
            this.moveLayerDownPictureBox.Size = new System.Drawing.Size(23, 22);
            this.moveLayerDownPictureBox.TabIndex = 23;
            this.moveLayerDownPictureBox.TabStop = false;
            this.moveLayerDownPictureBox.Click += new System.EventHandler(this.moveLayerDownPictureBox_Click);
            // 
            // moveLayerUpPictureBox
            // 
            this.moveLayerUpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveLayerUpPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.MoveLayerUp;
            this.moveLayerUpPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveLayerUpPictureBox.Enabled = false;
            this.moveLayerUpPictureBox.Location = new System.Drawing.Point(99, 48);
            this.moveLayerUpPictureBox.Name = "moveLayerUpPictureBox";
            this.moveLayerUpPictureBox.Size = new System.Drawing.Size(23, 22);
            this.moveLayerUpPictureBox.TabIndex = 24;
            this.moveLayerUpPictureBox.TabStop = false;
            this.moveLayerUpPictureBox.Click += new System.EventHandler(this.moveLayerUpPictureBox_Click);
            // 
            // newLayerPictureBox
            // 
            this.newLayerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.AddLayer;
            this.newLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newLayerPictureBox.Enabled = false;
            this.newLayerPictureBox.Location = new System.Drawing.Point(12, 48);
            this.newLayerPictureBox.Name = "newLayerPictureBox";
            this.newLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.newLayerPictureBox.TabIndex = 18;
            this.newLayerPictureBox.TabStop = false;
            this.newLayerPictureBox.Click += new System.EventHandler(this.newLayerPictureBox_Click);
            // 
            // removeLayerPictureBox
            // 
            this.removeLayerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLayerPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.RemoveLayer;
            this.removeLayerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeLayerPictureBox.Enabled = false;
            this.removeLayerPictureBox.Location = new System.Drawing.Point(41, 48);
            this.removeLayerPictureBox.Name = "removeLayerPictureBox";
            this.removeLayerPictureBox.Size = new System.Drawing.Size(23, 22);
            this.removeLayerPictureBox.TabIndex = 19;
            this.removeLayerPictureBox.TabStop = false;
            this.removeLayerPictureBox.Click += new System.EventHandler(this.removeLayerPictureBox_Click);
            // 
            // removeLevelPictureBox
            // 
            this.removeLevelPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLevelPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.RemoveLayer;
            this.removeLevelPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeLevelPictureBox.Location = new System.Drawing.Point(70, 46);
            this.removeLevelPictureBox.Name = "removeLevelPictureBox";
            this.removeLevelPictureBox.Size = new System.Drawing.Size(23, 22);
            this.removeLevelPictureBox.TabIndex = 19;
            this.removeLevelPictureBox.TabStop = false;
            this.removeLevelPictureBox.Click += new System.EventHandler(this.removeLevelPictureBox_Click);
            // 
            // newLevelPictureBox
            // 
            this.newLevelPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newLevelPictureBox.BackgroundImage = global::BlockEd.Properties.Resources.AddLayer;
            this.newLevelPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newLevelPictureBox.Location = new System.Drawing.Point(41, 46);
            this.newLevelPictureBox.Name = "newLevelPictureBox";
            this.newLevelPictureBox.Size = new System.Drawing.Size(23, 22);
            this.newLevelPictureBox.TabIndex = 18;
            this.newLevelPictureBox.TabStop = false;
            this.newLevelPictureBox.Click += new System.EventHandler(this.newLevelPictureBox_Click);
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
            this.Controls.Add(this.topMenu);
            this.Controls.Add(this.glMapMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.topMenu;
            this.Name = "Form1";
            this.Text = "BlockEd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.editorClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.formResize);
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.devPanel.ResumeLayout(false);
            this.devPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerZDepthTextBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.editControlsGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.dataTabControl.ResumeLayout(false);
            this.tileDataPage.ResumeLayout(false);
            this.tileDataPage.PerformLayout();
            this.layerDataPage.ResumeLayout(false);
            this.layerDataPage.PerformLayout();
            this.levelDataPage.ResumeLayout(false);
            this.levelDataPage.PerformLayout();
            this.exitPositionGroupBox.ResumeLayout(false);
            this.exitPositionGroupBox.PerformLayout();
            this.startPositionGroupBox.ResumeLayout(false);
            this.startPositionGroupBox.PerformLayout();
            this.gameDataPage.ResumeLayout(false);
            this.gameDataPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerDownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveLayerUpPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeLevelPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLevelPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
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
        private System.Windows.Forms.Label tileTypeLabel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openStripButton;
        private System.Windows.Forms.ToolStripButton saveStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buildStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        internal System.Windows.Forms.ComboBox tileTypeCombo;
        internal System.Windows.Forms.ComboBox tileData1Combo;
        internal System.Windows.Forms.Label tileData2ValueLabel;
        internal System.Windows.Forms.Label dataOneLabel;
        internal System.Windows.Forms.Label dataTwoLabel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.PictureBox newLayerPictureBox;
        private System.Windows.Forms.PictureBox removeLayerPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel glLoadSpeedLabel;
        private System.Windows.Forms.Label layerWidthLabel;
        private System.Windows.Forms.Label layerHeightLabel;
        private System.Windows.Forms.Label maxTileHeightLabel;
        private System.Windows.Forms.Label maxTileWidthLabel;
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
        private System.Windows.Forms.Label layerOffsetYLabel;
        private System.Windows.Forms.Label layerOffsetXLabel;
        private System.Windows.Forms.Label layerNameLabel;
        private System.Windows.Forms.ToolStripSplitButton undoStripButton;
        private System.Windows.Forms.ToolStripSplitButton redoStripButton;
        internal System.Windows.Forms.ComboBox layerSelectionBox;
        internal System.Windows.Forms.ComboBox layerDrawTypeComboBox;
        internal System.Windows.Forms.NumericUpDown layerZDepthTextBox;
        internal System.Windows.Forms.MaskedTextBox layerHeightTextBox;
        internal System.Windows.Forms.MaskedTextBox layerOffsetYTextBox;
        internal System.Windows.Forms.MaskedTextBox layerOffsetXTextBox;
        internal System.Windows.Forms.MaskedTextBox layerWidthTextBox;
        internal System.Windows.Forms.MaskedTextBox maxTileWidthTextBox;
        internal System.Windows.Forms.MaskedTextBox maxTileHeightTextBox;
        internal System.Windows.Forms.MaskedTextBox layerNameTextBox;
        internal System.Windows.Forms.MaskedTextBox tileData2ValueTextBox;
        internal System.Windows.Forms.MaskedTextBox dataTwoTextBox;
        internal System.Windows.Forms.MaskedTextBox dataOneTextBox;
        private System.Windows.Forms.ToolStripButton boundsStripButton;
        internal System.Windows.Forms.ComboBox levelSelectionBox;
        private System.Windows.Forms.PictureBox removeLevelPictureBox;
        private System.Windows.Forms.PictureBox newLevelPictureBox;
        internal OpenTK.GLControl glMapMain;
        private System.Windows.Forms.TabControl dataTabControl;
        private System.Windows.Forms.TabPage layerDataPage;
        private System.Windows.Forms.TabPage tileDataPage;
        private System.Windows.Forms.Timer saveTimer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage levelDataPage;
        private System.Windows.Forms.Button levelApplyChangesButton;
        private System.Windows.Forms.GroupBox exitPositionGroupBox;
        internal System.Windows.Forms.MaskedTextBox levelExitYTextBox;
        private System.Windows.Forms.Label levelExitYPosition;
        internal System.Windows.Forms.MaskedTextBox levelExitXTextBox;
        private System.Windows.Forms.Label levelExitXPosition;
        private System.Windows.Forms.GroupBox startPositionGroupBox;
        internal System.Windows.Forms.MaskedTextBox levelStartYTextBox;
        private System.Windows.Forms.Label levelStartYLabel;
        internal System.Windows.Forms.MaskedTextBox levelStartXTextBox;
        private System.Windows.Forms.Label levelStartXLabel;
        private System.Windows.Forms.Label levelNameLabel;
        internal System.Windows.Forms.MaskedTextBox levelIDTextBox;
        private System.Windows.Forms.Label levelIDLabel;
        internal System.Windows.Forms.TextBox levelNameTextBox;
        private System.Windows.Forms.TabPage gameDataPage;
        private System.Windows.Forms.Button gameDataApplyChangesButton;
        private System.Windows.Forms.Label gameNameLabel;
        internal System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
    }
}

