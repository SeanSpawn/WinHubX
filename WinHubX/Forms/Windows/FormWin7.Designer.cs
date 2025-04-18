namespace WinHubX
{
    partial class FormWin7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWin7));
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            lblWin7AiO = new Label();
            btnWin7AIO64 = new Button();
            btnWin7AIO32 = new Button();
            lblInfoWin7AIO = new Label();
            lblInfoWin7Lite = new Label();
            btnWin7Lite64 = new Button();
            btnWin7Lite32 = new Button();
            lblWin7Lite = new Label();
            btnInfoWin7Lite = new Label();
            lblHashInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Name = "btnBack";
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.pngWin7;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lblWin7AiO
            // 
            resources.ApplyResources(lblWin7AiO, "lblWin7AiO");
            lblWin7AiO.ForeColor = Color.White;
            lblWin7AiO.Name = "lblWin7AiO";
            // 
            // btnWin7AIO64
            // 
            resources.ApplyResources(btnWin7AIO64, "btnWin7AIO64");
            btnWin7AIO64.Cursor = Cursors.Hand;
            btnWin7AIO64.FlatAppearance.BorderSize = 0;
            btnWin7AIO64.ForeColor = Color.White;
            btnWin7AIO64.Name = "btnWin7AIO64";
            btnWin7AIO64.UseVisualStyleBackColor = true;
            btnWin7AIO64.MouseUp += btnWin7AIO64_MouseUp;
            // 
            // btnWin7AIO32
            // 
            resources.ApplyResources(btnWin7AIO32, "btnWin7AIO32");
            btnWin7AIO32.Cursor = Cursors.Hand;
            btnWin7AIO32.FlatAppearance.BorderSize = 0;
            btnWin7AIO32.ForeColor = Color.White;
            btnWin7AIO32.Name = "btnWin7AIO32";
            btnWin7AIO32.UseVisualStyleBackColor = true;
            btnWin7AIO32.MouseUp += btnWin7AIO32_MouseUp;
            // 
            // lblInfoWin7AIO
            // 
            resources.ApplyResources(lblInfoWin7AIO, "lblInfoWin7AIO");
            lblInfoWin7AIO.ForeColor = Color.Coral;
            lblInfoWin7AIO.Name = "lblInfoWin7AIO";
            // 
            // lblInfoWin7Lite
            // 
            resources.ApplyResources(lblInfoWin7Lite, "lblInfoWin7Lite");
            lblInfoWin7Lite.ForeColor = Color.Coral;
            lblInfoWin7Lite.Name = "lblInfoWin7Lite";
            // 
            // btnWin7Lite64
            // 
            resources.ApplyResources(btnWin7Lite64, "btnWin7Lite64");
            btnWin7Lite64.Cursor = Cursors.Hand;
            btnWin7Lite64.FlatAppearance.BorderSize = 0;
            btnWin7Lite64.ForeColor = Color.White;
            btnWin7Lite64.Name = "btnWin7Lite64";
            btnWin7Lite64.UseVisualStyleBackColor = true;
            btnWin7Lite64.MouseUp += btnWin7Lite64_MouseUp;
            // 
            // btnWin7Lite32
            // 
            resources.ApplyResources(btnWin7Lite32, "btnWin7Lite32");
            btnWin7Lite32.Cursor = Cursors.Hand;
            btnWin7Lite32.FlatAppearance.BorderSize = 0;
            btnWin7Lite32.ForeColor = Color.White;
            btnWin7Lite32.Name = "btnWin7Lite32";
            btnWin7Lite32.UseVisualStyleBackColor = true;
            btnWin7Lite32.MouseUp += btnWin7Lite32_MouseUp;
            // 
            // lblWin7Lite
            // 
            resources.ApplyResources(lblWin7Lite, "lblWin7Lite");
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Name = "lblWin7Lite";
            // 
            // btnInfoWin7Lite
            // 
            resources.ApplyResources(btnInfoWin7Lite, "btnInfoWin7Lite");
            btnInfoWin7Lite.Cursor = Cursors.Hand;
            btnInfoWin7Lite.ForeColor = Color.Coral;
            btnInfoWin7Lite.Name = "btnInfoWin7Lite";
            btnInfoWin7Lite.Click += infoWin7Lite_Click;
            // 
            // lblHashInfo
            // 
            resources.ApplyResources(lblHashInfo, "lblHashInfo");
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Name = "lblHashInfo";
            // 
            // FormWin7
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(lblHashInfo);
            Controls.Add(btnInfoWin7Lite);
            Controls.Add(lblInfoWin7Lite);
            Controls.Add(btnWin7Lite64);
            Controls.Add(btnWin7Lite32);
            Controls.Add(lblWin7Lite);
            Controls.Add(lblInfoWin7AIO);
            Controls.Add(btnWin7AIO64);
            Controls.Add(btnWin7AIO32);
            Controls.Add(lblWin7AiO);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWin7";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private PictureBox pictureBox1;
        private Label lblWin7AiO;
        private Button btnWin7AIO64;
        private Button btnWin7AIO32;
        private Label lblInfoWin7AIO;
        private Label lblInfoWin7Lite;
        private Button btnWin7Lite64;
        private Button btnWin7Lite32;
        private Label lblWin7Lite;
        private Label btnInfoWin7Lite;
        private Label lblHashInfo;
    }
}