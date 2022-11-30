namespace game_cosmos
{
    partial class GameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(13, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximum number of enemy :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(315, 191);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(646, 383);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 10);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Back";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(85, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(377, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "GAME SETTINGS";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(319, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enemies start speed :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(251, 123);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 200, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "7.0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(13, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "DIFICULTY :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.comboBox1.Location = new System.Drawing.Point(135, 149);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "Normal";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameSettings";
            this.Text = "Elden Sword";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}