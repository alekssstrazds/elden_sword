using System;
using SharpGL;
using SharpGL.SceneGraph;
using System.Windows.Forms;
using SharpGL.SceneGraph.Assets;
using System.Linq.Expressions;
using SharpGL.WPF;
using System.Collections.Generic;
using game_cosmos;
using System.Media;
using System.Linq;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Media;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using SharpGL.SceneGraph.Lighting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Timers;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;
using System.Collections;
using static game_cosmos.Audio;
using NAudio.Wave;
using elden_sword.Properties;

namespace game_cosmos
{
    public partial class Form1 : Form
    {
        List<Enemie> enemies = new List<Enemie>();
        List<Player> players = new List<Player>();
        List<HealthBar> healthbars = new List<HealthBar>();
        List<Background> screens = new List<Background>();
        List<DeathEffect> effects = new List<DeathEffect>();
        public GameSettings gameSettings = new GameSettings();

        //Movment
        public float speed;
        public float xDistance;
        public float yDistance;
        public float hypotenuse;
        public float deltaTime;
        public bool getTime = true;
        public float x = 0.0f;
        public float y = 0.0f;
        //Audio
        String background = @"C:\\assets\\Roundtable_Hold.wav";
        String hit = @"C:\\assets\\SwordHitEffect.wav";
        String theme = @"C:\\assets\\Theme.wav";
        String hitEnemieSFX = @"C:\\assets\\hitEnemieSFX.wav";
        public bool audioTheme = false;
        public WaveOut waveOut;
        public bool hitSFX = false;
        //Window
        public bool check = true;
        //Level
        public int level = 0;
        public int timer = 0;
        //Player
        public bool isDeath = false;
        public int timerAnimation = 0;
        public int timerDeathScreen = 0;
        public int fixedTime = 0;
        public int playerScore = 0;
        //enemies
        public int enemiesInc = 0;
        public int maxEnemies;
        //boss
        public bool regenBossShield = false;
        public int timerRegenBoss = 0;
        //death screen
        public float alpha = 0f;
        //Key press accuracy
        public int keysPressed = 0;
        public int correctKeysPresed = 0;
        public double accuraciesScore = 0.0;
        public bool triggerCorrect = true;
        //TODO
        //1.Fix enemies spawn
        //2.Fix textures overlap
        //3.Fix game menu
        //4. Optimize fps drops
        public Form1()
        {
            InitializeComponent();
            OpenGL gl = this.openGLControl1.OpenGL;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Minimum width = 1280, Minimum height = 960;
            //this.MinimumSize = new Size(1297, 996);
            //Maximum width = 800, Maximum height= unlimited
            //this.MaximumSize = new Size(1920, 1080);
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            /*while (check != false)
            {
                int formHeight = this.Height;
                int formWidth = this.Width;
                windowResizeHandler(gl, formHeight, formWidth);
            }*/
        }
        private void openGLControl1_Load(object sender, EventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);

            gl.Rotate(180, 0, 0, 1);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            this.speed = gameSettings.selectedSpeed;
            this.maxEnemies = gameSettings.selectedMaxEnemies;
            createPlayer(gl);
            createEnemies(gl, enemiesInc); 
            createHealthBar(gl);
            createBackground(gl);
            createDeathEffect(gl);
            PlayAudio(background);
        }
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            gl.Rotate(180, 0, 0, 1);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            showBackground(gl);
            showPlayers(gl);
            catchPlayer();
            showEnemies(gl);
            showHealthBars(gl);
            showLabels(gl);
            showStats(gl);
            showDeaths(gl);
            
            if (isDeath != false && timerAnimation > 20)
            {
                gl.Disable(OpenGL.GL_TEXTURE_2D);
                showDeathScreen(gl);
                if(timerAnimation > 20 && screens.Count != 0)
                {
                    screens.Clear();
                    enemies.Clear();
                    healthbars.Clear();
                    effects.Clear();
                }
            }
            if(audioTheme == true)
            {
                PlayAudio(theme);
                audioTheme = false;
            }
            if (enemies.Count == 0 && isDeath != true)
            {
                level++;
                if(maxEnemies > enemiesInc)
                {
                    enemiesInc++;
                } 
                createEnemies(gl, enemiesInc);
                speed += 0.1f;
                if(level >= 3)
                {
                    if (level % 2 == 0)
                    {
                        if (maxEnemies > enemiesInc)
                        {
                            enemiesInc++;
                        }
                        createEnemieBoss(gl, 6);
                    }
                }
            }
            
        }
        public void PlayAudio(String audio)
        {
            if (waveOut == null)
            {
                WaveFileReader reader = new WaveFileReader(audio);
                LoopStream loop = new LoopStream(reader);
                waveOut = new WaveOut();
                waveOut.Init(loop);
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                PlayAudio(audio);
            }
        }
        public void showLabels(OpenGL gl)
        {
            foreach(Enemie enemie in enemies.ToList())
            {
                gl.PushMatrix();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
                gl.Translate(enemie.cX, enemie.cY + 0.5f, -6.5f);
                gl.Color(255.0f, 255.0f, 255.0f);
                gl.Scale(0.2, 0.2, 0.2);
                gl.DrawText3D("Drone Range Pro Bold", 1.0f, 0.0f, 0.0f, enemie.genEnemieShield);
                gl.PopMatrix();
            }
        }
        //Bacground and death screen
        public void createDeathScreen(OpenGL gl, float alpha)
        {
            Texture death_screen_texture = new Texture();
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(0.0f, 0.0f, -5.0f);
            gl.Rotate(180, 1, 0, 0);
            gl.Scale(0.4f, 0.4f, 0.4f);
            gl.Color(1.0f, 1.0f, 1.0f, alpha);

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            death_screen_texture.Create(gl, @"C:\\assets\\died.png");
            death_screen_texture.Bind(gl);
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
        public void showDeathScreen(OpenGL gl)
        {
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            createDeathScreen(gl, alpha);
            gl.PushMatrix();
            gl.DrawText3D("Drone Range Pro Bold", 18.0f, 1.0f, 1.0f, "");
            gl.Color(202, 21, 26, 200);
            gl.DrawText(this.Width - 900, this.Height - 400, 125, 125, 125, "Drone Range Pro Bold", 24.0f, "TOTAL SCORE..........................");
            gl.DrawText(this.Width - 500, this.Height - 400, 255, 255, 255, "Drone Range Pro Bold", 24.0f, (playerScore + calcKeysAccuraciesScore(playerScore)).ToString() + "....");
            gl.DrawText(this.Width - 900, this.Height - 425, 125, 125, 125, "Drone Range Pro Bold", 24.0f, "PRESSED KEYS ACCUARCY....");
            gl.DrawText(this.Width - 500, this.Height - 425, 255, 255, 255, "Drone Range Pro Bold", 24.0f, Math.Round(accuraciesScore * 100, 2) + "%...");
            gl.DrawText(this.Width - 900, this.Height - 450, 125, 125, 125, "Drone Range Pro Bold", 24.0f, "TOTAL TIME..............................");
            gl.DrawText(this.Width - 500, this.Height - 450, 255, 255, 255, "Drone Range Pro Bold", 24.0f, (fixedTime).ToString() + "....");
            gl.PopMatrix();
        }
        public void createBackground(OpenGL gl)
        {
            Background background = new Background();
            background.alpha = 255.0f;
            screens.Add(background);
        }
        public void showBackground(OpenGL gl)
        {
            foreach (Background background in screens)
            {
                background.showScreen(gl);
            }
        }
        //Create Boss
        public void createEnemieBoss(OpenGL gl, int enemieShield)
        {
            float x1 = enemies[enemies.Count - 1].cX;
            if (x1 >= 1.0f) {
                x1 += 3.0f;
            } else x1 -= 3.0f;
            Enemie enemie = new Enemie(x1, enemies[enemies.Count - 1].cY, -6.0f, 1.0f, 0.0f, 0.7f, enemieShield);
            if(enemie.cX >= 1.0f)
            {
                enemie.rotX = 0;
                enemie.rotZ = 1;
                enemie.angle = 180;
            } else
            {
                enemie.rotX = 1;
                enemie.rotZ = 0;
                enemie.angle = 180;
            }
            enemie.izmeers = 0.8f;
            enemies.Add(enemie);
            enemie.showEnemieType(1);
        }
        //Movment
        public void movment(int i)
        {
            if (players.Count != 0)
            {
                xDistance = players[0].cX - enemies[i].cX;
                yDistance = players[0].cY - enemies[i].cY;
                enemies[i].cX += speed * deltaTime * (xDistance / distance(xDistance, yDistance));
                enemies[i].cY += speed * deltaTime * (yDistance / distance(xDistance, yDistance));

                DateTime time1 = DateTime.Now;
                DateTime time2 = DateTime.Now;
                while (getTime != false)
                {
                    time2 = DateTime.Now;
                    deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
                    time1 = time2;
                    getTime = false;
                }
            }
            if (regenBossShield != false && enemies[i].enemieSh == 6)
            {
                enemies[i].cX = enemies[i].cX;
                enemies[i].cY = enemies[i].cY;
            }
        }

        public float distance(float xDistance, float yDistance)
        {
            return hypotenuse = (float)Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }
        //Create Player
        public void createPlayer(OpenGL gl)
        {
            Player mainCharacter = new Player();
            players.Add(mainCharacter);
        }
        public void showPlayers(OpenGL gl)
        {
            foreach (Player player in players.ToList())
            {
                player.showPlayer(gl);
                playerScore = player.score;
            }
        }
        //Create enemies
        public void createEnemie(OpenGL gl, int enemieType)
        {
            Enemie enemie = new Enemie();
            enemie.showEnemieType(enemieType);
            enemies.Add(enemie);
        }
        public void createEnemies(OpenGL gl, int index)
        {
            for (int i = 0; i < index; i++)
            {
                createEnemie(gl, 0);
                changeEnemiePosition(gl, i);
            }
        }
        public void showEnemies(OpenGL gl)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].showEnemie(gl);
                movment(i);
            }
        }
        //Create health bar
        public void createHealthBar(OpenGL gl)
        {
            HealthBar healthBar = new HealthBar();
            healthbars.Add(healthBar);
        }
        public void showHealthBars(OpenGL gl)
        {
            foreach (HealthBar healthBar in healthbars)
            {
                healthBar.showHealthStatus(players[0].player_hp);
                healthBar.showHealthBar(gl);
            }
        }
        //Create death effect
        public void createDeathEffect(OpenGL gl)
        {
            DeathEffect deathEffect = new DeathEffect();
            effects.Add(deathEffect);
        }
        public void showDeaths(OpenGL gl)
        {
            foreach(DeathEffect effect in effects.ToList())
            {
                effect.showDeath(gl);
            }
        }
        //Change enemie position
        public float getNextPointX(float lastP, float distanceMin, float distanceMax)
        {
            float nextP;
            Random random = new Random();
            float diff = distanceMax - distanceMin;
            return nextP = (float)(random.NextDouble() * diff) + distanceMin + lastP;
        }
        public void changeEnemiePosition(OpenGL gl, int index)
        {
            //Change x value
            if (index >= 2)
            {
                if (enemies.Count % 2 != 0)
                {
                    x = getNextPointX(enemies[index - 1].cX, 1.0f, 4.0f);
                    y = getNextPointX(enemies[index - 1].cY, 0.0f, -4.0f);
                }
                else if (enemies.Count % 2 == 0)
                {
                    x = getNextPointX(enemies[index - 1].cX, -1.0f, -4.0f);
                    y = getNextPointX(enemies[index - 1].cY, 0.5f, -4.0f);
                } 
            }
            else
            {
                x += 1.5f;
                y -= 1.5f;
            }
            if (x >= 1.0f && x <= 7.0f)
            {
                enemies[index].cX = x;
                enemies[index].rotX = 0;
                enemies[index].rotZ = 1;
                enemies[index].angle = 180;
            }
            else if (x <= -1.0f && x >= -7.0f)
            {
                enemies[index].cX = x;
            }
            if (y <= 0.0f && y >= -7.0f)
            {
                enemies[index].cY = y;
            }
        }
        //Catch player function
        public void catchPlayer()
        {
            foreach(Enemie enemie in enemies.ToList())
            {
                if (enemie.cX >= -0.1f && enemie.cX <= 0.1f && enemie.cY >= -0.1f && enemie.cY <= 0.1f) 
                {
                    AudioPlaybackEngine.Instance.PlaySound(hit);
                    if (enemie.enemieSh == 4)
                    {
                        players[0].player_hp -= 1;
                        enemies.Remove(enemie);
                        healthbars[0].showHealthStatus(players[0].player_hp);
                    }
                    else if(enemie.enemieSh == 6)
                    {
                        players[0].player_hp -= 2;
                        enemies.Remove(enemie);
                        healthbars[0].showHealthStatus(players[0].player_hp);
                    }
                    if (players[0].player_hp <= 0)
                    {
                        isDeath = true;
                        audioTheme = true;
                        fixedTime = timer;
                        enemies.Clear();
                    }
                }
            }    
        }
        //Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isDeath != true)
            {
                timer++;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isDeath != false && timerAnimation <= 30)
            {
                foreach(DeathEffect effect in effects.ToList())
                {
                    effect.showDeathAnimationStatus(timerAnimation);
                    timerAnimation++;
                }
            }
            if (timerAnimation > 20 && timerDeathScreen <= 1000)
            {
                if(alpha != 255.0f)
                {
                    alpha += 0.255f;
                    timerDeathScreen++;
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if(regenBossShield != false && isDeath != true)
            {
                timerRegenBoss++;
                Console.WriteLine("Regen = " + timerRegenBoss + "sec");
                if(timerRegenBoss >= 5)
                {
                    regenBossShield = false;
                    timerRegenBoss = 0;
                }
            }
        }
        //Statistic
        public void showStats(OpenGL gl)
        {
            int scoreNum = 0;
            gl.DrawText3D("", 0.0f, 0.0f, 0.0f, "");
            gl.DrawText(this.Width - 250, 50, 255, 255, 255, "Drone Range Pro Bold", 18.0f, "SCORE");
            gl.DrawText(this.Width - 250, 30, 255, 255, 255, "Drone Range Pro Bold", 18.0f, (scoreNum + players[0].score).ToString());
            gl.DrawText(this.Width - 150, 50, 255, 255, 255, "Drone Range Pro Bold", 18.0f, "LEVEL");
            gl.DrawText(this.Width - 150, 30, 255, 255, 255, "Drone Range Pro Bold", 18.0f, (level).ToString());
            gl.DrawText(this.Width - 350, 50, 255, 255, 255, "Drone Range Pro Bold", 18.0f, "TIME");
            gl.DrawText(this.Width - 350, 30, 255, 255, 255, "Drone Range Pro Bold", 18.0f, (timer).ToString());
        }
        public int calcKeysAccuraciesScore(int score)
        {
            
            if(playerScore == 0)
            {
                this.accuraciesScore = 0;
                return 0;
            } else
            {
                this.accuraciesScore = (double)correctKeysPresed / keysPressed;
                return (int)(accuraciesScore * (score / 4));
            }
        }
        //Check keyboard input function
        public void checkIfInputExist(String input)
        {
            keysPressed++;
            triggerCorrect = true;
            foreach (Enemie enemie in enemies.ToList())
            {
                if (enemie.genEnemieShield.Count() > 0)
                {
                    if (Equals(enemie.genEnemieShield.Substring(0, 1), input) == true)
                    {
                        if(triggerCorrect != false)
                        {
                            correctKeysPresed++;
                            triggerCorrect = false;
                        }
                        String newLabel = enemie.genEnemieShield.Remove(0, 1);
                        enemie.genEnemieShield = newLabel;
                        players[0].score += 25;
                        AudioPlaybackEngine.Instance.PlaySound(hitEnemieSFX);
                        if (enemie.enemieSh == 6 && enemie.genEnemieShield.Count() == 0)
                        {
                            Random rand = new Random();
                            int number = rand.Next(10);
                            if(number >= 5)
                            {
                                timerRegenBoss = 0;
                                regenBossShield = true;
                                enemie.enemieSh = 4;
                                enemie.genSymbolsE(enemie.enemieSh);
                            } else
                            {
                                if (players[0].player_hp < 3)
                                {
                                    players[0].player_hp++;
                                    healthbars[0].showHealthStatus(players[0].player_hp);
                                }
                                enemies.Remove(enemie);
                                players[0].score += 250;
                            }
                        }
                        if (enemie.enemieSh == 4 && enemie.genEnemieShield.Count() == 0)
                        {
                            enemies.Remove(enemie);
                            players[0].score += 100;
                        }
                    }
                }
                    
            }
        }
        //Keyboard input
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;

            if (e.KeyCode == Keys.Q)
            {
                checkIfInputExist("Q");
            }
            if (e.KeyCode == Keys.W)
            { 
                checkIfInputExist("W"); 
            }
            if (e.KeyCode == Keys.E)
            {
                checkIfInputExist("E");
            }
            if (e.KeyCode == Keys.R)
            {   
                checkIfInputExist("R");
            }
            if (e.KeyCode == Keys.T)
            {
                checkIfInputExist("T");
            }
            if (e.KeyCode == Keys.Y)
            {
                checkIfInputExist("Y");
            }
            if (e.KeyCode == Keys.U)
            {
                checkIfInputExist("U");
            }
            if (e.KeyCode == Keys.I)
            {
                checkIfInputExist("I");
            }
            if (e.KeyCode == Keys.O)
            {
                checkIfInputExist("O");
            }
            if (e.KeyCode == Keys.P)
            {
                checkIfInputExist("P");
            }
            if (e.KeyCode == Keys.A)
            {
                checkIfInputExist("A");
            }
            if (e.KeyCode == Keys.S)
            {
                checkIfInputExist("S");
            }
            if(e.KeyCode == Keys.D)
            {
                checkIfInputExist("D");
            }
            if (e.KeyCode == Keys.F)
            {
                checkIfInputExist("F");
            }
            if (e.KeyCode == Keys.G)
            {
                checkIfInputExist("G");
            }
            if (e.KeyCode == Keys.H)
            {
                checkIfInputExist("H");
            }
            if (e.KeyCode == Keys.J)
            {
                checkIfInputExist("J");
            }
            if (e.KeyCode == Keys.K)
            {
                checkIfInputExist("K");
            }
            if (e.KeyCode == Keys.L)
            {
                checkIfInputExist("L");
            }
            if (e.KeyCode == Keys.Z)
            {
                checkIfInputExist("Z");
            }
            if (e.KeyCode == Keys.X)
            {
                checkIfInputExist("X");
            }
            if (e.KeyCode == Keys.C)
            {
                checkIfInputExist("C");
            }
            if (e.KeyCode == Keys.V)
            {
                checkIfInputExist("V");
            }
            if (e.KeyCode == Keys.B)
            {
                checkIfInputExist("B");
            }
            if (e.KeyCode == Keys.N)
            {
                checkIfInputExist("N");
            }
            if (e.KeyCode == Keys.M)
            {
                checkIfInputExist("M");
            }
            if (e.KeyCode == Keys.F4)
            {
                Console.WriteLine(check);
                check = true;
                if(check != false)
                {
                    if(this.Width == 1920 && this.Height == 1280 && check == true)
                    {
                        this.Width = 1280;
                        this.Height = 960;
                        int glHeight = this.Height;
                        int glWidth = this.Width;
                        windowResizeHandler(gl, glHeight, glWidth);
                        check = false;
                    }
                    else if(this.Width != 1920 && this.Height != 1280 && check == true)
                    {
                        this.Width = 1920;
                        this.Height = 1280;
                        int glHeight = this.Height;
                        int glWidth = this.Width;
                        windowResizeHandler(gl, glHeight, glWidth);
                        check = false;
                    }
                }
            }
        }
        //Resize screen (not working)
        void windowResizeHandler(OpenGL gl, int windowWidth, int windowHeight)
        {
            float aspectRatio = (float)(windowWidth) / windowHeight;

            if (windowWidth > windowHeight)
            {
                gl.Ortho(-2.0f * aspectRatio, 2.0f * aspectRatio, -2.0f, 2.0f, -1.0f, 1.0f);
            }
            else
            {
                gl.Ortho(-2.0f, 2.0f, -2.0f, 2.0f, -1.0f, 1.0f);
            }
            gl.Viewport(0, 0, windowWidth, windowHeight);
            //gl.Scissor(0, 0, windowWidth, windowHeight);
        }
    }
}



