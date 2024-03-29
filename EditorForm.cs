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

    public partial class EditorForm : Form
    {

        bool DEVMODE = false;
        bool changeMade = false;
        bool mapLoaded = false;
        string mapFilePath = null;
        string layerSelected = null;
        string levelSelected = null;
        MapTile currentTile = null;
        internal const int maxAmountTiles = 65536; //256 * 256 (1px per tile)
        internal const int maxZDepth = 10;
        string periodicFileName = "backup";

        internal Color alphaColorKey;

        internal List<GraphicTile> graphicTiles = new List<GraphicTile>();
        internal List<SpriteSheet> graphicFiles = new List<SpriteSheet>();
        internal List<MapTile> mapTiles = new List<MapTile>();
        GameData loadedMap = null;
        internal GLFuncs glFuncs;

        internal Stack<Command> undoStack = new Stack<Command>();
        internal Stack<Command> redoStack = new Stack<Command>();

        DataFuncs data;

        internal float tileOffsetX = 0;
        internal float tileOffsetY = 0;
        internal int maxLayerX = 0;
        internal int maxLayerY = 0;

        int lastMouseX;
        int lastMouseY;

        //Load speed sting get/set
        public string glLoadSpeed
        {
            get { return glLoadSpeedLabel.Text; }
            set { glLoadSpeedLabel.Text = value; }
        }

        //Toggle all the controls within a tabpage to be enabled or not
        internal void toggleTabPageEnable(TabPage page, bool areControlsEnabled)
        {
            foreach (Control control in page.Controls)
            {
                control.Enabled = areControlsEnabled;
            }
        }

        //Add a command to the undo stack
        internal void addCommand(Command cmd){
            changeMade = true;
            saveTimer.Enabled = true;

            undoStack.Push(cmd);
            undoStripButton.Enabled = true;
            if (redoStack.Count > 0)
            {
                redoStack.Clear();
                redoStripButton.Enabled = false;
            }
        }

        //Go down the undo stack x amount and push to the redo stack
        internal void performUndo(int undoAmount)
        {
            for (int i = 0; i < undoAmount; ++i)
            {
                Command currentCmd = undoStack.Pop();
                currentCmd.Undo();
                redoStack.Push(currentCmd);
            }
            if (undoStack.Count == 0)
            {
                undoStripButton.Enabled = false;
            }
            redoStripButton.Enabled = true;
            updateGLComponents();
            updateTileCount();
        }

        //Go down the redo stack x amount and push to the undo stack
        internal void performRedo(int redoAmount)
        {
            for (int i = 0; i < redoAmount; ++i)
            {
                Command currentCmd = redoStack.Pop();
                currentCmd.Do();
                undoStack.Push(currentCmd);
            }
            if (redoStack.Count == 0)
            {
                redoStripButton.Enabled = false;
            }
            undoStripButton.Enabled = true;
            updateGLComponents();
            updateTileCount();
        }

        //Override keys to allow specific shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                loadMap();
                return true;
            }
            else if(keyData == (Keys.Control | Keys.S)){
                saveXML();
                return true;
            }
            else if (keyData == Keys.F5)
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
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Z))
            {
                if (undoStripButton.Enabled)
                {
                    performUndo(1);
                }
            }
            else if (keyData == (Keys.Control | Keys.Y))
            {
                if (redoStripButton.Enabled)
                {
                    performRedo(1);
                }
            }
            else if(keyData == (Keys.Control | Keys.G)){
                if (ghostingStripButton.Checked)
                {
                    ghostingStripButton.Checked = false;
                    glFuncs.useLayerGhosting(true);
                }
                else
                {
                    ghostingStripButton.Checked = true;
                    glFuncs.useLayerGhosting(false);
                }
            }
            else if(keyData == (Keys.Control | Keys.B)){
                if (boundsStripButton.Checked)
                {
                    boundsStripButton.Checked = false;
                    glFuncs.useLayerBounds(true);
                }
                else
                {
                    boundsStripButton.Checked = true;
                    glFuncs.useLayerBounds(false);
                }
            }
            else if(keyData == (Keys.Control | Keys.N)){
                newMap();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public int getMaxZDepth()
        {
            return maxZDepth;
        }

        //Go through all the layers for the selected level and find the largest X and Y
        private void findBiggestLayer()
        {
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                if (level.getName() == levelSelectionBox.Text)
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
            }

            //Update the minimap to the new size
            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, maxLayerX, maxLayerY, 0, -1, 1);
            GL.Viewport(0, 0, glMiniMapControl.Width, glMiniMapControl.Height);
            GL.ClearColor(Color.Black);

        }

        //Set offset X with validation
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

            updateGLComponents();

        }

        //Set offset Y with validation
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

            updateGLComponents();

        }

        //Called when loading a map; it will setup all the GL controls, graphics, tiles e.t.c.
        private void loadMap(){

            glMiniMapControl.Visible = true;
            glMapMain.Visible = true;

            if(!loadXML()) return;                                  //Load the Map, Graphics and TileData XML
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

            updateGLComponents();

            //Add the list of levels to the level selection box
            updateLevelList();

            ////Add the list of layers to the layer selection box
            //updateLayerList();

            //Add the various loaded in graphics to the tile picker.
            data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);

            editControlsGroupBox.Enabled = true;
            updateTileCount();
            saveTimer.Enabled = true;

            gameNameTextBox.Text = loadedMap.getName();
            toggleTabPageEnable(gameDataPage, true);

            tileTypeLabel.Text = "Tile Types: " + graphicTiles.Count;
        }

        //Update the list of layers. Should be called if changes to layer order is made
        internal void updateLayerList()
        {
            layerSelectionBox.Items.Clear();
            layerSelectionBox.Items.Add("Show All");
            for (int curZDepth = 1; curZDepth <= maxZDepth; ++curZDepth)
            {
                foreach (GameLevel level in loadedMap.getLevelList())
                {
                    if (level.getName() == levelSelectionBox.Text)
                    {
                        MapData currentLayer = level.getLayerList().Find(delegate(MapData map)
                        {
                            return map.getZDepth() == curZDepth;
                        });

                        if (currentLayer != null)
                        {
                            layerSelectionBox.Items.Add(currentLayer.getMapName());
                        }
                    }
                }
            }
        }

        //Update the list of levels. Should be called if changes to a level is made
        internal void updateLevelList()
        {
            levelSelectionBox.Items.Clear();
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                levelSelectionBox.Items.Add(level.getName());
            }
        }

        //Saves calling updates all both controls
        internal void updateGLComponents()
        {
            glMapMain.Refresh();
            glMiniMapControl.Refresh();
            updateGL(glMapMain);
            updateGL(glMiniMapControl, false);
        }

        //Will add tiles to the tile tab control
        internal void updateTabControl()
        {
            data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);
        }

        //Main form init
        public EditorForm()
        {
            InitializeComponent();
            glFuncs = new GLFuncs(this);
            currentTile = new MapTile(-1, -1, -1);
            toggleTabPageEnable(tileDataPage, false);
            toggleTabPageEnable(layerDataPage, false);
            toggleTabPageEnable(levelDataPage, false);
            toggleTabPageEnable(gameDataPage, false);
            //tileDataGroupBox.Enabled = false;
            //layerDataGroupBox.Enabled = false;

            editControlsGroupBox.Enabled = false;
            //glMiniMapControl.Enabled = true;
            data = new DataFuncs(currentTile, _tileData, this);

            //From: http://stackoverflow.com/questions/8075040/visual-studio-style-undo-drop-down-button-custom-toolstripsplitbutton
            undoStripButton.DropDownOpening += (sender, e) =>
            {
                DrawDropDown(
                    undoStripButton,
                    "Undo",
                    UndoStackList,
                    performUndo
                    );
            };

            redoStripButton.DropDownOpening += (sender, e) =>
            {
                DrawDropDown(
                    redoStripButton,
                    "Redo",
                    RedoStackList,
                    performRedo
                    );
            };

            //End From

            //Setup tooltops for picture buttons
            ToolTip newLayerToolTop = new ToolTip();
            newLayerToolTop.SetToolTip(this.newLayerPictureBox, "Add a layer");
            ToolTip removeLayerToolTop = new ToolTip();
            removeLayerToolTop.SetToolTip(this.removeLayerPictureBox, "Remove layer");
            ToolTip moveLayerDownToolTip = new ToolTip();
            moveLayerDownToolTip.SetToolTip(this.moveLayerDownPictureBox, "Move layer down");
            ToolTip moveLayerUpToolTip = new ToolTip();
            moveLayerUpToolTip.SetToolTip(this.moveLayerUpPictureBox, "Move layer down");

            ToolTip newLevelToolTip = new ToolTip();
            newLevelToolTip.SetToolTip(this.newLevelPictureBox, "Add a new level");
            ToolTip removeLevelToolTip = new ToolTip();
            removeLevelToolTip.SetToolTip(this.removeLevelPictureBox, "Remove level");
        }

        //From: http://stackoverflow.com/questions/8075040/visual-studio-style-undo-drop-down-button-custom-toolstripsplitbutton
        private IEnumerable<string> UndoStackList
        {
            get { foreach (Command cmd in undoStack) { yield return cmd.getUndoName(); } }
        }
        private IEnumerable<string> RedoStackList
        {
            get { foreach (Command cmd in redoStack) { yield return cmd.getRedoName(); } }
        }
        //End from

        //Override dialog key and forward to the GL control if it's in focus
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

        //Provides some more updates for the GL controls
        protected override void OnPaint(PaintEventArgs e)
        {
            updateGLComponents();
            base.OnPaint(e);
        }

        //Updates the given glControl passing through offset or not (not for minimap)
        private void updateGL(GLControl glControl, bool doOffset = true)
        {
            if (mapLoaded)
            {
                if (doOffset)
                {
                    glFuncs.updateGL(glControl, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles, layerSelected, levelSelected);
                }
                else
                {
                    glFuncs.updateGL(glControl, 0, 0, loadedMap, graphicTiles, graphicFiles, layerSelected, levelSelected);
                }
            }
        }

        //Displays the current GL load time
        public void updateGlLoadSpeedLabel(string loadTime)
        {
            glLoadSpeedLabel.Text = "Rendered in: " + loadTime;
        }

        //Debug
        private void button4_Click(object sender, EventArgs e)
        {
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
        }
        //Debug
        private void button1_Click(object sender, EventArgs e)
        {
            updateGL(glMapMain);
        }
        //Debug
        private void button1_Click_1(object sender, EventArgs e)
        {
            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
        }
        //Debug
        private void button2_Click(object sender, EventArgs e)
        {
            loadXML();
        }
        //Debug
        private void button3_Click(object sender, EventArgs e)
        {
            devPanel.Visible = !devPanel.Visible;
        }

        //Pans the GL control depending on keyboard input
        private bool keyboardPanGLControl(KeyEventArgs e)
        {
            bool handled = false;

            if (glMapMain.Focused)
            {
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
                    updateGLComponents();
                }
            }

            return handled;
        }
        //Debug
        private void button5_Click(object sender, EventArgs e)
        {
            loadMap();
        }

        //Toggle dev mode
        private void button6_Click(object sender, EventArgs e)
        {
            DEVMODE = !DEVMODE;
        }

        //On open tool click
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMap();
        }

        //Updates the layer selection box to new values for the selected layer
        internal void updateLayerSelectionBox()
        {
            string layerSelectedName = (string)layerSelectionBox.SelectedItem;

            layerSelected = layerSelectedName;

            updateGLComponents();

            foreach (GameLevel level in loadedMap.getLevelList())
            {
                if (level.getName() == levelSelectionBox.Text)
                {
                    foreach (MapData layer in level.getLayerList())
                    {
                        if (layer.getMapName() == layerSelected)
                        {
                            //layerDataGroupBox.Enabled = true;
                            toggleTabPageEnable(layerDataPage, true);
                            layerOffsetXTextBox.Text = layer.getLayerOffsetX().ToString();
                            layerOffsetYTextBox.Text = layer.getLayerOffsetY().ToString();
                            layerWidthTextBox.Text = layer.getMapWidth().ToString();
                            layerHeightTextBox.Text = layer.getMapHeight().ToString();
                            layerNameTextBox.Text = layer.getMapName();
                            layerZDepthTextBox.Text = layer.getZDepth().ToString();
                            maxTileWidthTextBox.Text = layer.getMaxTileWidth().ToString();
                            maxTileHeightTextBox.Text = layer.getMaxTileHeight().ToString();
                            layerDrawTypeComboBox.SelectedIndex = layer.getDrawType() - 1; //Map to zero index
                            return;
                        }
                    }
                }
            }

            //Above did not return so unknown layer or Select All selected
            //layerDataGroupBox.Enabled = false;
            toggleTabPageEnable(layerDataPage, false);
            layerWidthTextBox.Text = "";
            layerHeightTextBox.Text = "";
            layerZDepthTextBox.Text = "";
            maxTileWidthTextBox.Text = "";
            maxTileHeightTextBox.Text = "";
            layerDrawTypeComboBox.Text = "";

            //Debug.WriteLine(layerSelectedName);
        }

        //Call the layer selection to be updated
        private void layerSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLayerSelectionBox();
        }

        //Debug
        private void button7_Click(object sender, EventArgs e)
        {
            data.saveMapXml(loadedMap, "map", "test");
        }

        //If mouse down in GL, add tiles, remove tiles or begin panning
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

            if (!String.IsNullOrEmpty(layerSelectionBox.Text) && layerSelectionBox.Text != "Show All")
            {
                if (e.Button == MouseButtons.Left && currentTile.getID() != -1)
                {
                    placeTile(e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    removeTile(e.X, e.Y);
                }
            }
            else
            {
                glMapMain.Focus();
            }

        }

        //Mouse up, do nothing really.
        private void mouseUpGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                //isMousePanning = false;
                //Debug.WriteLine("Mouse Middle Up");
                return;
            }
        }

        //On mouse move, continue placing tiles/removing or perform panning
        private void mousePanGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (loadedMap == null)
            {
                return;
            }

            if (e.X >= glMapMain.Left && e.X <= glMapMain.Right &&
                e.Y >= glMapMain.Top  && e.Y <= glMapMain.Bottom )
            {
                
            }

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
                updateGLComponents();
                //Debug.WriteLine("Mouse Middle is down, performing move.");
            }

            //Guard to stop removal/placement of tiles beyond the current view.
            if (e.X >= 0 && e.X <= glMapMain.Width &&
                e.Y >= 0  && e.Y <= glMapMain.Height )
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

        //Run the test client
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

        //Export the XML for the map
        private void saveStripButton_Click(object sender, EventArgs e)
        {
            saveXML();
        }

        //If the form is closing, check to see if any changes were made. If so, handle them accordingly
        private void editorClosing(object sender, FormClosingEventArgs e)
        {
            if (changeMade)
            {
                DialogResult shouldQuit = MessageBox.Show("Save changes to " + loadedMap.getName() + " before quitting?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (shouldQuit == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (shouldQuit == DialogResult.Yes)
                {
                    if (!saveXML())
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    //Delete the periodic save file.
                    string backupFileSavePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + periodicFileName + ".xml";
                    if (System.IO.File.Exists(backupFileSavePath))
                    {
                        System.IO.File.Delete(backupFileSavePath);
                    }
                    e.Cancel = false;
                }

            }

            if(isTestAppRunning){
                gameTestApplication.Kill();
            }

        }

        //Update tile count applying a colour changes as the max limit is being reached
        internal void updateTileCount()
        {
            int currentTileAmount = loadedMap.getNumTiles();
            float greenAmount = (1f - ((float)currentTileAmount / (float)maxAmountTiles)) * 100f;
            float redAmount = 100f - greenAmount;
            numTilesLoadedLabel.ForeColor = Color.FromArgb((int)redAmount, (int)greenAmount, 0);
            numTilesLoadedLabel.Text = "Number of Tiles: " + currentTileAmount.ToString();

            if (currentTileAmount == maxAmountTiles)
            {
                numTilesLoadedLabel.Font = new Font(numTilesLoadedLabel.Font.Name, numTilesLoadedLabel.Font.Size, FontStyle.Bold);
            }
            else
            {
                numTilesLoadedLabel.Font = new Font(numTilesLoadedLabel.Font.Name, numTilesLoadedLabel.Font.Size, FontStyle.Regular);
            }

        }

        //Performs a tile placement and mouse X/Y
        private void placeTile(int mouseX, int mouseY)
        {
            if (loadedMap.getNumTiles() >= maxAmountTiles)
            {
                Console.Beep(1000, 50);
                return;
            }
            foreach (GameLevel level in loadedMap.getLevelList())
            {

                if (level.getName() == levelSelectionBox.Text)
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

                                //If the tile placement is not within the map bounds, don't do anything.
                                if (tileX < 0 || tileY < 0 || tileX > map.getMapWidth() - 1 || tileY > map.getMapHeight() - 1)
                                {
                                    return;
                                }

                                currentTile.setPosition(tileX, tileY);
                                CPlaceTile placeTile = new CPlaceTile(currentTile, map, loadedMap);

                                foreach (MapDataTile checkTile in map.getTileList())
                                {
                                    if (checkTile._xPos == currentTile.getX() && checkTile._yPos == currentTile.getY())
                                    {
                                        if (checkTile._spriteID == currentTile.getID())
                                        {
                                            return;
                                        }
                                    }
                                }

                                addCommand(placeTile);
                                placeTile.Do();

                                updateGLComponents();
                                updateTileCount();

                                return;
                            }
                        }
                    }
                }
            }
        }

        //Removes a tile at the mouse X/T
        private void removeTile(int mouseX, int mouseY)
        {
            foreach (GameLevel level in loadedMap.getLevelList())
            {

                if (level.getName() == levelSelectionBox.Text)
                {
                    foreach (MapData map in level.getLayerList())
                    {
                        if (map.getMapName() == layerSelectionBox.Text)
                        {
                            int tileX = (int)((tileOffsetX * -1 + mouseX) / map.getMaxTileWidth());
                            int tileY = (int)((tileOffsetY * -1 + mouseY) / map.getMaxTileHeight());
                            currentTile.setPosition(tileX, tileY);

                            CRemoveTile removeTile = new CRemoveTile(currentTile, map, loadedMap);

                            foreach (MapDataTile checkTile in map.getTileList())
                            {
                                if (checkTile._xPos == currentTile.getX() && checkTile._yPos == currentTile.getY())
                                {
                                    addCommand(removeTile);
                                    removeTile.Do();

                                    updateGLComponents();
                                    updateTileCount();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        //Performs a save as by setting the mapFilePath to null
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapFilePath = null;
            saveXML();
        }

        //Debug
        private void button8_Click(object sender, EventArgs e)
        {
            string serializedString = Serialize(loadedMap);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(serializedString);

            string outDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "test.xml";
            xdoc.Save(outDir);
        }

        //Debug
        private void button9_Click(object sender, EventArgs e)
        {
            string inDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "test.xml";
            string text = System.IO.File.ReadAllText(inDir);

            loadedMap = (GameData)Deserialize(text, loadedMap.GetType());
        }

        //Move the given layer
        private void moveLayerZ(bool moveUp)
        {
            CMoveLayerZ moveLayer = new CMoveLayerZ(loadedMap, this, moveUp);
            addCommand(moveLayer);
            moveLayer.Do();
        }

        //Move the layer down
        private void moveLayerDownPictureBox_Click(object sender, EventArgs e)
        {
            if (layerSelectionBox.Text != "Show All")
            {
                moveLayerZ(false);
                updateGLComponents();
            }
        }

        //Move the layer up
        private void moveLayerUpPictureBox_Click(object sender, EventArgs e)
        {
            if (layerSelectionBox.Text != "Show All")
            {
                moveLayerZ(true);
                updateGLComponents();
            }
        }

        //Toggle the ghosting option
        private void ghostingStripButton_Click(object sender, EventArgs e)
        {
            if (ghostingStripButton.Checked)
            {
                ghostingStripButton.Checked = false;
                glFuncs.useLayerGhosting(true);
            }
            else
            {
                ghostingStripButton.Checked = true;
                glFuncs.useLayerGhosting(false);
            }
        }

        //Open/load a map
        private void openStripButton_Click(object sender, EventArgs e)
        {
            loadMap();
        }

        //Debug
        private void button10_Click(object sender, EventArgs e)
        {
            tileGraphicEditor tileEditor = new tileGraphicEditor(22, ref graphicFiles, ref graphicTiles, this);
            tileEditor.Show();
        }

        //Open the tile editor displaying the given tileID
        internal void displayTileEditor(int tileID)
        {
            tileGraphicEditor tileEditor = new tileGraphicEditor(tileID, ref graphicFiles, ref graphicTiles, this);
            tileEditor.Show();
        }

        //Update the tile data if the tile type combo is changed
        private void tileTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            //tileTypeCombo.Items.Clear();
            //tileData1Combo.Items.Clear();

            foreach (TileType tileData in _tileData.getList())
            {
                if (tileData._name == tileTypeCombo.Text)
                {
                    foreach (TileDataOne tileDataOne in tileData.getList())
                    {
                        if (tileDataOne._id == 0)
                        {
                            //tileTypeCombo.Enabled = false;
                            tileData1Combo.Enabled = false;
                            tileTypeLabel.Enabled = false;
                            tileData2ValueLabel.Enabled = false;
                            tileData2ValueTextBox.Enabled = false;

                            dataOneLabel.Enabled = true;
                            dataOneTextBox.Enabled = true;
                            dataTwoLabel.Enabled = true;
                            dataTwoTextBox.Enabled = true;

                            dataOneLabel.Text = tileDataOne._name + ":";
                            dataOneTextBox.Text = "0";

                            if (tileDataOne.getSecondData()._name == null)
                            {
                                dataTwoLabel.Enabled = false;
                                dataTwoTextBox.Enabled = false;
                            }
                            else
                            {
                                dataTwoLabel.Text = tileDataOne.getSecondData()._name + ":";
                                dataTwoTextBox.Text = "0";
                            }
                        }
                        else
                        {
                            dataOneLabel.Enabled = false;
                            dataOneTextBox.Enabled = false;
                            dataTwoLabel.Enabled = false;
                            dataTwoTextBox.Enabled = false;

                            tileData1Combo.Enabled = true;
                            tileTypeLabel.Enabled = true;
                            tileData2ValueLabel.Enabled = true;
                            tileData2ValueTextBox.Enabled = true;

                            if (tileDataOne._name == null)
                            {
                                tileData1Combo.Enabled = false;
                            }
                            else
                            {
                                tileData1Combo.Items.Add(tileDataOne._name);
                            }

                            if (tileDataOne._id == 1)
                            {
                                tileData1Combo.SelectedIndex = 0;
                                tileData2ValueLabel.Text = tileDataOne.getSecondData()._name + ":";
                                tileData2ValueTextBox.Text = "0";
                            }
                        }
                    }
                }
            }

        }

        //Updat ethe tile data as tile data one combo changed
        private void tileData1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TileType tileData in _tileData.getList())
            {
                if (tileData._name == tileTypeCombo.Text)
                {
                    foreach (TileDataOne tileDataOne in tileData.getList())
                    {
                        if (tileDataOne._name == tileData1Combo.Text)
                        {
                            tileData2ValueLabel.Text = tileDataOne.getSecondData()._name + ":";
                            tileData2ValueTextBox.Text = "0";
                        }
                    }
                }
            }
        }

        //Apply any tile modifications
        private void tileDataApplyChangesButton_Click(object sender, EventArgs e)
        {
            CApplyTileData applyChange = new CApplyTileData(currentTile, ref graphicTiles, ref _tileData, this);
            addCommand(applyChange);
            applyChange.Do();
        }

        //Apply any layer modifications
        private void layerDataApplyChangesButton_Click(object sender, EventArgs e)
        {
            CApplyLayerData applyLayerData = new CApplyLayerData(loadedMap, this);
            addCommand(applyLayerData);
            applyLayerData.Do();
            findBiggestLayer();
        }

        //Add a new layer
        private void newLayerPictureBox_Click(object sender, EventArgs e)
        {
            CAddLayer addLayer = new CAddLayer(loadedMap, this);
            addCommand(addLayer);
            addLayer.Do();
        }

        //Remove the selected layer
        private void removeLayerPictureBox_Click(object sender, EventArgs e)
        {
            CRemoveLayer removeLayer = new CRemoveLayer(loadedMap, this);
            addCommand(removeLayer);
            removeLayer.Do();
        }

        //From: http://stackoverflow.com/questions/8075040/visual-studio-style-undo-drop-down-button-custom-toolstripsplitbutton
        public delegate void UndoRedoCallback(int count);
        private void DrawDropDown(ToolStripSplitButton button, string action, IEnumerable<string> commands, UndoRedoCallback callback)
        {
            int width = 277;
            int listHeight = 181;
            int textHeight = 29;

            Panel panel = new Panel()
            {
                Size = new Size(width, textHeight + listHeight),
                Padding = new Padding(0),
                Margin = new Padding(0),
                BorderStyle = BorderStyle.FixedSingle,
            };
            Label label = new Label()
            {
                Size = new Size(width, textHeight),
                Location = new Point(1, listHeight - 2),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = String.Format("{0} 1 Action", action),
                Padding = new Padding(0),
                Margin = new Padding(0),
            };
            ListBox list = new ListBox()
            {
                Size = new Size(width, listHeight),
                Location = new Point(1, 1),
                SelectionMode = SelectionMode.MultiSimple,
                ScrollAlwaysVisible = true,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BorderStyle = BorderStyle.None,
                Font = new Font(panel.Font.FontFamily, 9),
            };
            foreach (var item in commands) { list.Items.Add(item); }
            if (list.Items.Count == 0) return;
            list.SelectedIndex = 0;

            ToolStripControlHost toolHost = new ToolStripControlHost(panel)
            {
                Size = panel.Size,
                Margin = new Padding(0),
            };
            ToolStripDropDown toolDrop = new ToolStripDropDown()
            {
                Padding = new Padding(0),
            };
            toolDrop.Items.Add(toolHost);

            panel.Controls.Add(list);
            panel.Controls.Add(label);
            toolDrop.Show(this, new Point(button.Bounds.Left + button.Owner.Left, button.Bounds.Bottom + button.Owner.Top));

            // *Note: These will be "up values" that will exist beyond the scope of this function
            int index = 1;
            int lastIndex = 1;

            list.Click += (sender, e) => { toolDrop.Close(); callback(index); };
            list.MouseMove += (sender, e) =>
            {
                index = Math.Max(1, list.IndexFromPoint(e.Location) + 1);
                if (lastIndex != index)
                {
                    int topIndex = Math.Max(0, Math.Min(list.TopIndex + e.Delta, list.Items.Count - 1));
                    list.BeginUpdate();
                    list.ClearSelected();
                    for (int i = 0; i < index; ++i) { list.SelectedIndex = i; }
                    label.Text = String.Format("{0} {1} Action{2}", action, index, index == 1 ? "" : "s");
                    lastIndex = index;
                    list.EndUpdate();
                    list.TopIndex = topIndex;
                }
            };
            list.Focus();
        }
        //End from

        //On form resize, update the GL control's viewport
        private void formResize(object sender, EventArgs e)
        {
            if (glMapMain.Visible)
            {
                //Setup the main viewport
                glMapMain.MakeCurrent();
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(0, glMapMain.Width, glMapMain.Height, 0, -1, 1);
                GL.Viewport(0, 0, glMapMain.Width, glMapMain.Height);
                GL.ClearColor(Color.Black);

                updateGLComponents();
            }
        }

        //Handle the toffle of the bounds area
        private void boundsStripButton_Click(object sender, EventArgs e)
        {
            if (boundsStripButton.Checked)
            {
                boundsStripButton.Checked = false;
                glFuncs.useLayerBounds(true);
            }
            else
            {
                boundsStripButton.Checked = true;
                glFuncs.useLayerBounds(false);
            }
        }

        //Enable other controls when the level selection is changed
        private void levelSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string levelSelectedName = (string)levelSelectionBox.SelectedItem;
            levelSelected = levelSelectedName;

            updateLevelSelectionBox();

            updateLayerList();
            layerSelectionBox.SelectedItem = "Show All";
            //currentLayerLabel.Enabled = true;
            layerSelectionBox.Enabled = true;
            newLayerPictureBox.Enabled = true;
            removeLayerPictureBox.Enabled = true;
            moveLayerDownPictureBox.Enabled = true;
            moveLayerUpPictureBox.Enabled = true;
            
        }

        //If the minimap is clicked, move the main window area
        private void glMiniMapClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            float xPercentage = (float)e.X / (float)glMiniMapControl.Width;
            float yPercentage = (float)e.Y / (float)glMiniMapControl.Height;

            float newOffsetX = ((float)maxLayerX * xPercentage) - (float)glMapMain.Width * 0.5f;
            float newOffsetY = ((float)maxLayerY * yPercentage) - (float)glMapMain.Height * 0.5f;

            setOffsetX(newOffsetX * -1);
            setOffsetY(newOffsetY * -1);

            updateGLComponents();

        }

        //If the mouse is moved on the minimap whilst left clicking, cause the large area to pan
        private void glMiniMapMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float xPercentage = (float)e.X / (float)glMiniMapControl.Width;
                float yPercentage = (float)e.Y / (float)glMiniMapControl.Height;

                float newOffsetX = ((float)maxLayerX * xPercentage) - (float)glMapMain.Width * 0.5f;
                float newOffsetY = ((float)maxLayerY * yPercentage) - (float)glMapMain.Height * 0.5f;

                setOffsetX(newOffsetX * -1);
                setOffsetY(newOffsetY * -1);

                updateGLComponents();
            }
        }

        //On save timer tick, serialize the loaded map out.
        private void saveTimer_Tick(object sender, EventArgs e)
        {
            string serializedString = Serialize(loadedMap);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(serializedString);

            string outDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + periodicFileName + ".xml";
            xdoc.Save(outDir);
        }

        //On form load, check to see if a backup exists and ask if it should be restored
        private void Form1_Load(object sender, EventArgs e)
        {
            string checkBackupSave = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + periodicFileName + ".xml";
            if (System.IO.File.Exists(checkBackupSave))
            {
                DialogResult result = MessageBox.Show("A backup file has been detected, this may have been due to a crash before a save could be made. Would you like to recover from this backup?",
                                                      "Backup Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string text = System.IO.File.ReadAllText(checkBackupSave);
                    loadedMap = new GameData();
                    loadedMap = (GameData)Deserialize(text, loadedMap.GetType());

                    glMiniMapControl.Visible = true;
                    glMapMain.Visible = true;

                    data.loadTileData(ref _tileData);
                    data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
                    glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
                    updateGL(glMapMain);
                    this.Text = "BlockEd - " + System.IO.Path.GetFileNameWithoutExtension(mapFilePath);

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

                    updateGLComponents();

                    //Add the list of levels to the level selection box
                    updateLevelList();

                    //Add the various loaded in graphics to the tile picker.
                    data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);

                    editControlsGroupBox.Enabled = true;
                    updateTileCount();
                    changeMade = true;
                    saveTimer.Enabled = true;

                }
                else
                {
                    System.IO.File.Delete(checkBackupSave);
                }
            }
        }

        //Update the level selection box data
        internal void updateLevelSelectionBox()
        {

            foreach (GameLevel level in loadedMap.getLevelList())
            {
                if (level.getName() == levelSelectionBox.Text)
                {
                    levelIDTextBox.Text = level.getID().ToString();
                    levelNameTextBox.Text = level.getName();
                    levelStartXTextBox.Text = level.getStartX().ToString();
                    levelStartYTextBox.Text = level.getStartY().ToString();
                    levelExitXTextBox.Text = level.getExitX().ToString();
                    levelExitYTextBox.Text = level.getExitY().ToString();
                    toggleTabPageEnable(levelDataPage, true);
                    return;
                }
            }

            //Above did not return so unknown level or Select All selected
            toggleTabPageEnable(levelDataPage, false);
            levelIDTextBox.Text = "";
            levelNameTextBox.Text = "";
            levelStartXTextBox.Text = "";
            levelStartYTextBox.Text = "";
            levelExitXTextBox.Text = "";
            levelExitYTextBox.Text = "";
        }

        //Add a new level
        private void newLevelPictureBox_Click(object sender, EventArgs e)
        {
            CAddLevel addLevel = new CAddLevel(loadedMap, this);
            addCommand(addLevel);
            addLevel.Do();
        }

        //Remove the selected level
        private void removeLevelPictureBox_Click(object sender, EventArgs e)
        {
            CRemoveLevel removeLevel = new CRemoveLevel(loadedMap, this);
            addCommand(removeLevel);
            removeLevel.Do();
        }

        //Apply any changes made to a level
        private void levelApplyChangesButton_Click(object sender, EventArgs e)
        {
            CApplyLevelData applyLevelData = new CApplyLevelData(loadedMap, this);
            addCommand(applyLevelData);
            applyLevelData.Do();
        }

        //On validation of the layer width/height, make sure they're within 1->256
        private void layerWidthHeightValidate(object sender, CancelEventArgs e)
        {
            MaskedTextBox caller = (MaskedTextBox)sender;
            if (Int32.Parse(caller.Text) > 256)
            {
                caller.Text = "256";
            }
            else if(Int32.Parse(caller.Text) < 1)
            {
                caller.Text = "1";
            }
        }

        //Apply any game data changes
        private void gameDataApplyChangesButton_Click(object sender, EventArgs e)
        {
            CApplyGameData applyGameData = new CApplyGameData(loadedMap, this);
            addCommand(applyGameData);
            applyGameData.Do();
        }

        //Perform a single undo
        private void undoStripButton_ButtonClick(object sender, EventArgs e)
        {
            performUndo(1);
        }

        //Perform a single redo
        private void redoStripButton_ButtonClick(object sender, EventArgs e)
        {
            performRedo(1);
        }

        //Perform a map export
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveXML();
        }

        //Create a new map
        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newMap();
        }

        //Create a new blank map, also create a default level and layer
        internal void newMap()
        {
            mapFilePath = null;
            loadedMap = new GameData();

            glMiniMapControl.Visible = true;
            glMapMain.Visible = true;

            data.loadTileData(ref _tileData);
            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            updateGL(glMapMain);
            this.Text = "BlockEd - New Map";

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

            updateGLComponents();

            //Add the list of levels to the level selection box
            updateLevelList();

            //Add the various loaded in graphics to the tile picker.
            data.addTilesToTabControl(graphicFiles, graphicTiles, tilePicker);

            editControlsGroupBox.Enabled = true;
            updateTileCount();
            changeMade = true;
            saveTimer.Enabled = true;

            CAddLevel addLevel = new CAddLevel(loadedMap, this);
            CAddLayer addLayer = new CAddLayer(loadedMap, this);
            addCommand(addLevel);
            addCommand(addLayer);
            addLevel.Do();
            addLayer.Do();

        }

        //Add a new map
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newMap();
        }


    }
}
