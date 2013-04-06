using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BlockEd
{
    //Pretty much a class to hide away all the data loading/writing(eventually) functions
    class DataFuncs
    {
        bool DEVMODE = false;

        private PictureBox _lastModifiedTile = null;
        private Image _lastModifiedTileImage = null;
        private MapTile _selectedTile = null;
        private TileData _tileData = null;
        private EditorForm _mainForm = null;

        public DataFuncs(MapTile currentTile, TileData tileData, EditorForm mainForm)
        {
            _selectedTile = currentTile;
            _tileData = tileData;
            _mainForm = mainForm;
        }

        //Parses a hard coded xml file to load graphics into the given lists
        //Note/TODO: This would be possible to pass in a custom graphics xml file
        public void loadGraphics(List<GraphicTile> graphicTiles, List<SpriteSheet> graphicFiles, ref bool mapLoaded)
        {

            //If there's already tiles/files loaded, clear the list
            if (graphicTiles.Count > 0)
            {
                graphicTiles.Clear();
                Debug.WriteLine("Cleared graphicTiles");
            }
            if (graphicFiles.Count > 0)
            {
                graphicFiles.Clear();
                Debug.WriteLine("Cleared graphicFiles");
            }

            //Setup the XML settings
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            //Define a temp to store alpha in
            Color alphaColorKey;

            //Load in the hard coded XML path
            XmlReader graphicsReader = XmlReader.Create("data/Graphics.xml", settings);
            graphicsReader.Read();

            while (graphicsReader.Read())
            {
                if (graphicsReader.NodeType == XmlNodeType.Element)
                {
                    if (graphicsReader.Name == "transparentcolour")
                    {
                        int r = 0;
                        int g = 0;
                        int b = 0;

                        if (DEVMODE) Console.WriteLine("---- Element[transparentcolour] ----");

                        graphicsReader.MoveToAttribute("red");
                        if (DEVMODE) Console.WriteLine("Red: " + graphicsReader.ReadContentAsInt());
                        r = graphicsReader.ReadContentAsInt();

                        graphicsReader.MoveToAttribute("green");
                        if (DEVMODE) Console.WriteLine("Green: " + graphicsReader.ReadContentAsInt());
                        g = graphicsReader.ReadContentAsInt();

                        graphicsReader.MoveToAttribute("blue");
                        if (DEVMODE) Console.WriteLine("Blue: " + graphicsReader.ReadContentAsInt());
                        b = graphicsReader.ReadContentAsInt();

                        alphaColorKey = Color.FromArgb(0, r, g, b);

                    }

                    if (graphicsReader.Name == "FileList")
                    {
                        graphicsReader.ReadToDescendant("file");
                        while (graphicsReader.NodeType == XmlNodeType.Element && graphicsReader.Name == "file")
                        {
                            int fileID = 0;
                            string fileName = "";

                            graphicsReader.MoveToAttribute("id");
                            fileID = graphicsReader.ReadContentAsInt();

                            graphicsReader.MoveToElement();
                            fileName = graphicsReader.ReadElementContentAsString();

                            graphicFiles.Add(new SpriteSheet(fileID, fileName));

                        }
                    }

                    if (graphicsReader.NodeType == XmlNodeType.Element && graphicsReader.Name == "sprite")
                    {
                        string name = "", set = "";
                        int id, file, type = 0, data1 = 0, data2 = 0, width, height, xpos, ypos;
                        bool block = false;

                        if (DEVMODE) Console.WriteLine("-------------------------------------------");

                        graphicsReader.MoveToAttribute("id");
                        if (DEVMODE) Console.WriteLine("ID: " + graphicsReader.ReadContentAsInt().ToString());
                        id = graphicsReader.ReadContentAsInt();


                        graphicsReader.MoveToAttribute("file");
                        if (DEVMODE) Console.WriteLine("File: " + graphicsReader.ReadContentAsString().ToString());
                        file = graphicsReader.ReadContentAsInt();

                        if (graphicsReader.MoveToAttribute("set"))
                        {
                            if (DEVMODE) Console.WriteLine("Set: " + graphicsReader.ReadContentAsString().ToString());
                            set = graphicsReader.ReadContentAsString();
                        }

                        if (graphicsReader.MoveToAttribute("name"))
                        {
                            if (DEVMODE) Console.WriteLine("Name: " + graphicsReader.ReadContentAsString().ToString());
                            name = graphicsReader.ReadContentAsString();
                        }

                        if (graphicsReader.MoveToAttribute("type"))
                        {
                            if (DEVMODE) Console.WriteLine("Type: " + graphicsReader.ReadContentAsInt().ToString());
                            type = graphicsReader.ReadContentAsInt();
                        }

                        if (graphicsReader.MoveToAttribute("data1"))
                        {
                            if (!graphicsReader.Value.Equals(""))
                            {
                                if (DEVMODE) Console.WriteLine("Data1: " + graphicsReader.ReadContentAsInt().ToString());

                                data1 = graphicsReader.ReadContentAsInt();
                            }
                        }


                        if (graphicsReader.MoveToAttribute("data2"))
                        {
                            if (!graphicsReader.Value.Equals(""))
                            {
                                if (DEVMODE) Console.WriteLine("Data2: " + graphicsReader.ReadContentAsInt().ToString());

                                data2 = graphicsReader.ReadContentAsInt();
                            }
                        }


                        if (graphicsReader.MoveToAttribute("block"))
                        {
                            if (DEVMODE) Console.WriteLine("Block: " + graphicsReader.ReadContentAsBoolean().ToString());
                            block = graphicsReader.ReadContentAsBoolean();
                        }

                        graphicsReader.MoveToAttribute("x");
                        if (DEVMODE) Console.WriteLine("X: " + graphicsReader.ReadContentAsInt().ToString());
                        xpos = graphicsReader.ReadContentAsInt();

                        graphicsReader.MoveToAttribute("y");
                        if (DEVMODE) Console.WriteLine("Y: " + graphicsReader.ReadContentAsInt().ToString());
                        ypos = graphicsReader.ReadContentAsInt();

                        graphicsReader.MoveToAttribute("w");
                        if (DEVMODE) Console.WriteLine("W: " + graphicsReader.ReadContentAsInt().ToString());
                        width = graphicsReader.ReadContentAsInt();

                        graphicsReader.MoveToAttribute("h");
                        if (DEVMODE) Console.WriteLine("H: " + graphicsReader.ReadContentAsInt().ToString());
                        height = graphicsReader.ReadContentAsInt();

                        graphicTiles.Add(new GraphicTile(id, file, name, xpos, ypos, width, height, set, type, data1, data2, block));

                    }
                }
            }
            mapLoaded = true;
        }

        //Load the map from the given file path
        public GameData loadMap(GameData loadedMap, string mapFilePath)
        {
            //Setup the XML reader settings
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader mapReader = XmlReader.Create(mapFilePath, settings);

            if (mapReader == null)
            {
                Debug.WriteLine("Failed to load map");
            }
            mapReader.Read();

            while (mapReader.Read())
            {
                #region GameData

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "Game")
                {
                    if (mapReader.MoveToAttribute("name"))
                    {
                        string mapName = mapReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Map Name: " + mapName);

                        loadedMap = new GameData();
                        loadedMap.setName(mapName);
                    }
                }

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "scroll_area")
                {
                    int maxMapX = 0;
                    int maxMapY = 0;
                    if (mapReader.MoveToAttribute("TripWndX"))
                    {
                        maxMapX = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Max X: " + maxMapX);
                    }

                    if (mapReader.MoveToAttribute("TripWndY"))
                    {
                        maxMapY = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Max Y: " + maxMapY);
                    }
                    loadedMap.setMaxScroll(maxMapX, maxMapY);
                }
                #endregion

                #region GameLevel

                int levelID = 0;
                string levelName = null;
                int levelStartX = 0;
                int levelStartY = 0;

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "Level")
                {
                    if (mapReader.MoveToAttribute("id"))
                    {
                        levelID = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Level ID: " + levelID.ToString());
                    }

                    if (mapReader.MoveToAttribute("name"))
                    {
                        levelName = mapReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Level Name: " + levelName);
                    }

                    mapReader.ReadToFollowing("startposition");
                    if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "startposition")
                    {
                        if (mapReader.MoveToAttribute("x"))
                        {
                            levelStartX = mapReader.ReadContentAsInt();
                            if (DEVMODE) Console.WriteLine("Level Start X: " + levelStartX.ToString());
                        }
                        if (mapReader.MoveToAttribute("y"))
                        {
                            levelStartY = mapReader.ReadContentAsInt();
                            if (DEVMODE) Console.WriteLine("Level Start Y: " + levelStartY.ToString());
                        }
                    }
                    loadedMap.addLevel(levelID, levelStartX, levelStartY, levelName);

                    if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "startposition")
                    {
                        int exitX = 0;
                        int exitY = 0;

                        if (mapReader.MoveToAttribute("x"))
                        {
                            exitX = mapReader.ReadContentAsInt();
                            if (DEVMODE) Console.WriteLine("Level Exit X: " + exitX.ToString());
                        }
                        if (mapReader.MoveToAttribute("y"))
                        {
                            exitY = mapReader.ReadContentAsInt();
                            if (DEVMODE) Console.WriteLine("Level Exit Y: " + exitY.ToString());
                        }

                        loadedMap.getLastLoadedLevel().setExit(exitX, exitY);
                    }
                    
                }





                #endregion

                #region MapData
                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "map")
                {

                    string layerName = null;
                    int zDepth = 0;
                    int width = 0;
                    int height = 0;
                    int maxTileWidth = 32;
                    int maxTileHeight = 32;
                    int drawType = 0;

                    if (mapReader.MoveToAttribute("name"))
                    {
                        layerName = mapReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Layer Name: " + layerName);
                    }

                    if (mapReader.MoveToAttribute("z_depth"))
                    {
                        zDepth = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Z-Depth: " + zDepth.ToString());
                    }

                    if (mapReader.MoveToAttribute("width"))
                    {
                        width = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Layer Width: " + width.ToString());
                    }

                    if (mapReader.MoveToAttribute("height"))
                    {
                        height = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Layer Width: " + height.ToString());
                    }

                    if (mapReader.MoveToAttribute("xsz"))
                    {
                        maxTileWidth = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Max Tile Width: " + maxTileWidth.ToString());
                    }

                    if (mapReader.MoveToAttribute("ysz"))
                    {
                        maxTileHeight = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Max Tile Height: " + maxTileHeight.ToString());
                    }

                    if (mapReader.MoveToAttribute("drawtype"))
                    {
                        drawType = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Draw Type: " + drawType.ToString());
                    }

                    loadedMap.getLastLoadedLevel().addLayer(width, height, drawType, zDepth, layerName, maxTileWidth, maxTileHeight);

                }

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "layer_offset")
                {

                    int xOffset = 0;
                    int yOffset = 0;

                    if (mapReader.MoveToAttribute("x"))
                    {
                        xOffset = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Layer X Offset: " + xOffset.ToString());
                    }

                    if (mapReader.MoveToAttribute("y"))
                    {
                        yOffset = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Layer Y Offset: " + yOffset.ToString());
                    }

                    loadedMap.getLastLoadedLevel().getLastAddedLayer().setLayerOffset(xOffset, yOffset);

                }

                #region MapDataTile
                while (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "tile")
                {

                    int spriteID = 0;
                    int tileX = 0;
                    int tileY = 0;

                    if (mapReader.MoveToAttribute("sp"))
                    {
                        spriteID = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Sprite ID: " + spriteID.ToString());
                    }
                    if (mapReader.MoveToAttribute("x"))
                    {
                        tileX = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Sprite X: " + tileX.ToString());
                    }
                    if (mapReader.MoveToAttribute("y"))
                    {
                        tileY = mapReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Sprite Y: " + tileY.ToString());
                    }

                    loadedMap.getLastLoadedLevel().getLastAddedLayer().addTile(spriteID, tileX, tileY);
                    loadedMap.incrementNumTiles();

                }
                #endregion

                #endregion

            }
            mapReader.Close();
            return loadedMap;
        }

        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Debug.WriteLine("Validation Error: {0}", e.Message);
            MessageBox.Show("Error validating XML: " + e.Message + ". The map will still try to load.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Creates an XML document whilst checking against a DTD and will save to the specified location
        public void saveMapXml(GameData mapData, string saveLocation, string fileName)
        {
            XmlDocument document = new XmlDocument();
            XmlDeclaration docDecleration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            document.AppendChild(docDecleration);

            //<!DOCTYPE Game SYSTEM "MapDTD.xml">
            File.Copy("map/MapDTD.dtd", "MapDTD.dtd", true);
            XmlDocumentType doctype = document.CreateDocumentType("Game", null, "MapDTD.dtd", null);
            document.AppendChild(doctype);
            File.Delete("MapDTD.dtd");

            XmlElement root = document.CreateElement("Game");
            root.SetAttribute("name", mapData.getName());
            document.AppendChild(root);

            //GameData and scroll_area elements
            XmlElement gameData = document.CreateElement("GameData");
            XmlElement scroll_area = document.CreateElement("scroll_area");
            scroll_area.SetAttribute("TripWndX", mapData.getMaxScrollX().ToString());
            scroll_area.SetAttribute("TripWndY", mapData.getMaxScrollY().ToString());
            gameData.AppendChild(scroll_area);
            root.AppendChild(gameData);

            foreach (GameLevel level in mapData.getLevelList())
            {
                XmlElement levelElement = document.CreateElement("Level");
                levelElement.SetAttribute("id", level.getID().ToString());
                levelElement.SetAttribute("name", level.getName());

                XmlElement startposition = document.CreateElement("startposition");
                startposition.SetAttribute("x", level.getStartX().ToString());
                startposition.SetAttribute("y", level.getStartY().ToString());
                levelElement.AppendChild(startposition);

                if (level.hasExitBeenSet())
                {
                    XmlElement exitposition = document.CreateElement("exitposition");
                    exitposition.SetAttribute("x", level.getExitX().ToString());
                    exitposition.SetAttribute("y", level.getExitY().ToString());
                    levelElement.AppendChild(exitposition);
                }
                else
                {
                    //Don't add any data to exitposition
                    XmlElement exitposition = document.CreateElement("exitposition");
                    levelElement.AppendChild(exitposition);
                }

                //Do a check to see if the current level has any layers or not.
                if (level.getLayerList().Count == 0)
                {
                    root.AppendChild(levelElement);
                    break;
                }
                XmlElement mapList = document.CreateElement("MapList");
                foreach (MapData map in level.getLayerList())
                {
                    XmlElement mapElement = document.CreateElement("map");
                    mapElement.SetAttribute("name", map.getMapName());
                    mapElement.SetAttribute("z_depth", map.getZDepth().ToString());
                    mapElement.SetAttribute("width", map.getMapWidth().ToString());
                    mapElement.SetAttribute("height", map.getMapHeight().ToString());
                    mapElement.SetAttribute("xsz", map.getMaxTileWidth().ToString());
                    mapElement.SetAttribute("ysz", map.getMaxTileHeight().ToString());
                    mapElement.SetAttribute("drawtype", map.getDrawType().ToString());

                    XmlElement layerOffset = document.CreateElement("layer_offset");
                    layerOffset.SetAttribute("x", map.getLayerOffsetX().ToString());
                    layerOffset.SetAttribute("y", map.getLayerOffsetY().ToString());
                    mapElement.AppendChild(layerOffset);

                    foreach (MapDataTile tile in map.getTileList())
                    {
                        XmlElement tileElement = document.CreateElement("tile");
                        tileElement.SetAttribute("sp", tile._spriteID.ToString());
                        tileElement.SetAttribute("x", tile._xPos.ToString());
                        tileElement.SetAttribute("y", tile._yPos.ToString());
                        mapElement.AppendChild(tileElement);
                    }
                    mapList.AppendChild(mapElement);
                }

                levelElement.AppendChild(mapList);
                root.AppendChild(levelElement);
            }


            document.Save(saveLocation + "\\" + fileName + ".xml");

        }

        //Adds the tiles to the tab based control
        public void addTilesToTabControl(List<SpriteSheet> spriteSheets, List<GraphicTile> tiles, TabControl tabControl)
        {
            //Remove any previous graphics
            if (tabControl.TabPages.Count != 0)
            {
                foreach (TabPage page in tabControl.TabPages)
                {
                    foreach (PictureBox picBox in page.Controls)
                    {
                        picBox.Dispose();
                    }
                    page.Dispose();
                }
                tabControl.TabPages.Clear();
            }

            foreach (SpriteSheet sheet in spriteSheets)
            {
                //Create a new tab for this sprite sheet
                TabPage sheetPage = new TabPage(sheet.getImageFileName());
                sheetPage.AutoScroll = true;
                tabControl.TabPages.Add(sheetPage);

                Bitmap spriteSheetImage = new Bitmap(sheet.getImagePath());

                int tileCurX = 0;
                int tileCurY = 0;
                int maxTileY = 0;

                foreach (GraphicTile tile in tiles)
                {

                    //If the tile is not part of this sheet, just quickly continue
                    if (tile.getFileID() != sheet.getFileId())
                    {
                        continue;
                    }

                    //Create a picture box to load the tile image into -- Possibly PictureBox is slow? Seems okay for now.
                    PictureBox newPictureBox = new PictureBox();
                    newPictureBox.Name = "tile:" + tile.getTileID();    //In order to identify which tile the user has clicked (Parsed with .split(':') later)
                    newPictureBox.Width = tile.getWidth();
                    newPictureBox.Height = tile.getHeight();

                    //Create a new cropped bitmap to be loaded into the PictureBox
                    OpenTK.Vector2 tilePos = tile.getPosition();
                    Rectangle tileRect = new Rectangle((int)tilePos.X, (int)tilePos.Y, tile.getWidth(), tile.getHeight());

                    //If a sprite sheet is 32*32 and there's a single 32*32 tile, it seems like C# just creates a reference rather than a copy.
                    //So the following code just performs a check and does it manually
                    Bitmap cropped = null;
                    if (tileRect.X == 0 && tileRect.Y == 0 && tileRect.Width == spriteSheetImage.Width && tileRect.Height == spriteSheetImage.Height)
                    {
                        cropped = new Bitmap(spriteSheetImage);
                    }
                    else
                    {
                        cropped = new Bitmap(spriteSheetImage.Clone(tileRect, spriteSheetImage.PixelFormat));
                    }
                    
                    newPictureBox.Image = cropped;

                    
                    //Position the PictureBox within the sheetPage control
                    newPictureBox.Left = tileCurX;
                    newPictureBox.Top = tileCurY;
                    newPictureBox.Click += pictureBoxClick;
                    sheetPage.Controls.Add(newPictureBox);

                    //Increment the int that keeps track of X position.
                    tileCurX += tile.getWidth();
                    if (tile.getHeight() > maxTileY)
                    {
                        maxTileY = tile.getHeight();
                    }

                    if ((tileCurX + tile.getWidth()) > sheetPage.Width)
                    {
                        tileCurX = 0;
                        tileCurY += maxTileY;
                        maxTileY = 0;   //Make sure to reset this or other rows will be affected.
                    }

                }
                spriteSheetImage.Dispose();
            }
        }

        //This function is used for when the tile is clicked
        public void pictureBoxClick(object sender, System.EventArgs e)
        {
            //If a tile was selected  before, restore its original image
            if (_lastModifiedTile != null)
            {
                _lastModifiedTile.Image = _lastModifiedTileImage;
            }

            //Cast the event
            MouseEventArgs mouseEvent = (MouseEventArgs)e;

            //If the tile was right clicked, launch the tile editor
            if (mouseEvent.Button == MouseButtons.Right)
            {
                PictureBox invoker = (PictureBox)sender;
                String[] tileNameData = invoker.Name.Split(':');
                int parsedTileID;
                Int32.TryParse(tileNameData[1], out parsedTileID);
                _mainForm.displayTileEditor(parsedTileID);
                return;
            }

            //Cast the caller object to a PictureBox
            PictureBox invokePicture = (PictureBox)sender;
            _lastModifiedTile = invokePicture;

            Bitmap curImage = (Bitmap)invokePicture.Image;
            _lastModifiedTileImage = new Bitmap(curImage);

            //Loop over every pixel and give the selected tile a green tint
            for (int curX = 0; curX < curImage.Width; ++curX)
            {
                for (int curY = 0; curY < curImage.Height; ++curY)
                {
                    Color pixelCol = curImage.GetPixel(curX, curY);
                    byte R = pixelCol.R;
                    byte G = pixelCol.G;
                    byte B = pixelCol.B;

                    R = (byte)(R / 2);
                    G = (byte)(G + 20);
                    B = (byte)(B / 2);
                    Color newCol = Color.FromArgb(R, G, B);
                    curImage.SetPixel(curX, curY, newCol);
                }
            }

            //Set the new image
            invokePicture.Image = curImage;

            //Split the tile ID fromt he name
            String[] tileData = invokePicture.Name.Split(':');
            int tileID;
            Int32.TryParse(tileData[1], out tileID);

            _selectedTile.newData(tileID, 0, 0);

            _mainForm.updateTileUI(_selectedTile.getID());

            Debug.WriteLine("Clicked on tile id: " + tileID);
        }

        //Load the custom tile data XML in
        public void loadTileData(ref TileData loadInto)
        {
            XmlSchema mapSchema = new XmlSchema();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            XmlReader dataReader = XmlReader.Create("data/TileData.xml", settings);

            if (dataReader == null)
            {
                Debug.WriteLine("Failed to load map");
            }
            dataReader.Read();

            while (dataReader.Read())
            {
                if (dataReader.NodeType == XmlNodeType.Element && dataReader.Name == "Type")
                {
                    int id;
                    string name;

                    dataReader.MoveToAttribute("id");
                    id = dataReader.ReadContentAsInt();
                    if (DEVMODE) Console.WriteLine("Type ID: " + id);

                    dataReader.MoveToAttribute("name");
                    name = dataReader.ReadContentAsString();
                    if (DEVMODE) Console.WriteLine("Type Name: " + name);

                    loadInto.addTileType(id, name);
                }

                if (dataReader.NodeType == XmlNodeType.Element && dataReader.Name == "DataOne")
                {

                    int id = 0;
                    string name = null;

                    if (dataReader.MoveToAttribute("id"))
                    {
                        id = dataReader.ReadContentAsInt();
                        if (DEVMODE) Console.WriteLine("Type ID: " + id);
                    }
                    if (dataReader.MoveToAttribute("name"))
                    {
                        name = dataReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Type Name: " + name);
                    }

                    loadInto.getLastList().addDataOne(id, name);

                }

                if (dataReader.NodeType == XmlNodeType.Element && dataReader.Name == "DataTwo")
                {
                    string name = null;
                    string melee;
                    string shot;

                    if (dataReader.MoveToAttribute("name"))
                    {
                        name = dataReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Type Name: " + name);
                    }

                    dataReader.MoveToAttribute("melee");
                    melee = dataReader.ReadContentAsString();
                    if (DEVMODE) Console.WriteLine("Type Name: " + melee);

                    dataReader.MoveToAttribute("shot");
                    shot = dataReader.ReadContentAsString();
                    if (DEVMODE) Console.WriteLine("Type Name: " + shot);

                    loadInto.getLastList().getLastList().setSecondData(name, melee, shot);

                }
            }
        }

    }
}
