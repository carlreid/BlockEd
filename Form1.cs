﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System.Drawing.Imaging;

using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Threading;

namespace BlockEd
{

    public partial class Form1 : Form
    {

        bool DEVMODE = false;
        bool changeMade = false;
        bool mapLoaded = false;
        string mapFilePath = null;
        string layerSelected = null;
        MapTile currentTile = null;

        Color alphaColorKey;

        List<GraphicTile> graphicTiles = new List<GraphicTile>();
        List<SpriteSheet> graphicFiles = new List<SpriteSheet>();
        List<MapTile> mapTiles = new List<MapTile>();
        GameData loadedMap = null;
        GLFuncs glFuncs;

        DataFuncs data;

        float tileOffsetX = 0;
        float tileOffsetY = 0;

        bool isMousePanning = false;
        int lastMouseX;
        int lastMouseY;

        private void setOffsetX(float value)
        {
            if (value > 0)
            {
                value = 0;
            }
            tileOffsetX = value;
        }

        private void setOffsetY(float value)
        {
            if (value > 0)
            {
                value = 0;
            }
            tileOffsetY = value;
        }

        public Form1()
        {
            InitializeComponent();
            glFuncs = new GLFuncs(this);
            currentTile = new MapTile(-1, -1, -1);
            data = new DataFuncs(currentTile, _tileData, this);
            //tileData = new ObjectData(this);
            tileDataGroupBox.Enabled = false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (!keyboardPanGLControl(new KeyEventArgs(keyData)))
            {
                OnKeyDown(new KeyEventArgs(keyData));
                return base.ProcessDialogKey(keyData);
            }
            else
            {
                return true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            updateGL(glMapMain);
            updateGL(glMiniMapControl);
            base.OnPaint(e);
        }

        private void updateGL(GLControl glControl)
        {
            if (mapLoaded)
            {
                glFuncs.updateGL(glControl, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles, layerSelected);
            }
        }

        private void glControl1_Load(object sender, EventArgs e)
        {

            int width = glMapMain.Width;
            int height = glMapMain.Height;

            GraphicsContext.ShareContexts = true;

            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, glMiniMapControl.Width, glMiniMapControl.Height);
            GL.ClearColor(Color.Black);

            glMapMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, width, height);
            GL.ClearColor(Color.Black);

            alphaColorKey = Color.Black;
           
        }
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.smiley, -250, -100);
        }

        public void updateGlLoadSpeedLabel(string loadTime)
        {
            glLoadSpeedLabel.Text = "Rendered in: " + loadTime;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateGL(glMapMain);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //loadedMap = data.loadMap(loadedMap);
            loadXML();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            devPanel.Visible = !devPanel.Visible;
        }

        private bool keyboardPanGLControl(KeyEventArgs e)
        {
            bool handled = false;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                setOffsetX(tileOffsetX + 10);
                handled = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                setOffsetX(tileOffsetX - 10);
                handled = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                setOffsetY(tileOffsetY + 10);
                handled = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                setOffsetY(tileOffsetY - 10);

                Debug.WriteLine(tileOffsetY + " - Which is " + ((tileOffsetY - glMapMain.Height) / 64) * -1 + " tiles.");

                if (((tileOffsetY - glMapMain.Height) / 64) * -1 > loadedMap.getMaxScrollY())
                {
                    tileOffsetY = ((loadedMap.getMaxScrollY() * 64) - glMapMain.Height) * -1;
                }
                handled = true;
            }
            if (handled)
            {
                updateGL(glMapMain);
            }

            return handled;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            loadXML();
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            updateGL(glMapMain);
            
            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            glLoadSpeedLabel.Text = "Loaded in: " + executionTime.ToString();

            //List<GameLevel> level = loadedMap.getLevelList();
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    layerSelectionBox.Items.Add(map.getMapName());
                }
            }

            data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);

            tileTypeLabel.Text = "Tile Types: " + graphicTiles.Count;

        }

        public string glLoadSpeed
        {
            get { return glLoadSpeedLabel.Text; }
            set { glLoadSpeedLabel.Text = value; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DEVMODE = !DEVMODE;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileBrowser = new OpenFileDialog();
            //fileBrowser.Multiselect = false;
            //fileBrowser.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            //fileBrowser.Filter = "XML Files (*.xml)|*.xml";
            //if (fileBrowser.ShowDialog(this) == DialogResult.OK)
            //{
            //    mapFilePath = fileBrowser.FileName;
            //}
            //else
            //{
            //    return;
            //}
            //loadedMap = data.loadMap(loadedMap, mapFilePath);
            //data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
            //glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            //updateGL(glMapMain);
            loadXML();
        }

        private void layerSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox layerSelect = (ComboBox)sender;
            string layerSelectedName = (string)layerSelect.SelectedItem;

            layerSelected = layerSelectedName;
            //Debug.WriteLine(layerSelectedName);

        }

        private void clickGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = data.ToXML(loadedMap);
            data.saveMapXml(loadedMap, "map", "test");
        }

        private void mouseDownGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (loadedMap == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Middle)
            {
                isMousePanning = true;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                Debug.WriteLine("Mouse Middle Down");
                return;
            }

            if (layerSelectionBox.Text == "" || layerSelectionBox.Text == null)
            {
                MessageBox.Show("Please select a layer to place the tile on.", "Select Layer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentTile.getID() == -1)
            {
                MessageBox.Show("You need to select a tile first.");
                return;
            }

            placeTile(e.X, e.Y);
        }

        private void mouseUpGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                isMousePanning = false;
                Debug.WriteLine("Mouse Middle Up");
                return;
            }
        }

        private void mousePanGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isMousePanning)
            {
                if (e.X == lastMouseX && e.Y == lastMouseY)
                {
                    return;
                }

                setOffsetX(tileOffsetX - (lastMouseX - e.X));
                setOffsetY(tileOffsetY - (lastMouseY - e.Y));
                lastMouseX = e.X;
                lastMouseY = e.Y;
                updateGL(glMapMain);
                Debug.WriteLine("Mouse Middle is down, performing move.");
            }
        }

        private void buildStripButton_Click(object sender, EventArgs e)
        {
            launchTest();
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            //if (loadedMap == null)
            //{
            //    MessageBox.Show("Please load a map first.", "No map open", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.Filter = "XML|*.xml";
            //saveDialog.InitialDirectory = Application.ExecutablePath;
            //saveDialog.CheckPathExists = true;
            //saveDialog.DefaultExt = "xml";
            //DialogResult saveResult = saveDialog.ShowDialog();

            //if(saveResult == DialogResult.OK){
            //    string savePath = saveDialog.FileName;
            //    string saveDirectory = System.IO.Path.GetDirectoryName(savePath);
            //    string saveName = System.IO.Path.GetFileNameWithoutExtension(savePath);
            //    data.saveMapXml(loadedMap, saveDirectory, saveName);
            //}

            saveXML();

        }

        private void editorClosing(object sender, FormClosingEventArgs e)
        {
            if (changeMade)
            {
                DialogResult shouldQuit = MessageBox.Show("You have unsaved changes. Are you sure you want to quit?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (shouldQuit == DialogResult.No)
                {
                    e.Cancel = true;
                }

            }
        }

        private void placeTile(int mouseX, int mouseY)
        {
            changeMade = true;
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == layerSelectionBox.Text)
                    {
                        foreach (GraphicTile graphic in graphicTiles)
                        {
                            if (graphic.getTileID() != currentTile.getID())
                            {
                                continue;
                            }

                            //Debug.WriteLine(e.X + " - " + e.Y);
                            //int tileX;
                            //int tileY;

                            //if (tileOffsetX < 0 || tileOffsetY < 0)
                            //{
                            //    tileX = (((int)tileOffsetX * -1) + e.X) / map.getMaxTileWidth();
                            //    tileY = (((int)tileOffsetY * -1) + e.Y) / map.getMaxTileHeight();
                            //}
                            //else
                            //{
                            //    tileX = (((int)Math.Floor(0.5 + tileOffsetX) * -1) + e.X) / map.getMaxTileWidth();
                            //    tileY = (((int)Math.Floor(0.5 + tileOffsetY) * -1) + e.Y) / map.getMaxTileHeight();
                            //}

                            //Debug.WriteLine(tileOffsetX + " -- " + Math.Abs(tileOffsetX));

                            int tileX = (int)((tileOffsetX * -1 + mouseX) / map.getMaxTileWidth());
                            int tileY = (int)((tileOffsetY * -1 + mouseY) / map.getMaxTileHeight());


                            currentTile.setPosition(tileX, tileY);
                            map.addTile(currentTile);
                            updateGL(glMapMain);
                            break;
                        }
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapFilePath = null;
            saveXML();
        }

    }
}
