namespace WinHubX
{
    partial class FormTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTools));
            btnKasperky = new Button();
            btnWimTK = new Button();
            btnRufus = new Button();
            btnDaRT = new Button();
            btnMPM = new Button();
            btnRSTDriver = new Button();
            SuspendLayout();
            // 
            // btnKasperky
            // 
            resources.ApplyResources(btnKasperky, "btnKasperky");
            btnKasperky.Cursor = Cursors.Hand;
            btnKasperky.FlatAppearance.BorderSize = 0;
            btnKasperky.ForeColor = Color.White;
            btnKasperky.Name = "btnKasperky";
            btnKasperky.UseVisualStyleBackColor = true;
            btnKasperky.Click += btnKasperky_Click;
            // 
            // btnWimTK
            // 
            resources.ApplyResources(btnWimTK, "btnWimTK");
            btnWimTK.Cursor = Cursors.Hand;
            btnWimTK.FlatAppearance.BorderSize = 0;
            btnWimTK.ForeColor = Color.White;
            btnWimTK.Image = Properties.Resources.extWIMToolkit;
            btnWimTK.Name = "btnWimTK";
            btnWimTK.UseVisualStyleBackColor = true;
            btnWimTK.Click += btnWimTK_Click;
            // 
            // btnRufus
            // 
            resources.ApplyResources(btnRufus, "btnRufus");
            btnRufus.Cursor = Cursors.Hand;
            btnRufus.FlatAppearance.BorderSize = 0;
            btnRufus.ForeColor = Color.White;
            btnRufus.Image = Properties.Resources.Rufus_4Lite;
            btnRufus.Name = "btnRufus";
            btnRufus.UseVisualStyleBackColor = true;
            btnRufus.Click += btnRufus_Click;
            // 
            // btnDaRT
            // 
            resources.ApplyResources(btnDaRT, "btnDaRT");
            btnDaRT.Cursor = Cursors.Hand;
            btnDaRT.FlatAppearance.BorderSize = 0;
            btnDaRT.ForeColor = Color.White;
            btnDaRT.Image = Properties.Resources.pngDaRT;
            btnDaRT.Name = "btnDaRT";
            btnDaRT.UseVisualStyleBackColor = true;
            btnDaRT.Click += btnDaRT_Click;
            // 
            // btnMPM
            // 
            resources.ApplyResources(btnMPM, "btnMPM");
            btnMPM.Cursor = Cursors.Hand;
            btnMPM.FlatAppearance.BorderSize = 0;
            btnMPM.ForeColor = Color.White;
            btnMPM.Image = Properties.Resources.pngMPM;
            btnMPM.Name = "btnMPM";
            btnMPM.UseVisualStyleBackColor = true;
            btnMPM.Click += btnMPM_Click;
            // 
            // btnRSTDriver
            // 
            resources.ApplyResources(btnRSTDriver, "btnRSTDriver");
            btnRSTDriver.Cursor = Cursors.Hand;
            btnRSTDriver.FlatAppearance.BorderSize = 0;
            btnRSTDriver.ForeColor = Color.White;
            btnRSTDriver.Name = "btnRSTDriver";
            btnRSTDriver.UseVisualStyleBackColor = true;
            btnRSTDriver.Click += btnRSTDriver_Click;
            // 
            // FormTools
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(btnRSTDriver);
            Controls.Add(btnMPM);
            Controls.Add(btnDaRT);
            Controls.Add(btnRufus);
            Controls.Add(btnWimTK);
            Controls.Add(btnKasperky);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTools";
            ResumeLayout(false);
        }

        #endregion

        private Button btnKasperky;
        private Button btnWimTK;
        private Button btnRufus;
        private Button btnDaRT;
        private Button btnMPM;
        private Button btnRSTDriver;
    }
}