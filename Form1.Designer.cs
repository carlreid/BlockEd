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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.glLoadSpeedLabel = new System.Windows.Forms.Label();
            this.devPanel = new System.Windows.Forms.Panel();
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
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileTypeCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tileData1Combo = new System.Windows.Forms.ComboBox();
            this.tileData2Combo = new System.Windows.Forms.ComboBox();
            this.topMenu.SuspendLayout();
            this.devPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // glMapMain
            // 
            this.glMapMain.BackColor = System.Drawing.Color.Black;
            this.glMapMain.Location = new System.Drawing.Point(12, 57);
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
            this.tilePicker.Location = new System.Drawing.Point(945, 57);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(312, 399);
            this.tilePicker.TabIndex = 5;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(945, 462);
            this.glMiniMapControl.Name = "glMiniMapControl";
            this.glMiniMapControl.Size = new System.Drawing.Size(200, 200);
            this.glMiniMapControl.TabIndex = 8;
            this.glMiniMapControl.VSync = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1168, 639);
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
            // glLoadSpeedLabel
            // 
            this.glLoadSpeedLabel.AutoSize = true;
            this.glLoadSpeedLabel.Location = new System.Drawing.Point(949, 665);
            this.glLoadSpeedLabel.Name = "glLoadSpeedLabel";
            this.glLoadSpeedLabel.Size = new System.Drawing.Size(91, 13);
            this.glLoadSpeedLabel.TabIndex = 9;
            this.glLoadSpeedLabel.Text = "Rendered in: N/A";
            // 
            // devPanel
            // 
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
            this.layerSelectionBox.Location = new System.Drawing.Point(1149, 462);
            this.layerSelectionBox.Name = "layerSelectionBox";
            this.layerSelectionBox.Size = new System.Drawing.Size(106, 21);
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
            this.buildStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openStripButton
            // 
            this.openStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openStripButton.Image")));
            this.openStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openStripButton.Name = "openStripButton";
            this.openStripButton.Size = new System.Drawing.Size(23, 22);
            this.openStripButton.Text = "Open File (CTRL+O)";
            // 
            // saveStripButton
            // 
            this.saveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveStripButton.Image")));
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
            this.undoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoStripButton.Image")));
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoStripButton.Text = "Undo (CTRL+Z)";
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoStripButton.Image")));
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
            this.buildStripButton.Image = ((System.Drawing.Image)(resources.GetObject("buildStripButton.Image")));
            this.buildStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildStripButton.Name = "buildStripButton";
            this.buildStripButton.Size = new System.Drawing.Size(23, 22);
            this.buildStripButton.Text = "Test (F5)";
            this.buildStripButton.Click += new System.EventHandler(this.buildStripButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
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
            this.tileTypeCombo.Location = new System.Drawing.Point(4, 19);
            this.tileTypeCombo.Name = "tileTypeCombo";
            this.tileTypeCombo.Size = new System.Drawing.Size(96, 21);
            this.tileTypeCombo.TabIndex = 11;
            this.tileTypeCombo.SelectedIndexChanged += new System.EventHandler(this.layerSelectionBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tileData2Combo);
            this.groupBox1.Controls.Add(this.tileData1Combo);
            this.groupBox1.Controls.Add(this.tileTypeCombo);
            this.groupBox1.Location = new System.Drawing.Point(1149, 489);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 104);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Data";
            // 
            // tileData1Combo
            // 
            this.tileData1Combo.FormattingEnabled = true;
            this.tileData1Combo.Location = new System.Drawing.Point(4, 46);
            this.tileData1Combo.Name = "tileData1Combo";
            this.tileData1Combo.Size = new System.Drawing.Size(96, 21);
            this.tileData1Combo.TabIndex = 11;
            this.tileData1Combo.SelectedIndexChanged += new System.EventHandler(this.layerSelectionBox_SelectedIndexChanged);
            // 
            // tileData2Combo
            // 
            this.tileData2Combo.FormattingEnabled = true;
            this.tileData2Combo.Location = new System.Drawing.Point(4, 73);
            this.tileData2Combo.Name = "tileData2Combo";
            this.tileData2Combo.Size = new System.Drawing.Size(96, 21);
            this.tileData2Combo.TabIndex = 11;
            this.tileData2Combo.SelectedIndexChanged += new System.EventHandler(this.layerSelectionBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.layerSelectionBox);
            this.Controls.Add(this.glMiniMapControl);
            this.Controls.Add(this.devPanel);
            this.Controls.Add(this.glLoadSpeedLabel);
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
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Label glLoadSpeedLabel;
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
        private System.Windows.Forms.ComboBox tileTypeCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox tileData2Combo;
        private System.Windows.Forms.ComboBox tileData1Combo;
    }
}

