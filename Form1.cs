using System;
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

namespace BlockEd
{

    public partial class Form1 : Form
    {

        bool DEVMODE = false;
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


        public Form1()
        {
            InitializeComponent();
            glFuncs = new GLFuncs(this);
            currentTile = new MapTile(-1, -1, -1);
            data = new DataFuncs(currentTile);
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

            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, width, height);
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
            loadedMap = data.loadMap(loadedMap);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            devPanel.Visible = !devPanel.Visible;
        }

        private void mousePanGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //tileOffsetX += 1;
        }

        private bool keyboardPanGLControl(KeyEventArgs e)
        {
            bool handled = false;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                tileOffsetX += 10;
                handled = true;
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                tileOffsetX -= 10;
                handled = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                tileOffsetY += 10;
                handled = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                tileOffsetY -= 10;
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

            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
            loadedMap = data.loadMap(loadedMap);
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
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Multiselect = false;
            fileBrowser.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            fileBrowser.Filter = "XML Files (*.xml)|*.xml";
            if (fileBrowser.ShowDialog(this) == DialogResult.OK)
            {
                mapFilePath = fileBrowser.FileName;
            }
            else
            {
                return;
            }
            loadedMap = data.loadMap(loadedMap, mapFilePath);
            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            updateGL(glMapMain);
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
            if (loadedMap == null)
            {
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

                            Debug.WriteLine(tileOffsetX + " -- " + Math.Abs(tileOffsetX));

                            int tileX = (int)((tileOffsetX * -1 + e.X) / map.getMaxTileWidth());
                            int tileY = (int)((tileOffsetY * -1 + e.Y) / map.getMaxTileHeight());

                            
                            currentTile.setPosition(tileX, tileY);
                            map.addTile(currentTile);
                            updateGL(glMapMain);
                            break;
                        }
                    }
                }
            }
        }

    }
}
