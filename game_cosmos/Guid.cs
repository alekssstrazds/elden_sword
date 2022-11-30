using SharpGL.SceneGraph;
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

namespace game_cosmos
{
    public partial class Guid : Form
    {
        public Guid()
        {
            InitializeComponent();
        }
        private void Guid_Load(object sender, EventArgs e)
        {
            SoundPlayer theme = new SoundPlayer(@"C:\\assets\\Theme.wav");
            theme.Load();
            theme.Play();
            theme.PlayLooping();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var menuWindow = new GameMenu();
            menuWindow.Closed += (s, args) => this.Close();
            menuWindow.Show();
        }
    }
}
