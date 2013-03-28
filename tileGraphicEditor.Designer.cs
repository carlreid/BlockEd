namespace BlockEd
{
    partial class tileGraphicEditor
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
            this.colourPickPanel = new System.Windows.Forms.Panel();
            this.giantTilePictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.startAgainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.giantTilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // colourPickPanel
            // 
            this.colourPickPanel.BackColor = System.Drawing.Color.Black;
            this.colourPickPanel.Location = new System.Drawing.Point(476, 2);
            this.colourPickPanel.Name = "colourPickPanel";
            this.colourPickPanel.Size = new System.Drawing.Size(32, 32);
            this.colourPickPanel.TabIndex = 1;
            this.colourPickPanel.Click += new System.EventHandler(this.colourPickClick);
            // 
            // giantTilePictureBox
            // 
            this.giantTilePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.giantTilePictureBox.Location = new System.Drawing.Point(0, 37);
            this.giantTilePictureBox.Name = "giantTilePictureBox";
            this.giantTilePictureBox.Size = new System.Drawing.Size(512, 512);
            this.giantTilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.giantTilePictureBox.TabIndex = 0;
            this.giantTilePictureBox.TabStop = false;
            this.giantTilePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.giantTileMouseClick);
            this.giantTilePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.giantTilePictureBox_MouseMove);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(4, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 32);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(145, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(135, 32);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // startAgainButton
            // 
            this.startAgainButton.Location = new System.Drawing.Point(286, 2);
            this.startAgainButton.Name = "startAgainButton";
            this.startAgainButton.Size = new System.Drawing.Size(135, 32);
            this.startAgainButton.TabIndex = 4;
            this.startAgainButton.Text = "Start Again";
            this.startAgainButton.UseVisualStyleBackColor = true;
            this.startAgainButton.Click += new System.EventHandler(this.startAgainButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pick\r\nColour";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tileGraphicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startAgainButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.colourPickPanel);
            this.Controls.Add(this.giantTilePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "tileGraphicEditor";
            this.Text = "Graphic Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.editorClosing);
            ((System.ComponentModel.ISupportInitialize)(this.giantTilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox giantTilePictureBox;
        private System.Windows.Forms.Panel colourPickPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button startAgainButton;
        private System.Windows.Forms.Label label1;
    }
}