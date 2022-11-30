using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Transformations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace game_cosmos
{
    internal class Enemie : Form1
    {
        //Texture
        Texture knight_texture = new Texture();
        public String textureLink4;
        //cordinates
        public float cX { get; set; }
        public float cY { get; set; }
        public float cZ { get; set; }
        public float rotX { get; set; }
        public float rotY { get; set; }
        public float izmeers { get; set; }
        public float angle { get; set; }
        public float rotZ { get; set; }

        public int enemieSh { get; set; }
        public String genEnemieShield { get; set; }

        public Enemie(float cX, float cY, float cZ, float rotX, float rotY, float izmeers, int enemieSh)
        {   
            this.cX = cX;
            this.cY = cY;
            this.cZ = cZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.izmeers = izmeers;
            this.enemieSh = enemieSh;
            genSymbolsE(enemieSh);
        }
        public Enemie()
        {
            this.cX = -3.0f; 
            this.cY = -1.0f; 
            this.cZ = -7.0f;
            this.rotX = 1.0f;
            this.rotY = 0.0f;
            this.izmeers = 0.5f;
            this.angle = 180;
            this.rotZ = 0.0f;
            this.enemieSh = 4;
            genSymbolsE(4);
        }

        public void showEnemie(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(cX, cY, cZ);
            gl.Rotate(angle, rotX, rotY, rotZ);
            gl.Scale(izmeers, izmeers, izmeers);
            gl.Color(1.0f, 1.0f, 1.0f);
            
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            knight_texture.Create(gl, textureLink4);
            knight_texture.Bind(gl);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.Begin(OpenGL.GL_QUADS);

            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.96f, 0.8f, 0.8f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.96f, 0.8f, 0.8f);
            gl.End();
            gl.PopMatrix();
        }
        public String genSymbolsE(int enemieSh)
        {
            char[] allowedSymbols = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            Random r = new Random(GetHashCode());
            for (int i = 0; i < enemieSh; i++)
            {
                genEnemieShield += allowedSymbols[r.Next(0, 26)].ToString();
            }
            return genEnemieShield;
        }
        public void showEnemieType(int enemieType)
        {
            switch (enemieType)
            {
                case 0:
                    textureLink4 = @"C:\\assets\\knight.png";
                    break;
                case 1:
                    textureLink4 = @"C:\\assets\\dragon.png";
                    break;
                default:
                    break;
            }
        }
    }
}