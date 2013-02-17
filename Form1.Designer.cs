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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.glMapMain = new OpenTK.GLControl();
            this.updateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tilePicker = new System.Windows.Forms.TabControl();
            this.terrainTab = new System.Windows.Forms.TabPage();
            this.glMiniMapControl = new OpenTK.GLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectsTab = new System.Windows.Forms.TabPage();
            this.mobTab = new System.Windows.Forms.TabPage();
            this.pickupTabs = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.glLoadSpeedLabel = new System.Windows.Forms.Label();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devPanel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.topMenu.SuspendLayout();
            this.tilePicker.SuspendLayout();
            this.terrainTab.SuspendLayout();
            this.devPanel.SuspendLayout();
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
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // glMapMain
            // 
            this.glMapMain.BackColor = System.Drawing.Color.Black;
            this.glMapMain.Location = new System.Drawing.Point(12, 56);
            this.glMapMain.Name = "glMapMain";
            this.glMapMain.Size = new System.Drawing.Size(922, 583);
            this.glMapMain.TabIndex = 1;
            this.glMapMain.VSync = false;
            this.glMapMain.Load += new System.EventHandler(this.glControl1_Load);
            this.glMapMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mousePanGL);
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
            this.tilePicker.Controls.Add(this.terrainTab);
            this.tilePicker.Controls.Add(this.objectsTab);
            this.tilePicker.Controls.Add(this.mobTab);
            this.tilePicker.Controls.Add(this.pickupTabs);
            this.tilePicker.Location = new System.Drawing.Point(945, 34);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(312, 605);
            this.tilePicker.TabIndex = 5;
            // 
            // terrainTab
            // 
            this.terrainTab.Controls.Add(this.glMiniMapControl);
            this.terrainTab.Controls.Add(this.panel1);
            this.terrainTab.Location = new System.Drawing.Point(4, 22);
            this.terrainTab.Name = "terrainTab";
            this.terrainTab.Padding = new System.Windows.Forms.Padding(3);
            this.terrainTab.Size = new System.Drawing.Size(304, 579);
            this.terrainTab.TabIndex = 0;
            this.terrainTab.Text = "Terrain";
            this.terrainTab.UseVisualStyleBackColor = true;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(34, 321);
            this.glMiniMapControl.Name = "glMiniMapControl";
            this.glMiniMapControl.Size = new System.Drawing.Size(234, 220);
            this.glMiniMapControl.TabIndex = 8;
            this.glMiniMapControl.VSync = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 50);
            this.panel1.TabIndex = 0;
            // 
            // objectsTab
            // 
            this.objectsTab.Location = new System.Drawing.Point(4, 22);
            this.objectsTab.Name = "objectsTab";
            this.objectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.objectsTab.Size = new System.Drawing.Size(304, 579);
            this.objectsTab.TabIndex = 1;
            this.objectsTab.Text = "Objects";
            this.objectsTab.UseVisualStyleBackColor = true;
            // 
            // mobTab
            // 
            this.mobTab.Location = new System.Drawing.Point(4, 22);
            this.mobTab.Name = "mobTab";
            this.mobTab.Padding = new System.Windows.Forms.Padding(3);
            this.mobTab.Size = new System.Drawing.Size(304, 579);
            this.mobTab.TabIndex = 2;
            this.mobTab.Text = "Mobs";
            this.mobTab.UseVisualStyleBackColor = true;
            // 
            // pickupTabs
            // 
            this.pickupTabs.Location = new System.Drawing.Point(4, 22);
            this.pickupTabs.Name = "pickupTabs";
            this.pickupTabs.Padding = new System.Windows.Forms.Padding(3);
            this.pickupTabs.Size = new System.Drawing.Size(304, 579);
            this.pickupTabs.TabIndex = 3;
            this.pickupTabs.Text = "Pickups";
            this.pickupTabs.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(858, 28);
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
            this.glLoadSpeedLabel.Location = new System.Drawing.Point(442, 644);
            this.glLoadSpeedLabel.Name = "glLoadSpeedLabel";
            this.glLoadSpeedLabel.Size = new System.Drawing.Size(91, 13);
            this.glLoadSpeedLabel.TabIndex = 9;
            this.glLoadSpeedLabel.Text = "Rendered in: N/A";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // devPanel
            // 
            this.devPanel.Controls.Add(this.button6);
            this.devPanel.Controls.Add(this.button1);
            this.devPanel.Controls.Add(this.button2);
            this.devPanel.Controls.Add(this.button5);
            this.devPanel.Controls.Add(this.button4);
            this.devPanel.Controls.Add(this.updateButton);
            this.devPanel.Location = new System.Drawing.Point(301, 225);
            this.devPanel.Name = "devPanel";
            this.devPanel.Size = new System.Drawing.Size(402, 250);
            this.devPanel.TabIndex = 10;
            this.devPanel.Visible = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.devPanel);
            this.Controls.Add(this.glLoadSpeedLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tilePicker);
            this.Controls.Add(this.glMapMain);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.tilePicker.ResumeLayout(false);
            this.terrainTab.ResumeLayout(false);
            this.devPanel.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage terrainTab;
        private System.Windows.Forms.TabPage objectsTab;
        private System.Windows.Forms.TabPage mobTab;
        private System.Windows.Forms.TabPage pickupTabs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private OpenTK.GLControl glMiniMapControl;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label glLoadSpeedLabel;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel devPanel;
        private System.Windows.Forms.Button button6;
    }
}

