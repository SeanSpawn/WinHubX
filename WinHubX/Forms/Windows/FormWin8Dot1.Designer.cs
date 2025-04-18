namespace WinHubX.Forms.Windows
{
    partial class FormWin8Dot1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWin8Dot1));
            lblHashInfo = new Label();
            btnInfoWin8dot1Lite = new Label();
            lblInfoWin8dot1Lite = new Label();
            btnWin8dot1Lite64 = new Button();
            btnWin8dot1Lite32 = new Button();
            lblWin8dot1Lite = new Label();
            lblInfoWin8dot1AIO = new Label();
            btnWin8dot1AIO64 = new Button();
            btnWin8dot1AIO32 = new Button();
            lblWin8dot1AIO = new Label();
            pictureBox1 = new PictureBox();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblHashInfo
            // 
            resources.ApplyResources(lblHashInfo, "lblHashInfo");
            lblHashInfo.ForeColor = Color.Coral;
            lblHashInfo.Name = "lblHashInfo";
            // 
            // btnInfoWin8dot1Lite
            // 
            resources.ApplyResources(btnInfoWin8dot1Lite, "btnInfoWin8dot1Lite");
            btnInfoWin8dot1Lite.Cursor = Cursors.Hand;
            btnInfoWin8dot1Lite.ForeColor = Color.Coral;
            btnInfoWin8dot1Lite.Name = "btnInfoWin8dot1Lite";
            btnInfoWin8dot1Lite.Click += btnInfoWin8dot1Lite_Click;
            // 
            // lblInfoWin8dot1Lite
            // 
            resources.ApplyResources(lblInfoWin8dot1Lite, "lblInfoWin8dot1Lite");
            lblInfoWin8dot1Lite.ForeColor = Color.Coral;
            lblInfoWin8dot1Lite.Name = "lblInfoWin8dot1Lite";
            // 
            // btnWin8dot1Lite64
            // 
            resources.ApplyResources(btnWin8dot1Lite64, "btnWin8dot1Lite64");
            btnWin8dot1Lite64.Cursor = Cursors.Hand;
            btnWin8dot1Lite64.FlatAppearance.BorderSize = 0;
            btnWin8dot1Lite64.ForeColor = Color.White;
            btnWin8dot1Lite64.Name = "btnWin8dot1Lite64";
            btnWin8dot1Lite64.UseVisualStyleBackColor = true;
            btnWin8dot1Lite64.MouseUp += btnWin8dot1Lite64_MouseUp;
            // 
            // btnWin8dot1Lite32
            // 
            resources.ApplyResources(btnWin8dot1Lite32, "btnWin8dot1Lite32");
            btnWin8dot1Lite32.Cursor = Cursors.Hand;
            btnWin8dot1Lite32.FlatAppearance.BorderSize = 0;
            btnWin8dot1Lite32.ForeColor = Color.White;
            btnWin8dot1Lite32.Name = "btnWin8dot1Lite32";
            btnWin8dot1Lite32.UseVisualStyleBackColor = true;
            btnWin8dot1Lite32.MouseUp += btnWin8dot1Lite32_MouseUp;
            // 
            // lblWin8dot1Lite
            // 
            resources.ApplyResources(lblWin8dot1Lite, "lblWin8dot1Lite");
            lblWin8dot1Lite.ForeColor = Color.White;
            lblWin8dot1Lite.Name = "lblWin8dot1Lite";
            // 
            // lblInfoWin8dot1AIO
            // 
            resources.ApplyResources(lblInfoWin8dot1AIO, "lblInfoWin8dot1AIO");
            lblInfoWin8dot1AIO.ForeColor = Color.Coral;
            lblInfoWin8dot1AIO.Name = "lblInfoWin8dot1AIO";
            // 
            // btnWin8dot1AIO64
            // 
            resources.ApplyResources(btnWin8dot1AIO64, "btnWin8dot1AIO64");
            btnWin8dot1AIO64.Cursor = Cursors.Hand;
            btnWin8dot1AIO64.FlatAppearance.BorderSize = 0;
            btnWin8dot1AIO64.ForeColor = Color.White;
            btnWin8dot1AIO64.Name = "btnWin8dot1AIO64";
            btnWin8dot1AIO64.UseVisualStyleBackColor = true;
            btnWin8dot1AIO64.MouseUp += btnWin8dot1AIO64_MouseUp;
            // 
            // btnWin8dot1AIO32
            // 
            resources.ApplyResources(btnWin8dot1AIO32, "btnWin8dot1AIO32");
            btnWin8dot1AIO32.Cursor = Cursors.Hand;
            btnWin8dot1AIO32.FlatAppearance.BorderSize = 0;
            btnWin8dot1AIO32.ForeColor = Color.White;
            btnWin8dot1AIO32.Name = "btnWin8dot1AIO32";
            btnWin8dot1AIO32.UseVisualStyleBackColor = true;
            btnWin8dot1AIO32.MouseUp += btnWin8dot1AIO32_MouseUp;
            // 
            // lblWin8dot1AIO
            // 
            resources.ApplyResources(lblWin8dot1AIO, "lblWin8dot1AIO");
            lblWin8dot1AIO.ForeColor = Color.White;
            lblWin8dot1AIO.Name = "lblWin8dot1AIO";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.pngWin8dot1;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
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
            // FormWin8Dot1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(lblHashInfo);
            Controls.Add(btnInfoWin8dot1Lite);
            Controls.Add(lblInfoWin8dot1Lite);
            Controls.Add(btnWin8dot1Lite64);
            Controls.Add(btnWin8dot1Lite32);
            Controls.Add(lblWin8dot1Lite);
            Controls.Add(lblInfoWin8dot1AIO);
            Controls.Add(btnWin8dot1AIO64);
            Controls.Add(btnWin8dot1AIO32);
            Controls.Add(lblWin8dot1AIO);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWin8Dot1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHashInfo;
        private Label btnInfoWin8dot1Lite;
        private Label lblInfoWin8dot1Lite;
        private Button btnWin8dot1Lite64;
        private Button btnWin8dot1Lite32;
        private Label lblWin8dot1Lite;
        private Label lblInfoWin8dot1AIO;
        private Button btnWin8dot1AIO64;
        private Button btnWin8dot1AIO32;
        private Label lblWin8dot1AIO;
        private PictureBox pictureBox1;
        private Button btnBack;
    }
}