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
//using System.Xml.Linq;




namespace BlockEd
{
    

    public partial class Form1 : Form
    {

        bool DEVMODE = false;

        bool opentkLoaded = false;

        Color alphaColorKey;

        List<GraphicTile> graphicTiles = new List<GraphicTile>();
        List<SpriteSheet> graphicFiles = new List<SpriteSheet>();
        List<MapTile> mapTiles = new List<MapTile>();
        GameData loadedMap = null;

        float tileOffsetX = 0;
        float tileOffsetY = 0;

        

        public Form1()
        {
            InitializeComponent();
        }


        //protected override bool IsInputKey(Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        case Keys.Up:
        //        case Keys.Down:
        //        case Keys.Right:
        //        case Keys.Left:
        //            return true;
        //    }
        //    return base.IsInputKey(keyData);
        //}

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

        private void glControl1_Load(object sender, EventArgs e)
        {

            int width = glMapMain.Width;
            int height = glMapMain.Height;

            glMiniMapControl.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, width, height);
            GL.ClearColor(Color.SkyBlue);

            glMapMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, height, 0, -1, 1);
            GL.Viewport(0, 0, width, height);
            GL.ClearColor(Color.SkyBlue);

            
            opentkLoaded = true;

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


            //From: http://social.msdn.microsoft.com/Forums/en/Vsexpressvcs/thread/6bd4da70-5942-48cd-90c7-75abb40a3773
            panel1.Paint += new PaintEventHandler(panel1_Paint);
           
        }
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.smiley, -250, -100);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //Load all the sprite sheets into GL to get the correct texture IDs
            foreach (SpriteSheet sprite in graphicFiles)
            {
                //Set the GL textured ID in the sprite. Different to the file id.
                int spriteWidth = 0;
                int spriteHeight = 0;

                sprite.setGLTexId(LoadTexture(sprite.getImagePath(), ref spriteWidth, ref spriteHeight));

                sprite.setWidth(spriteWidth);
                sprite.setHeight(spriteHeight);

            }
        }

        private void updateGL()
        {
            if (!opentkLoaded)
                return;

            if (loadedMap.getLevelList() == null)
                return;

            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            //GL.Color3(Color.Black);

            //Set alpha blend function -- Will probably need to toggle due to "drawtype"
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);

            //Draw all the tiles
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData layer in level.getLayerList())
                {
                    foreach (MapDataTile tile in layer.getTileList())
                    {
                        //Locate the graphic for this tile
                        GraphicTile tileData = graphicTiles.Find(delegate(GraphicTile data)
                        {
                            return data.getTileID() == tile._spriteID;
                        }
                        );

                        if (tileData == null)
                        {
                            continue;
                        }

                        //Now find the graphic sheet to do with the tile
                        SpriteSheet tileSheet = graphicFiles.Find(delegate(SpriteSheet data)
                        {
                            //Console.WriteLine("Check ID: " + data.getFileId() + " - Needed: " + tileData.getFileID());
                            return data.getFileId() == tileData.getFileID();
                        }
                        );
                        //Bind the sheet to GL
                        GL.BindTexture(TextureTarget.Texture2D, tileSheet.getGLTexId());

                        //SpriteSheet currentTexture = null;

                        //Setup to use the correct texture.
                        //foreach (SpriteSheet sheet in graphicFiles)
                        //{
                        //    if (sheet.getFileId() == graphicTiles[curTile].getFileID())
                        //    {
                        //        currentTexture = sheet;
                        //        GL.BindTexture(TextureTarget.Texture2D, sheet.getGLTexId());
                        //        break;
                        //    }
                        //}

                        int textureWidth = tileSheet.getWidth();
                        int textureHeight = tileSheet.getHeight();

                        float u0 = (float)tileData.getPosition().X / textureWidth;
                        float v0 = (float)tileData.getPosition().Y / textureHeight;

                        int width = tileData.getWidth();
                        int height = tileData.getHeight();

                        float u1 = u0 + (float)tileData.getWidth() / textureWidth;
                        float v1 = v0 + (float)tileData.getHeight() / textureHeight;

                        float tilePositionX = tileOffsetX + tile._xPos * tileData.getWidth();
                        float tilePositionY = tileOffsetY + tile._yPos * tileData.getHeight();



                        GL.Begin(BeginMode.Quads);

                        GL.TexCoord2(u0, v0);
                        GL.Vertex2(tilePositionX, tilePositionY);

                        GL.TexCoord2(u1, v0);
                        GL.Vertex2(tilePositionX + tileData.getWidth(), tilePositionY);

                        GL.TexCoord2(u1, v1);
                        GL.Vertex2(tilePositionX + tileData.getWidth(), tilePositionY + tileData.getHeight());

                        GL.TexCoord2(u0, v1);
                        GL.Vertex2(tilePositionX, tilePositionY + tileData.getHeight());

                        GL.End();

                        if (tile._spriteID == 51)
                        {
                            //break;
                        }
                    }
                }
            }

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);

            glMapMain.SwapBuffers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateGL();
        }


        //From: http://www.opentk.com/doc/graphics/textures/loading
        int LoadTexture(string filename, ref int spriteWidth, ref int spriteHeight)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            if (!System.IO.File.Exists(filename))
                throw new ArgumentException(filename);

            Bitmap bmp = new Bitmap(filename);
            bmp.MakeTransparent(alphaColorKey);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            spriteWidth = bmp_data.Width;
            spriteHeight = bmp_data.Height;

            bmp.UnlockBits(bmp_data);

            // We haven't uploaded mipmaps, so disable mipmapping (otherwise the texture will not appear).
            // On newer video cards, we can use GL.GenerateMipmaps() or GL.Ext.GenerateMipmaps() to create
            // mipmaps automatically. In that case, use TextureMinFilter.LinearMipmapLinear to enable them.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return id;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

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
                           

                            graphicFiles.Add(new SpriteSheet(fileID, "data/" + fileName));

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

                        if(DEVMODE) Console.WriteLine("-------------------------------------------");

                        graphicsReader.MoveToAttribute("id");
                        if(DEVMODE) Console.WriteLine("ID: " + graphicsReader.ReadContentAsInt().ToString());
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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSchema mapSchema = new XmlSchema();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;

            //Good validating code: http://stackoverflow.com/questions/470313/net-how-to-validate-xml-file-with-dtd-without-doctype-declaration

            XmlReader mapReader = XmlReader.Create("map/TestMap.xml", settings);

            //XmlValidatingReader myReader = new XmlValidatingReader(mapReader);

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

                    loadedMap.getLastLoadedLevel().addLayer(width, height, drawType, layerName, maxTileWidth, maxTileHeight);

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

                }
                #endregion

#endregion

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DEVMODE = !DEVMODE;
        }

        private void mousePanGL(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //tileOffsetX += 1;
            //updateGL();
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
                updateGL();
            }

            return handled;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

    }
}
