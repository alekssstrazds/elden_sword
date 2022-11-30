namespace game_cosmos
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 60;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Margin = new System.Windows.Forms.Padding(0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(1280, 720);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.Load += new System.EventHandler(this.openGLControl1_Load);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.openGLControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elden Sword";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);

        }

        private SharpGL.OpenGLControl openGLControl1;

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}

