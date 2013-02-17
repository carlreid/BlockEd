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
//using System.Xml.Linq;




namespace BlockEd
{
    

    public partial class Form1 : Form
    {

        bool DEVMODE = false;
        bool mapLoaded = false;

<<<<<<< HEAD
=======
        string mapFilePath = null;

>>>>>>> Added loading of maps + Dev Panel
        //bool opentkLoaded = false;

        Color alphaColorKey;

        List<GraphicTile> graphicTiles = new List<GraphicTile>();
        List<SpriteSheet> graphicFiles = new List<SpriteSheet>();
        List<MapTile> mapTiles = new List<MapTile>();
        GameData loadedMap = null;

<<<<<<< HEAD
        GLFuncs glFuncs = new GLFuncs();
=======
        GLFuncs glFuncs;
>>>>>>> Added loading of maps + Dev Panel
        DataFuncs data = new DataFuncs();

        float tileOffsetX = 0;
        float tileOffsetY = 0;


        public Form1()
        {
            InitializeComponent();
            glFuncs = new GLFuncs(this);
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

<<<<<<< HEAD
        //private void updateGL(ref GLControl glControl)
        //{
        //    if (!opentkLoaded)
        //        return;

        //    if (loadedMap.getLevelList() == null)
        //        return;

        //    //glControl.MakeCurrent();

        //    GL.ClearColor(Color.Black);
        //    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        //    GL.MatrixMode(MatrixMode.Modelview);
        //    GL.LoadIdentity();

        //    //GL.Color3(Color.Black);

        //    //Set alpha blend function -- Will probably need to toggle due to "drawtype"
        //    GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

        //    GL.Enable(EnableCap.Texture2D);
        //    GL.Enable(EnableCap.Blend);

        //    //Draw all the tiles
        //    foreach (GameLevel level in loadedMap.getLevelList())
        //    {
        //        foreach (MapData layer in level.getLayerList())
        //        {
        //            foreach (MapDataTile tile in layer.getTileList())
        //            {
        //                //Locate the graphic for this tile
        //                GraphicTile tileData = graphicTiles.Find(delegate(GraphicTile data)
        //                {
        //                    return data.getTileID() == tile._spriteID;
        //                }
        //                );

        //                if (tileData == null)
        //                {
        //                    continue;
        //                }

        //                //Now find the graphic sheet to do with the tile
        //                SpriteSheet tileSheet = graphicFiles.Find(delegate(SpriteSheet data)
        //                {
        //                    //Console.WriteLine("Check ID: " + data.getFileId() + " - Needed: " + tileData.getFileID());
        //                    return data.getFileId() == tileData.getFileID();
        //                }
        //                );
        //                //Bind the sheet to GL
        //                GL.BindTexture(TextureTarget.Texture2D, tileSheet.getGLTexId());

        //                //SpriteSheet currentTexture = null;

        //                //Setup to use the correct texture.
        //                //foreach (SpriteSheet sheet in graphicFiles)
        //                //{
        //                //    if (sheet.getFileId() == graphicTiles[curTile].getFileID())
        //                //    {
        //                //        currentTexture = sheet;
        //                //        GL.BindTexture(TextureTarget.Texture2D, sheet.getGLTexId());
        //                //        break;
        //                //    }
        //                //}

        //                int textureWidth = tileSheet.getWidth();
        //                int textureHeight = tileSheet.getHeight();

        //                float u0 = (float)tileData.getPosition().X / textureWidth;
        //                float v0 = (float)tileData.getPosition().Y / textureHeight;

        //                int width = tileData.getWidth();
        //                int height = tileData.getHeight();

        //                float u1 = u0 + (float)tileData.getWidth() / textureWidth;
        //                float v1 = v0 + (float)tileData.getHeight() / textureHeight;

        //                float tilePositionX = tileOffsetX + tile._xPos * tileData.getWidth();
        //                float tilePositionY = tileOffsetY + tile._yPos * tileData.getHeight();



        //                GL.Begin(BeginMode.Quads);

        //                GL.TexCoord2(u0, v0);
        //                GL.Vertex2(tilePositionX, tilePositionY);

        //                GL.TexCoord2(u1, v0);
        //                GL.Vertex2(tilePositionX + tileData.getWidth(), tilePositionY);

        //                GL.TexCoord2(u1, v1);
        //                GL.Vertex2(tilePositionX + tileData.getWidth(), tilePositionY + tileData.getHeight());

        //                GL.TexCoord2(u0, v1);
        //                GL.Vertex2(tilePositionX, tilePositionY + tileData.getHeight());

        //                GL.End();

        //                if (tile._spriteID == 51)
        //                {
        //                    //break;
        //                }
        //            }
        //        }
        //    }

        //    GL.Disable(EnableCap.Blend);
        //    GL.Disable(EnableCap.Texture2D);

        //    glControl.SwapBuffers();
        //}
=======
        protected override void OnPaint(PaintEventArgs e)
        {
            updateGL(glMapMain);
            base.OnPaint(e);
        }

        private void updateGL(GLControl glControl)
        {
            if (mapLoaded)
            {
                glFuncs.updateGL(glControl, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
            }
        }
>>>>>>> Added loading of maps + Dev Panel

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

            //opentkLoaded = true;

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

        public void updateGlLoadSpeedLabel(string loadTime)
        {
<<<<<<< HEAD
=======
            glLoadSpeedLabel.Text = "Rendered in: " + loadTime;
        }

        private void button4_Click(object sender, EventArgs e)
        {
>>>>>>> Added loading of maps + Dev Panel
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
=======
            updateGL(glMapMain);
>>>>>>> Added loading of maps + Dev Panel
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
<<<<<<< HEAD
            data.loadGraphics(graphicTiles, graphicFiles);
=======
            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
>>>>>>> Added loading of maps + Dev Panel
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
<<<<<<< HEAD
                glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
=======
                updateGL(glMapMain);
>>>>>>> Added loading of maps + Dev Panel
            }

            return handled;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
<<<<<<< HEAD

            data.loadGraphics(graphicTiles, graphicFiles);
            loadedMap = data.loadMap(loadedMap);
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
            
            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            glLoadSpeedLabel.Text = "Loaded in: " + executionTime.ToString();
        }

        public string glLoadSpeed
        {
            get { return glLoadSpeedLabel.Text; }
            set { glLoadSpeedLabel.Text = value; }
        }

=======

            data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
            loadedMap = data.loadMap(loadedMap);
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            updateGL(glMapMain);
            
            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            glLoadSpeedLabel.Text = "Loaded in: " + executionTime.ToString();
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

>>>>>>> Added loading of maps + Dev Panel

    }
}
