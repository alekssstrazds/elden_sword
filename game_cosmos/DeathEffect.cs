using SharpGL.SceneGraph.Assets;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_cosmos
{
    internal class DeathEffect : Form1
    {
        //Texture
        Texture death_effect_texture = new Texture();
        public String textureLink3 = @"C:\\assets\\default.png";
        //cordinates
        public float cX { get; set; }
        public float cY { get; set; }
        public float cZ { get; set; }
        public float rotX { get; set; }
        public float rotY { get; set; }
        public float izmeers { get; set; }
        public float angle { get; set; }
        public float rotZ { get; set; }

        public DeathEffect(float cX, float cY, float cZ, float rotX, float rotY, float izmeers)
        {
            this.cX = cX;
            this.cY = cY;
            this.cZ = cZ;
            this.rotX = rotX;
            this.rotY = rotY;
            this.izmeers = izmeers;
        }
        public DeathEffect()
        {
            this.cX = 0.0f;
            this.cY = 0.2f;
            this.cZ = -6.0f;
            this.rotX = 1.0f;
            this.rotY = 0.0f;
            this.izmeers = 1.0f;
            this.angle = 180;
            this.rotZ = 0.0f;
        }
        public void showDeath(OpenGL gl)
        {
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(cX, cY, cZ);
            gl.Rotate(angle, rotX, rotY, rotZ);
            gl.Scale(izmeers, izmeers, izmeers);
            gl.Color(1.0f, 1.0f, 1.0f);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            death_effect_texture.Create(gl, textureLink3);
            death_effect_texture.Bind(gl);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.96f, -0.8f, 0.8f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.96f, 0.8f, 0.8f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.96f, 0.8f, 0.8f);
            gl.End();
            gl.PopMatrix();
        }

        public void showDeathAnimationStatus(int animation)
        {
            switch (animation)
            {
                case 0:
                    textureLink3 = @"C:\\assets\\default.png";
                    break;
                case 1:
                    textureLink3 = @"C:\\assets\\animation\\tile000.png";
                    break;
                case 2:
                    textureLink3 = @"C:\\assets\\animation\\tile001.png";
                    break;
                case 3:
                    textureLink3 = @"C:\\assets\\animation\\tile002.png";
                    break;
                case 4:
                    textureLink3 = @"C:\\assets\\animation\\tile003.png";
                    break;
                case 5:
                    textureLink3 = @"C:\\assets\\animation\\tile004.png";
                    break;
                case 6:
                    textureLink3 = @"C:\\assets\\animation\\tile005.png";
                    break;
                case 7:
                    textureLink3 = @"C:\\assets\\animation\\tile006.png";
                    break;
                case 8:
                    textureLink3 = @"C:\\assets\\animation\\tile007.png";
                    break;
                case 9:
                    textureLink3 = @"C:\\assets\\animation\\tile008.png";
                    break;
                case 10:
                    textureLink3 = @"C:\\assets\\animation\\tile009.png";
                    break;
                case 11:
                    textureLink3 = @"C:\\assets\\animation\\tile010.png";
                    break;
                case 12:
                    textureLink3 = @"C:\\assets\\animation\\tile011.png";
                    break;
                case 13:
                    textureLink3 = @"C:\\assets\\animation\\tile012.png";
                    break;
                case 14:
                    textureLink3 = @"C:\\assets\\animation\\tile013.png";
                    break;
                case 15:
                    textureLink3 = @"C:\\assets\\animation\\tile014.png";
                    break;
                case 16:
                    textureLink3 = @"C:\\assets\\animation\\tile015.png";
                    break;
                case 17:
                    textureLink3 = @"C:\\assets\\animation\\tile016.png";
                    break;
                case 18:
                    textureLink3 = @"C:\\assets\\animation\\tile017.png";
                    break;
                case 19:
                    textureLink3 = @"C:\\assets\\animation\\tile018.png";
                    break;
                case 20:
                    textureLink3 = @"C:\\assets\\animation\\tile019.png";
                    break;
                case 21:
                    textureLink3 = @"C:\\assets\\animation\\tile020.png";
                    break;
                case 22:
                    textureLink3 = @"C:\\assets\\animation\\tile021.png";
                    break;
                case 23:
                    textureLink3 = @"C:\\assets\\animation\\tile022.png";
                    break;
                case 24:
                    textureLink3 = @"C:\\assets\\animation\\tile023.png";
                    break;
                case 25:
                    textureLink3 = @"C:\\assets\\animation\\tile024.png";
                    break;
                case 26:
                    textureLink3 = @"C:\\assets\\animation\\tile025.png";
                    break;
                case 28:
                    textureLink3 = @"C:\\assets\\animation\\tile026.png";
                    break;
                case 29:
                    textureLink3 = @"C:\\assets\\animation\\tile027.png";
                    break;
                case 30:
                    textureLink3 = @"C:\\assets\\animation\\tile028.png";
                    break;
                case 31:
                    textureLink3 = @"C:\\assets\\animation\\tile029.png";
                    break;
                default:
                    break;
            }
        }
    }
}
