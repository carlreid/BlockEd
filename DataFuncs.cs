using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace BlockEd
{
    //Pretty much a class to hide away all the data loading/writing(eventually) functions
    class DataFuncs
    {
        bool DEVMODE = false;

        public void loadGraphics(List<GraphicTile> graphicTiles, List<SpriteSheet> graphicFiles, ref bool mapLoaded)
        {

            if (graphicTiles.Count > 0)
            {
                graphicTiles.Clear();
                Console.WriteLine("Cleared graphicTiles");
            }
            if (graphicFiles.Count > 0)
            {
                graphicFiles.Clear();
                Console.WriteLine("Cleared graphicFiles");
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            Color alphaColorKey;

            XmlReader graphicsReader = XmlReader.Create("data/Graphics.xml", settings);
            graphicsReader.Read();

            while (graphicsReader.Read())
            {
                //  Here we check the type of the node, in this case we are looking for element
                if (graphicsReader.NodeType == XmlNodeType.Element)
                {
                    //  If the element is "profile"
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
                            //graphicFiles.Add(new SpriteSheet(id, string);

                            int fileID = 0;
                            string fileName = "";

                            graphicsReader.MoveToAttribute("id");
                            //Console.WriteLine("Attrib: " + graphicsReader.Value.ToString());
                            fileID = graphicsReader.ReadContentAsInt();

                            graphicsReader.MoveToElement();
                            fileName = graphicsReader.ReadElementContentAsString();

                            graphicFiles.Add(new SpriteSheet(fileID, fileName));

                        }
                        //graphicsReader.ReadEndElement();
                    }

                    if (graphicsReader.NodeType == XmlNodeType.Element && graphicsReader.Name == "sprite")
                    {

                        //graphicTiles.Add(new Tile());
                        //Vector2 Position;
                        //Vector2 TexCoord;
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

        public GameData loadMap(GameData loadedMap, string mapFilePath = null)
        {
            XmlSchema mapSchema = new XmlSchema();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;

            //Good validating code: http://stackoverflow.com/questions/470313/net-how-to-validate-xml-file-with-dtd-without-doctype-declaration
            XmlReader mapReader = null;
            if (mapFilePath == null)
            {
                mapReader = XmlReader.Create("map/TestMap.xml", settings);
            }
            else
            {
                mapReader = XmlReader.Create(mapFilePath, settings);
            }

            //XmlValidatingReader myReader = new XmlValidatingReader(mapReader);

            if (mapReader == null)
            {
                Debug.WriteLine("Failed to load map");
            }
            mapReader.Read();

            while (mapReader.Read())
            {
                #region GameData
                //string mapName = "Default";
                //int maxMapX = 0;
                //int maxMapY = 0;

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "Game")
                {
                    if (mapReader.MoveToAttribute("name"))
                    {
                        string mapName = mapReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Map Name: " + mapName);

                        loadedMap = new GameData(mapName);

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

                string levelName = null;
                int levelStartX = 0;
                int levelStartY = 0;

                if (mapReader.NodeType == XmlNodeType.Element && mapReader.Name == "Level")
                {
                    if (mapReader.MoveToAttribute("name"))
                    {
                        levelName = mapReader.ReadContentAsString();
                        if (DEVMODE) Console.WriteLine("Level Name: " + levelName);
                    }
                }

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
                    loadedMap.addLevel(levelStartX, levelStartY, levelName);
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
            return loadedMap;
        }

        public void addTilesToTabControl(List<SpriteSheet> spriteSheets, List<GraphicTile> tiles, TabControl tabControl)
        {
            foreach (SpriteSheet sheet in spriteSheets)
            {
                TabPage sheetPage = new TabPage(sheet.getImageFileName());
                tabControl.TabPages.Add(sheetPage);

                //Image imgsrc = Image.FromFile("C:/Users/k0256525/Desktop/smiley.jpg"); // your PNG file
                //int imgwidth = imgsrc.Width;
                //int n = 10;
                //int imgindex = 1;
                //Image imgdst = new Bitmap(imgwidth / n, imgsrc.Height);
                //using (Graphics gr = Graphics.FromImage(imgdst))
                //{
                //    gr.DrawImage(imgsrc,
                //        new RectangleF(0, 0, imgdst.Width, imgdst.Height),
                //        new RectangleF(imgindex * imgwidth / n, 0, imgwidth / n, imgsrc.Height),
                //        GraphicsUnit.Pixel);
                //}

                Bitmap spriteSheetImage = new Bitmap(sheet.getImagePath());

                int tileCurX = 0;
                int tileCurY = 0;
                int maxTileY = 0;

                foreach (GraphicTile tile in tiles)
                {

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
                    Bitmap cropped = (Bitmap)spriteSheetImage.Clone(tileRect, spriteSheetImage.PixelFormat);
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
            }
        }

        public void pictureBoxClick(object sender, System.EventArgs e)
        {
            PictureBox invokePanel = (PictureBox)sender;
            String[] panelData = invokePanel.Name.Split(':');
            MessageBox.Show("Invoker = " + panelData[1]);
        }

    }
}
