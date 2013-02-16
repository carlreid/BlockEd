using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace BlockEd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool DEVMODE = false;

        //bool opentkLoaded = false;

        System.Drawing.Color alphaColorKey;

        List<GraphicTile> graphicTiles = new List<GraphicTile>();
        List<SpriteSheet> graphicFiles = new List<SpriteSheet>();
        List<MapTile> mapTiles = new List<MapTile>();
        GameData loadedMap = null;

        GLFuncs glFuncs = new GLFuncs();
        DataFuncs data = new DataFuncs();

        GLControl glMapMain;
        //GLControl glMiniMapControl;

        float tileOffsetX = 0;
        float tileOffsetY = 0;

        protected override void OnKeyDown(KeyEventArgs keyData)
        {
            keyboardPanGLControl(keyData);
            //OnKeyDown(keyData);
            base.OnKeyDown(keyData);
        }

        public MainWindow()
        {
            InitializeComponent();
            
            
            //glMapMain.

            //glMiniMapControl = new GLControl();

            //glMapMain.MakeCurrent();
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, (int)GLHost.Width, (int)GLHost.Height, 0, -1, 1);
            //GL.Viewport(0, 0, (int)GLHost.Width, (int)GLHost.Height);
            //GL.ClearColor(OpenTK.Graphics.Color4.Black);

            //GLHost.Child = glMapMain;
            //GLHost.Child.Width = (int)GLHost.Width;
            //GLHost.Child.Height = (int)GLHost.Height;
        }

        private bool keyboardPanGLControl(KeyEventArgs e)
        {
            bool handled = false;

            if (e.Key == System.Windows.Input.Key.Left || e.Key == System.Windows.Input.Key.A)
            {
                tileOffsetX += 10;
                handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Right || e.Key == System.Windows.Input.Key.D)
            {
                tileOffsetX -= 10;
                handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Up || e.Key == System.Windows.Input.Key.W)
            {
                tileOffsetY += 10;
                handled = true;
            }
            else if (e.Key == System.Windows.Input.Key.Down || e.Key == System.Windows.Input.Key.S)
            {
                tileOffsetY -= 10;
                handled = true;
            }
            if (handled)
            {
                glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
            }

            return handled;
        }

        //private void glControl1_Load(object sender, EventArgs e)
        //{

        //    //GLHost.
            
        //    //int width = glMapMain.Width;
        //    //int height = glMapMain.Height;

        //    //glMiniMapControl.MakeCurrent();
        //    //GL.MatrixMode(MatrixMode.Projection);
        //    //GL.LoadIdentity();
        //    //GL.Ortho(0, width, height, 0, -1, 1);
        //    //GL.Viewport(0, 0, width, height);
        //    //GL.ClearColor(OpenTK.Graphics.Color4.Black);

        //    glMapMain.MakeCurrent();
        //    GL.MatrixMode(MatrixMode.Projection);
        //    GL.LoadIdentity();
        //    GL.Ortho(0, (int)GLHost.Width, (int)GLHost.Height, 0, -1, 1);
        //    GL.Viewport(0, 0, (int)GLHost.Width, (int)GLHost.Height);
        //    GL.ClearColor(OpenTK.Graphics.Color4.Black);

        //    //GLHost.Child = glMapMain;
        //    //GLHost.Child.Width = (int)GLHost.Width;
        //    //GLHost.Child.Height = (int)GLHost.Height;

        //    //alphaColorKey = System.Drawing.Color.Black;
        //}

        //Binds the GLControl to the WindowsFormsHost which is needed to run inside the WPF
        private void bindGLWindow(GLControl controlToBind)
        {
            controlToBind.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, GLHost.Width, GLHost.Height, 0, -1, 1);
            GL.Viewport(0, 0, (int)GLHost.Width, (int)GLHost.Height);
            GL.ClearColor(OpenTK.Graphics.Color4.Black);

            GLHost.Child = controlToBind;
            GLHost.Child.Width = (int)GLHost.Width;
            GLHost.Child.Height = (int)GLHost.Height;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            glMapMain = new GLControl();

            bindGLWindow(glMapMain);

            alphaColorKey = System.Drawing.Color.Black;

            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            data.loadGraphics(graphicTiles, graphicFiles);
            loadedMap = data.loadMap(loadedMap);
            glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
            glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);

            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            //glLoadSpeedLabel.Text = "Loaded in: " + executionTime.ToString();
        }

        private void GLControl_Load_1(object sender, EventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //tileOffsetX += 10;
            glFuncs.updateGL(glMapMain, tileOffsetX, tileOffsetY, loadedMap, graphicTiles, graphicFiles);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
