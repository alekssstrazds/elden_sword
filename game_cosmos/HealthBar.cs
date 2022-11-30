using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_cosmos
{
    internal class HealthBar : Form1
    {
        //Texture
        Texture heart_texture = new Texture();
        public String textureLink2;
        //cordinates
        public float cX { get; set; }
        public float cY { get; set; }
        public float cZ { get; set; }
        public float rotX { get; set; }
        public float rotY { get; set; }
        public float izmeers { get; set; }
        public float angle { get; set; }
        public float rotZ { get; set; }

        public HealthBar(float cX, float cY, float cZ, float rotX, float rotY, float izmeers)
        {
            this.cX = cX;
            this.cY = cY;
            this.cZ = cZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.izmeers = izmeers;
        }
        public HealthBar()
        {
            this.cX = -3.8f;
            this.cY = 2.2f;
            this.cZ = -6.0f;
            this.rotX = 1.0f;
            this.rotY = 0.0f;
            this.izmeers = 0.28f;
            this.angle = 180;
            this.rotZ = 0.0f;
        }
        public void showHealthBar(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(cX, cY, cZ);
            gl.Rotate(angle, rotX, rotY, rotZ);
            gl.Scale(izmeers, izmeers, izmeers);
            gl.Color(1.0f, 1.0f, 1.0f);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            heart_texture.Create(gl, textureLink2);
            heart_texture.Bind(gl);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.Begin(OpenGL.GL_QUADS);

            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-3.0f, -1.0f, 1.0f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(3.0f, -1.0f, 1.0f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(3.0f, 1.0f, 1.0f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-3.0f, 1.0f, 1.0f);
            gl.End();
            gl.PopMatrix();
        }

        public void showHealthStatus(int hearts)
        {
            switch (hearts)
            {
                case 3:
                    textureLink2 = @"C:\\assets\\health_1.png";
                    break;
                case 2:
                    textureLink2 = @"C:\\assets\\health_2.png";
                    break;
                case 1:
                    textureLink2 = @"C:\\assets\\health_3.png";
                    break;
                case 0:
                    textureLink2 = @"C:\\assets\\health_4.png";
                    break;
                default:
                    break;
            }
        }
    }
}
