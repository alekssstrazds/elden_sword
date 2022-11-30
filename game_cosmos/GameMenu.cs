using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static game_cosmos.Audio;

namespace game_cosmos
{
    public partial class GameMenu : Form
    {
        public SoundPlayer theme = new SoundPlayer(@"C:\\assets\\Theme.wav");
        public GameMenu()
        {
            InitializeComponent();
        }
        private void GameMenu_Load(object sender, EventArgs e)
        {
            theme.Load();
            theme.Play();
            theme.PlayLooping();
        }
        private void keyDownEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                theme.Stop();
                this.Hide();
                var gameWindow = new Form1();
                gameWindow.Closed += (s, args) => this.Close();
                gameWindow.Show();
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            theme.Stop();
            this.Hide();
            var gameWindow = new Form1();
            gameWindow.Closed += (s, args) => this.Close();
            gameWindow.Show();
        }
        private void clickGuid(object sender, EventArgs e)
        {
            this.Hide();
            var guidWindow = new Guid();
            guidWindow.Closed += (s, args) => this.Close();
            guidWindow.Show();
        }

        private void clickGameSettings(object sender, EventArgs e)
        {
            this.Hide();
            var settingsWindow = new GameSettings();
            settingsWindow.Closed += (s, args) => this.Close();
            settingsWindow.Show();
        }
    }
}
