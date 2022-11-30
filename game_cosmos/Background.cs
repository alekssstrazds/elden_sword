using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_cosmos
{
    internal class Background : Form1
    {
        //Texture
        Texture screen_texture = new Texture();
        //cordinates
        public float cX { get; set; }
        public float cY { get; set; }
        public float cZ { get; set; }
        public float rotX { get; set; }
        public float rotY { get; set; }
        public float izmeers { get; set; }
        public float angle { get; set; }
        public float rotZ { get; set; }
        public float alphaBg { get; set; }

        public Background(float cX, float cY, float cZ, float rotX, float rotY, float izmeers, float alphaBg)
        {
            this.cX = cX;
            this.cY = cY;
            this.cZ = cZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.izmeers = izmeers;
            this.alphaBg = alpha;
        }
        public Background()
        {
            this.cX = 0.0f;
            this.cY = 0.0f;
            this.cZ = -12.0f;
            this.rotX = 0.0f;
            this.rotY = 0.0f;
            this.izmeers = 1f;
            this.angle = 180;
            this.rotZ = 1.0f;
            this.alphaBg = 0.0f;
        }
        public void showScreen(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(cX, cY, cZ);
            gl.Rotate(angle, rotX, rotY, rotZ);
            gl.Scale(izmeers, izmeers, izmeers);
            gl.Color(1.0f, 1.0f, 1.0f, alpha);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            screen_texture.Create(gl, @"C:\\assets\\bg.png");
            screen_texture.Bind(gl);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.Begin(OpenGL.GL_QUADS);

            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-9.6f, -5.4f, -1.0f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(9.6f, -5.4f, -1.0f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(9.6f, 5.4f, -1.0f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-9.6f, 5.4f, -1.0f);
            gl.End();
            gl.PopMatrix();
        }
    }
}
