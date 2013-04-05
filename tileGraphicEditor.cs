using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockEd
{
    public partial class tileGraphicEditor : Form
    {

        Bitmap _tileImage;
        Bitmap _recoverTileImage;
        int _tileID;
        List<SpriteSheet> _spriteSheets;
        List<GraphicTile> _tiles;
        GraphicTile _curTileData;
        bool _changesMade = false;
        EditorForm _hostForm;

        internal tileGraphicEditor(int tileID, ref List<SpriteSheet> spriteSheets, ref List<GraphicTile> tiles, EditorForm myHost)
        {
            InitializeComponent();

            _tileID = tileID;
            _spriteSheets = spriteSheets;
            _tiles = tiles;
            _hostForm = myHost;

            foreach (SpriteSheet sheet in _spriteSheets)
            {
                foreach (GraphicTile tile in _tiles)
                {
                    if (tile.getFileID() != sheet.getFileId())
                    {
                        continue;
                    }

                    if (_tileID == tile.getTileID())
                    {
                        Bitmap spriteSheetImage = new Bitmap(sheet.getImagePath());
                        _curTileData = tile;
                        OpenTK.Vector2 tilePos = tile.getPosition();
                        Rectangle tileRect = new Rectangle((int)tilePos.X, (int)tilePos.Y, tile.getWidth(), tile.getHeight());
                        Bitmap cropped = null;
                        if (tileRect.X == 0 && tileRect.Y == 0 && tileRect.Width == spriteSheetImage.Width && tileRect.Height == spriteSheetImage.Height)
                        {
                            cropped = new Bitmap(spriteSheetImage);
                        }
                        else
                        {
                            cropped = new Bitmap(spriteSheetImage.Clone(tileRect, spriteSheetImage.PixelFormat));
                        }
                        spriteSheetImage.Dispose();
                        _tileImage = cropped;
                        _recoverTileImage = new Bitmap(cropped);
                    }
                }
            }

            giantTilePictureBox.Image = _tileImage;
        }

        private void colourPickClick(object sender, EventArgs e)
        {
            ColorDialog colourPicker = new ColorDialog();
            colourPicker.AllowFullOpen = true;
            colourPicker.ShowHelp = true;
            colourPicker.Color = this.colourPickPanel.BackColor;
            colourPicker.ShowDialog();
            this.colourPickPanel.BackColor = colourPicker.Color;
        }

        private void setPixelColour(int mouseX, int mouseY, Color newColor)
        {
            int transformX = (int)(((float)mouseX / (float)giantTilePictureBox.Width) * (float)_curTileData.getWidth());
            int transformY = (int)(((float)mouseY / (float)giantTilePictureBox.Height) * (float)_curTileData.getHeight());

            if (transformX < 0)
            {
                transformX = 0;
            } else if(transformX >= _curTileData.getWidth()){
                transformX = _curTileData.getWidth() - 1;
            }

            if (transformY < 0)
            {
                transformY = 0;
            }
            else if (transformY >= _curTileData.getWidth())
            {
                transformY = _curTileData.getHeight() - 1;
            }

            _tileImage.SetPixel(transformX, transformY, newColor);

            giantTilePictureBox.Image = _tileImage;
            _changesMade = true;
        }

        private void restorePixelColour(int mouseX, int mouseY)
        {
            int transformX = (int)(((float)mouseX / (float)giantTilePictureBox.Width) * (float)_curTileData.getWidth());
            int transformY = (int)(((float)mouseY / (float)giantTilePictureBox.Height) * (float)_curTileData.getHeight());

            if (transformX < 0)
            {
                transformX = 0;
            }
            else if (transformX >= _curTileData.getWidth())
            {
                transformX = _curTileData.getWidth() - 1;
            }

            if (transformY < 0)
            {
                transformY = 0;
            }
            else if (transformY >= _curTileData.getWidth())
            {
                transformY = _curTileData.getHeight() - 1;
            }


            Color restoreColour = _recoverTileImage.GetPixel(transformX, transformY);
            _tileImage.SetPixel(transformX, transformY, restoreColour);

            giantTilePictureBox.Image = _tileImage;
            _changesMade = true;
        }

        private void giantTileMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                setPixelColour(e.X, e.Y, colourPickPanel.BackColor);
            }
            else if (e.Button == MouseButtons.Right)
            {
                restorePixelColour(e.X, e.Y);
            }
        }

        private void giantTilePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                setPixelColour(e.X, e.Y, colourPickPanel.BackColor);
            }
            else if (e.Button == MouseButtons.Right)
            {
                restorePixelColour(e.X, e.Y);
            }
        }

        private void startAgainButton_Click(object sender, EventArgs e)
        {
            _tileImage.Dispose();
            _tileImage = new Bitmap(_recoverTileImage);

            giantTilePictureBox.Image = _tileImage;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (SpriteSheet sheet in _spriteSheets)
            {
                foreach (GraphicTile tile in _tiles)
                {
                    if (tile.getFileID() != sheet.getFileId())
                    {
                        continue;
                    }

                    if (_tileID == tile.getTileID())
                    {
                        Bitmap spriteSheetImage = new Bitmap(sheet.getImagePath());

                        Graphics g = Graphics.FromImage(spriteSheetImage);

                        // Draw the specified section of the source bitmap to the new one
                        g.DrawImage(_tileImage, tile.getPosition().X, tile.getPosition().Y, tile.getWidth(), tile.getHeight());

                        //spriteSheetImage.Save(sheet.getImagePath());
                        Bitmap newSpriteSheet = new Bitmap(spriteSheetImage);

                        //Clean up and dispose the bitmap to allow file to be overwritten
                        spriteSheetImage.Dispose();
                        g.Dispose();

                        string savePath = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/" + sheet.getImagePath());
                        newSpriteSheet.Save(savePath);
                        newSpriteSheet.Dispose();

                        _hostForm.glFuncs.loadSpriteSheets(_hostForm.graphicFiles, _hostForm.alphaColorKey);
                        _hostForm.updateGLComponents();
                        _hostForm.updateTabControl();
                        _changesMade = false;
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editorClosing(object sender, FormClosingEventArgs e)
        {
            if (_changesMade)
            {
                DialogResult shouldQuit = MessageBox.Show("You have unsaved changes. Are you sure you want to close the window?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (shouldQuit == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
