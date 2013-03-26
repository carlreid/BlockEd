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
        int maxLayerX = 0;
        int maxLayerY = 0;

        //bool isMousePanning = false;
        //bool isLeftDown = false;
        //bool isRightDown = false;
        int lastMouseX;
        int lastMouseY;

        private void findBiggestLayer()
        {
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (maxLayerX < map.getMapWidth() * map.getMaxTileWidth())
                    {
                        maxLayerX = map.getMapWidth() * map.getMaxTileWidth();
                    }
                    if (maxLayerY < map.getMapHeight() * map.getMaxTileHeight())
                    {
                        maxLayerY = map.getMapHeight() * map.getMaxTileHeight();
                    }
                }
            }

            //Update the minimap to the new size
            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, maxLayerX, maxLayerY, 0, -1, 1);
            GL.Viewport(0, 0, glMiniMapControl.Width, glMiniMapControl.Height);
            GL.ClearColor(Color.Black);

        }

        private void setOffsetX(float value)
        {

            if (maxLayerX == 0 || maxLayerY == 0)
            {
                findBiggestLayer();
            }

            if (value > 0)
            {
                value = 0;
            }
            tileOffsetX = value;

            if ((tileOffsetX - glMapMain.Width) * -1 > maxLayerX)
            {
                tileOffsetX = (maxLayerX - glMapMain.Width) * -1;
            }
        }

        private void setOffsetY(float value)
        {

            if (maxLayerX == 0 || maxLayerY == 0)
            {
                findBiggestLayer();
            }

            if (value > 0)
            {
                value = 0;
            }
            tileOffsetY = value;

            if ((tileOffsetY - glMapMain.Height) * -1 > maxLayerY)
            {
                tileOffsetY = (maxLayerY - glMapMain.Height) * -1;
            }
        }

        private void loadMap(){
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            loadXML();                                              //Load the Map, Graphics and TileData XML
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);  //Load the graphics into OpenGL
            findBiggestLayer();                                     //Setup variables to the max layer size

            //Setup the mini map viewport
            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, maxLayerX, maxLayerY, 0, -1, 1);
            GL.Viewport(0, 0, glMiniMapControl.Width, glMiniMapControl.Height);
            GL.ClearColor(Color.Black);

            //Setup the main viewport
            glMapMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glMapMain.Width, glMapMain.Height, 0, -1, 1);
            GL.Viewport(0, 0, glMapMain.Width, glMapMain.Height);
            GL.ClearColor(Color.Black);

            alphaColorKey = Color.Black;

            updateGL(glMapMain);
            updateGL(glMiniMapControl);

            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            glLoadSpeedLabel.Text = "Loaded in: " + executionTime.ToString();

            //Add the list of layers to the layer selection box
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    layerSelectionBox.Items.Add(map.getMapName());
                }
            }

            //Add the various loaded in graphics to the tile picker.
            data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);

            tileTypeLabel.Text = "Tile Types: " + graphicTiles.Count;
        }

        public Form1()
        {
            InitializeComponent();
            glFuncs = new GLFuncs(this);
            currentTile = new MapTile(-1, -1, -1);
            tileDataGroupBox.Enabled = false;
            data = new DataFuncs(currentTile, _tileData, this);

            ToolTip newLayerToolTop = new ToolTip();
            newLayerToolTop.SetToolTip(this.newLayerPictureBox, "Add a layer");

            ToolTip removeLayerToolTop = new ToolTip();
            removeLayerToolTop.SetToolTip(this.removeLayerPictureBox, "Remove a layer");
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
            updateGL(glMiniMapControl, false);
            base.OnPaint(e);
        }

        private void updateGL(GLControl glControl, bool doOffset = true)
        {
            if (mapLoaded)
            {
                if (doOffset)
                {
                    glFuncs.updateGL(glControl, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles, layerSelected);
                }
                else
                {
                    glFuncs.updateGL(glControl, 0, 0, loadedMap, graphicTiles, graphicFiles, layerSelected);
                }
            }
        }

        private void glControl1_Load(object sender, EventArgs e)
        {

            //int width = glMapMain.Width;
            //int height = glMapMain.Height;

            //GraphicsContext.ShareContexts = true;

            //glMiniMapControl.MakeCurrent();
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, width, height, 0, -1, 1);
            //GL.Viewport(0, 0, glMiniMapControl.Width, glMiniMapControl.Height);
            //GL.ClearColor(Color.Black);

            //glMapMain.MakeCurrent();
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, width, height, 0, -1, 1);
            //GL.Viewport(0, 0, width, height);
            //GL.ClearColor(Color.Black);

            //alphaColorKey = Color.Black;
           
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
            loadMap();
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
            loadMap();
        }

        private void layerSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox layerSelect = (ComboBox)sender;
            string layerSelectedName = (string)layerSelect.SelectedItem;

            layerSelected = layerSelectedName;
            updateGL(glMapMain);
            updateGL(glMiniMapControl, false);
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
                //isMousePanning = true;
                lastMouseX = e.X;
                lastMouseY = e.Y;
                //Debug.WriteLine("Mouse Middle Down");
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

            if (e.Button == MouseButtons.Left)
            {
                placeTile(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                removeTile(e.X, e.Y);
            }

        }

        private void mouseUpGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                //isMousePanning = false;
                //Debug.WriteLine("Mouse Middle Up");
                return;
            }
        }

        private void mousePanGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
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
                //Debug.WriteLine("Mouse Middle is down, performing move.");
            }

            //Guard to stop removal/placement of tiles beyond the current view.
            if (e.X > glMapMain.Left && e.X < glMapMain.Right &&
                e.Y > glMapMain.Top  && e.Y < glMapMain.Bottom )
            {
                if (e.Button == MouseButtons.Left)
                {
                    placeTile(e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    removeTile(e.X, e.Y);
                }
            }
        }

        private void buildStripButton_Click(object sender, EventArgs e)
        {
            if (!isTestAppRunning)
            {
                launchTest();
            }
            else
            {
                gameTestApplication.Kill();
                isTestAppRunning = false;
                buildStripButton.Image = BlockEd.Properties.Resources.StatusAnnotations_Play_32xLG_color;
            }
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

            if(isTestAppRunning){
                gameTestApplication.Kill();
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

                            int tileX = (int)((tileOffsetX * -1 + mouseX) / map.getMaxTileWidth());
                            int tileY = (int)((tileOffsetY * -1 + mouseY) / map.getMaxTileHeight());


                            currentTile.setPosition(tileX, tileY);
                            map.addTile(currentTile);
                            updateGL(glMapMain);
                            return;
                        }
                    }
                }
            }
        }

        private void removeTile(int mouseX, int mouseY)
        {
            changeMade = true;
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == layerSelectionBox.Text)
                    {
                        int tileX = (int)((tileOffsetX * -1 + mouseX) / map.getMaxTileWidth());
                        int tileY = (int)((tileOffsetY * -1 + mouseY) / map.getMaxTileHeight());

                        map.removeTile(tileX, tileY);
                        updateGL(glMapMain);
                        return;
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapFilePath = null;
            saveXML();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string serializedString = Serialize(loadedMap);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(serializedString);

            string outDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "test.xml";
            xdoc.Save(outDir);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string inDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "test.xml";
            string text = System.IO.File.ReadAllText(inDir);

            loadedMap = (GameData)Deserialize(text, loadedMap.GetType());
        }



    }
}
