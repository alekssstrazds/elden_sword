namespace game_cosmos
{
    partial class GameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonGuid = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Yellow;
            this.buttonStart.Location = new System.Drawing.Point(563, 296);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(162, 45);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Press ENTER";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownEnter);
            // 
            // buttonGuid
            // 
            this.buttonGuid.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonGuid.FlatAppearance.BorderSize = 0;
            this.buttonGuid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuid.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuid.ForeColor = System.Drawing.Color.Yellow;
            this.buttonGuid.Location = new System.Drawing.Point(563, 347);
            this.buttonGuid.Name = "buttonGuid";
            this.buttonGuid.Size = new System.Drawing.Size(162, 45);
            this.buttonGuid.TabIndex = 1;
            this.buttonGuid.Text = "Guid";
            this.buttonGuid.UseVisualStyleBackColor = false;
            this.buttonGuid.Click += new System.EventHandler(this.clickGuid);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Drone Ranger Pro Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.Yellow;
            this.buttonSettings.Location = new System.Drawing.Point(563, 398);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(162, 45);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Game Settings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.clickGameSettings);
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonGuid);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elden Sword";
            this.Load += new System.EventHandler(this.GameMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonGuid;
        private System.Windows.Forms.Button buttonSettings;
    }
}