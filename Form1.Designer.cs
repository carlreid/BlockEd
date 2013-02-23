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
            this.button6 = new System.Windows.Forms.Button();
            this.layerSelectionBox = new System.Windows.Forms.ComboBox();
            this.tileTypeLabel = new System.Windows.Forms.Label();
            this.topMenu.SuspendLayout();
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
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            this.glMapMain.Location = new System.Drawing.Point(12, 56);
            this.glMapMain.Name = "glMapMain";
            this.glMapMain.Size = new System.Drawing.Size(922, 583);
            this.glMapMain.TabIndex = 1;
            this.glMapMain.VSync = false;
            this.glMapMain.Load += new System.EventHandler(this.glControl1_Load);
            this.glMapMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickGL);
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
            this.tilePicker.Location = new System.Drawing.Point(945, 34);
            this.tilePicker.Name = "tilePicker";
            this.tilePicker.SelectedIndex = 0;
            this.tilePicker.Size = new System.Drawing.Size(312, 399);
            this.tilePicker.TabIndex = 5;
            // 
            // glMiniMapControl
            // 
            this.glMiniMapControl.BackColor = System.Drawing.Color.Black;
            this.glMiniMapControl.Location = new System.Drawing.Point(945, 439);
            this.glMiniMapControl.Name = "glMiniMapControl";
            this.glMiniMapControl.Size = new System.Drawing.Size(200, 200);
            this.glMiniMapControl.TabIndex = 8;
            this.glMiniMapControl.VSync = false;
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
            // devPanel
            // 
            this.devPanel.Controls.Add(this.tileTypeLabel);
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
            // layerSelectionBox
            // 
            this.layerSelectionBox.FormattingEnabled = true;
            this.layerSelectionBox.Location = new System.Drawing.Point(1149, 439);
            this.layerSelectionBox.Name = "layerSelectionBox";
            this.layerSelectionBox.Size = new System.Drawing.Size(106, 21);
            this.layerSelectionBox.TabIndex = 11;
            this.layerSelectionBox.SelectedIndexChanged += new System.EventHandler(this.layerSelectionBox_SelectedIndexChanged);
            // 
            // tileTypeLabel
            // 
            this.tileTypeLabel.AutoSize = true;
            this.tileTypeLabel.Location = new System.Drawing.Point(26, 127);
            this.tileTypeLabel.Name = "tileTypeLabel";
            this.tileTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.tileTypeLabel.TabIndex = 12;
            this.tileTypeLabel.Text = "Tile Types:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
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
            this.Text = "Form1";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.devPanel.ResumeLayout(false);
            this.devPanel.PerformLayout();
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
    }
}

