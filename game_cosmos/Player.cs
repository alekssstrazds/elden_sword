using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_cosmos
{
    internal class Player : Form1
    {
        Texture cat_texture = new Texture();
        //cordinates
        public float cX { get; set; }
        public float cY { get; set; }
        public float cZ { get; set; }
        public float rotX { get; set; }
        public float rotY { get; set; }
        public float izmeers { get; set; }
        public float angle { get; set; }
        public float rotZ { get; set; }
        //health
        public int player_hp { get; set; }

        public int score { get; set; }
        public Player(float cX, float cY, float cZ, float rotX, float rotY, float izmeers, int player_hp, int score)
        {
            this.cX = cX;
            this.cY = cY;
            this.cZ = cZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.izmeers = izmeers;
            this.player_hp = player_hp;
            this.score = score;
        }
        public Player()
        {
            this.cX = 0.0f;
            this.cY = 0.0f;
            this.cZ = -7.0f;
            this.rotX = 1.0f;
            this.rotY = 0.0f;
            this.izmeers = 0.5f;
            this.angle = 180;
            this.rotZ = 0.0f;
            this.player_hp = 3;
            this.score = 0;
        }
        public void showPlayer(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(cX, cY, cZ);
            gl.Rotate(angle, rotX, rotY, rotZ);
            gl.Scale(izmeers, izmeers, izmeers);
            gl.Color(1.0f, 1.0f, 1.0f);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            cat_texture.Create(gl, @"C:\\assets\\cat.png");
            cat_texture.Bind(gl);

            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.96f, 0.8f, 0.8f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.96f, 0.8f, 0.8f);
            gl.End();
            gl.PopMatrix();
        }
    }
}
