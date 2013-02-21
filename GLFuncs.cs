using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BlockEd
{
    public struct Vertex
    {
        public Vector3 position;
        public Vector2 tex_coords;

        public Vertex(Vector3 position, Vector2 tex_coords)
            : this()
        {
            this.position = position;
            this.tex_coords = tex_coords;
        }
    }

    class GLFuncs
    {
        //Useful source on loading in shaders/setting them up: http://www.opentk.com/node/92


        private Form1 callerForm;

        public GLFuncs(Form1 callerForm)
        {
            this.callerForm = callerForm;

        }

        public void updateGL(GLControl glControl, float tileOffsetX, float tileOffsetY, GameData loadedMap, List<GraphicTile> graphicTiles, List<SpriteSheet> graphicFiles, string layerSelected = null)
        {

            //Create a program and fragment shader.
            int _fragShader = GL.CreateShader(ShaderType.FragmentShader);
            int _vertexShader = GL.CreateShader(ShaderType.VertexShader);
            int _program = GL.CreateProgram();
            string _fragString = @"
                            #version 330

                            uniform sampler2D texture_id;
                            uniform int apply_red;

                            in vec2 varying_texcoord;
                            out vec4 fragment_colour;
                            void main(void)
                            {
                                //vec3 color = vec3(0, 1, 0);
                                vec3 color = texture(texture_id, varying_texcoord).rgb;
                                //if(apply_red == 1){
                                //    color = vec3(1, 0, 0);
                                //}
                                fragment_colour = vec4(color, 1.0);
                            }";
//            string _vertexString = @"
//                            #version 330
//                            in vec3 vertex_position;
//                            in vec2 vertex_texcoord;
//
//                            out vec2 varying_texcoord;
//                            void main(void)
//                            {
//                                varying_texcoord = vertex_texcoord;
//                                gl_Position = vec4(vertex_position, 1.0);
//                            }";
            GL.ShaderSource(_fragShader, @_fragString);
            //GL.ShaderSource(_vertexShader, _vertexString);
            GL.CompileShader(_fragShader);
            //GL.CompileShader(_vertexShader);
            GL.AttachShader(_program, _fragShader);
            //GL.AttachShader(_program, _vertexShader);

            //GL.BindAttribLocation(_program, 0, "vertex_position");
            //GL.BindAttribLocation(_program, 1, "vertex_texcoord");



            //GL.BindAttribLocation(_program, 0, "vertex_texcoord");
            //int texcoord_index = GL.GetAttribLocation(_program, "vertex_texcoord");


            GL.LinkProgram(_program);
            //GL.UseProgram(_program);

            string info;
            GL.GetProgramInfoLog(_program, out info);

            if (info != "")
                Debug.WriteLine(info);

            //bool applyTint = false;

            if (loadedMap.getLevelList() == null)
                return;

            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            glControl.MakeCurrent();

            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            //Set alpha blend function -- Will probably need to toggle due to "drawtype"
            ////GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
            

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.ColorMaterial);

            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            //List<Vertex> vertices = new List<Vertex>();

            //Draw all the tiles
            foreach (GameLevel level in loadedMap.getLevelList())
            {
                foreach (MapData layer in level.getLayerList())
                {

                    //Debug.WriteLine(glControl.Name + " is drawing Z Depth: " + layer.getZDepth());

                    //Check to see if we want to render a specific layer.
                    //If we do, check if this is that layer, else continue.
                    if (layerSelected != null)
                    {
                        if (layer.getMapName() != layerSelected)
                        {
                            //GL.Color3(Color.Red);
                            GL.Uniform1(GL.GetUniformLocation(_program, "apply_red"), 1);
                        }
                        else
                        {
                            GL.Uniform1(GL.GetUniformLocation(_program, "apply_red"), 0);
                        }
                    }
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
                        GL.ActiveTexture((TextureUnit)tileSheet.getGLTexId());
                        GL.BindTexture(TextureTarget.Texture2D, tileSheet.getGLTexId());
                        GL.Uniform1(GL.GetUniformLocation(_program, "texture_id"), tileSheet.getGLTexId());

                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.Clamp);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.Clamp);

                        GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, Color.Red);


                        int textureWidth = tileSheet.getWidth();
                        int textureHeight = tileSheet.getHeight();

                        float u0 = (float)tileData.getPosition().X / textureWidth;
                        float v0 = (float)tileData.getPosition().Y / textureHeight;

                        int width = tileData.getWidth();
                        int height = tileData.getHeight();

                        float u1 = u0 + (float)tileData.getWidth() / textureWidth;
                        float v1 = v0 + (float)tileData.getHeight() / textureHeight;

                        float tilePositionX = tileOffsetX + tile._xPos * layer.getMaxTileWidth();
                        float tilePositionY = tileOffsetY + tile._yPos * layer.getMaxTileHeight();


                        float z_depth = layer.getZDepth() / 10; //Z depth is currently an int (0, 1, 5 etc) but we want it between -1 .. 1


                        GL.Begin(BeginMode.Quads);
                        if (layerSelected != null)
                        {
                            if (layer.getMapName() != layerSelected)
                            {
                                GL.Color4(0.2f, 0.1f, 0.1f, 0.1f);
                            }
                            else
                            {
                                GL.Color4(1f, 1f, 1f, 1f);
                            }
                        }

                        //GL.Color4(1, 0, 0, 0.1f);
                        GL.TexCoord2(u0, v0);
                        GL.Vertex3(tilePositionX, tilePositionY, z_depth);

                        //GL.Color4(0, 1, 0, 0.4f);
                        GL.TexCoord2(u1, v0);
                        GL.Vertex3(tilePositionX + tileData.getWidth(), tilePositionY, z_depth);

                        //GL.Color4(0, 0, 1, 0.6f);
                        GL.TexCoord2(u1, v1);
                        GL.Vertex3(tilePositionX + tileData.getWidth(), tilePositionY + tileData.getHeight(), z_depth);

                        //GL.Color4(1, 0, 1, 0.8f);
                        GL.TexCoord2(u0, v1);
                        GL.Vertex3(tilePositionX, tilePositionY + tileData.getHeight(), z_depth);

                        GL.End();

                        //GL.Disable(EnableCap.ColorMaterial);

                        //Used to populate List<Vertex> with tile data
                        //vertices.Add(new Vertex(new Vector3(tilePositionX, tilePositionY, z_depth), new Vector2(u0, v0)));
                        //vertices.Add(new Vertex(new Vector3(tilePositionX + tileData.getWidth(), tilePositionY, z_depth), new Vector2(u1, v0)));
                        //vertices.Add(new Vertex(new Vector3(tilePositionX + tileData.getWidth(), tilePositionY + tileData.getHeight(), z_depth), new Vector2(u1, v1)));
                        //vertices.Add(new Vertex(new Vector3(tilePositionX, tilePositionY + tileData.getHeight(), z_depth), new Vector2(u0, v1)));

                        if (tile._spriteID == 51)
                        {
                            //break;
                        }
                    }
                }
            }

            #region Attempt at creating buffers
            /*
            int VBO;
            GL.GenBuffers(1, out VBO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            int arraySize = vertices.Count;
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Count * (sizeof(float) * 5)),
                          vertices.ToArray(), BufferUsageHint.StaticDraw);  //vertices.ToArray() may be costly.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            int VAO;
            GL.GenVertexArrays(1, out VAO);
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementData[0]); //Need to create element vbo and replace 0
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);

            //Vertex Position
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, sizeof(float) * 5, 0);

            //Vertex Texcoord
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, sizeof(float) * 5, sizeof(float) * 3);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.DrawElements(BeginMode.Quads, elementData.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            */
            #endregion



            glControl.SwapBuffers();

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);

            //GL.DeleteBuffers(1, ref VBO);

            stopWatch.Stop();
            var executionTime = stopWatch.Elapsed;
            callerForm.updateGlLoadSpeedLabel(executionTime.ToString());

        }

        //From: http://www.opentk.com/doc/graphics/textures/loading
        int LoadTexture(string filename, ref int spriteWidth, ref int spriteHeight, Color alphaColorKey)
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

        public void loadSpriteSheets(List<SpriteSheet> graphicFiles, Color alphaColorKey)
        {
            //Load all the sprite sheets into GL to get the correct texture IDs
            foreach (SpriteSheet sprite in graphicFiles)
            {
                //Set the GL textured ID in the sprite. Different to the file id.
                int spriteWidth = 0;
                int spriteHeight = 0;

                sprite.setGLTexId(LoadTexture(sprite.getImagePath(), ref spriteWidth, ref spriteHeight, alphaColorKey));

                sprite.setWidth(spriteWidth);
                sprite.setHeight(spriteHeight);

            }
        }
    }
}
