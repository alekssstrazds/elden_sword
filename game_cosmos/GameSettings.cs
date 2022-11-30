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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace game_cosmos
{
    public partial class GameSettings : Form
    {
        public float selectedSpeed { get; set; }
        public int selectedMaxEnemies { get; set; }

        public GameSettings()
        {
            InitializeComponent();
            this.selectedMaxEnemies = int.Parse(textBox1.Text);
            this.selectedSpeed = float.Parse(textBox2.Text);
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
            SoundPlayer theme = new SoundPlayer(@"C:\\assets\\Theme.wav");
            theme.Load();
            theme.Play();
            theme.PlayLooping();
    
            this.selectedSpeed = float.Parse(textBox2.Text);
            this.selectedMaxEnemies = int.Parse(textBox1.Text);
            comboBox1.SelectedIndex = 1;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                this.selectedSpeed = float.Parse(textBox2.Text);
                Console.WriteLine(selectedSpeed);
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && textBox2.Text.IndexOf('.') > -1)
            {
                this.selectedSpeed = float.Parse(textBox2.Text);
                Console.WriteLine(selectedSpeed);
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "1";
            }
            else
            {
                this.selectedMaxEnemies = int.Parse(textBox1.Text);
                Console.WriteLine(selectedSpeed);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "1.0";
            } 
            else
            {
                this.selectedSpeed = float.Parse(textBox2.Text);
                Console.WriteLine(selectedSpeed);
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                this.selectedMaxEnemies = int.Parse(textBox1.Text);
                Console.WriteLine(selectedMaxEnemies);
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "3";
                textBox2.Text = "3.5";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "5";
                textBox2.Text = "7.0";
            } 
            else if(comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = "7";
                textBox2.Text = "10.0";
            }
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
