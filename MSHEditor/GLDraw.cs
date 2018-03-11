using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using LibSWBF2.MSH.Chunks;
using LibSWBF2.MSH.Types;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Paloma;

namespace MSHEditor {
    class GLDraw {
        private static readonly PrimitiveType texturedMode = PrimitiveType.TriangleStrip;
        private static readonly PrimitiveType wireframeMode = PrimitiveType.LineStrip;

        public Vector3 cameraPosition;
        public Vector3 cameraRotation;
        public Color BackgroundColor { get; set; }
        public Color CollisionColor { get; set; } = Color.FromArgb(0, 255, 0);
        public Color TerrainCutColor { get; set; } = Color.FromArgb(255, 0, 255);
        public Color MiscColor { get; set; } = Color.FromArgb(0, 0, 255);
        public SEGMDraw[] SegmentsToRender { get; set; }
        public DrawMode DrawMode { get; set; }

        private GLControl glControl;
        private Dictionary<string, int> textures = new Dictionary<string, int>();


        public GLDraw(GLControl glControl) {
            this.glControl = glControl;
            ResetCamera();

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
        }

        public void ResetCamera() {
            cameraPosition = new Vector3(0f, -5f, 50f);
            cameraRotation = Vector3.Zero;
        }

        public void Resize() {
            if (glControl.ClientSize.Height == 0)
                glControl.ClientSize = new Size(glControl.ClientSize.Width, 1);

            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            float aspect_ratio = glControl.ClientSize.Width / (float)glControl.ClientSize.Height;
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 10000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        public bool LoadTextures(FileInfo[] textureFiles) {
            bool success = false;
            textures.Clear();

            foreach (FileInfo texFile in textureFiles) {
                if (texFile.Exists && !textures.ContainsKey(texFile.Name)) {
                    Bitmap tga = new TargaImage(texFile.FullName).Image;

                    int id = GL.GenTexture();
                    GL.BindTexture(TextureTarget.Texture2D, id);

                    BitmapData data = tga.LockBits(new Rectangle(0, 0, tga.Width, tga.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                    tga.UnlockBits(data);

                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                    
                    textures.Add(texFile.Name, id);
                }
            }

            return success;
        }

        public void Render() {
            //Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            Matrix4 lookat = Matrix4.LookAt(0, cameraPosition.Z, cameraPosition.Z, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //GL.Translate(cameraPosition);
            GL.Translate(cameraPosition.X, cameraPosition.Y, 0f);

            GL.Rotate(cameraRotation.X, 1.0f, 0.0f, 0.0f);
            GL.Rotate(cameraRotation.Y, 0.0f, 1.0f, 0.0f);
            GL.Rotate(cameraRotation.Z, 0.0f, 0.0f, 1.0f);

            GL.ClearColor(BackgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            RenderSegments();

            glControl.SwapBuffers();
        }

        private void RenderSegments() {
            if (SegmentsToRender == null)
                return;

            foreach (SEGMDraw segm in SegmentsToRender) {
                foreach (Polygon poly in segm.segment.Polygons) {
                    PrimitiveType primitiveDraw = PrimitiveType.Points;
                    Color color = Color.FromArgb(
                        (int)(segm.segment.Material.Diffuse.A * 255),
                        (int)(segm.segment.Material.Diffuse.R * 255),
                        (int)(segm.segment.Material.Diffuse.G * 255),
                        (int)(segm.segment.Material.Diffuse.B * 255)
                    );
                    
                    if (segm.tag == ModelTag.Collision || segm.tag == ModelTag.VehicleCollision) {
                        primitiveDraw = wireframeMode;
                        color = CollisionColor;
                    }
                    else if (segm.tag == ModelTag.TerrainCut) {
                        primitiveDraw = wireframeMode;
                        color = TerrainCutColor;
                    } 
                    else if (segm.tag == ModelTag.Miscellaneous) {
                        primitiveDraw = wireframeMode;
                        color = MiscColor;
                    } 
                    else {
                        if (DrawMode == DrawMode.Textured)
                            primitiveDraw = texturedMode;
                        else if (DrawMode == DrawMode.Wireframe)
                            primitiveDraw = wireframeMode;
                        else
                            primitiveDraw = PrimitiveType.Points;
                    }

                    if (primitiveDraw == texturedMode && segm.segment.Material != null && !string.IsNullOrEmpty(segm.segment.Material.Texture) && 
                        textures.TryGetValue(segm.segment.Material.Texture, out int texID)) {
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, texID);
                    }
                    else {
                        GL.Disable(EnableCap.Texture2D);
                    }

                    GL.Begin(primitiveDraw);
                    GL.Color3(color);

                    foreach (Vertex vert in poly.Vertices) {
                        if (primitiveDraw == texturedMode)
                            GL.TexCoord2(vert.uvCoordinate.X, vert.uvCoordinate.Y);

                        GL.Vertex3(vert.position.X, vert.position.Y, vert.position.Z);
                    }
                    GL.End();
                }
            }
        }
    }
}
