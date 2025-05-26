namespace WinHubX
{
    partial class FormWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWin));
            btnWin7 = new Button();
            btnWin8dot1 = new Button();
            btnWin11 = new Button();
            btnWin10 = new Button();
            btnWinLive = new Button();
            btnWin12 = new Button();
            lblInfoWin12 = new Label();
            btnAttivaWin = new Button();
            btnCambioEdizione = new Button();
            SuspendLayout();
            // 
            // btnWin7
            // 
            resources.ApplyResources(btnWin7, "btnWin7");
            btnWin7.Cursor = Cursors.Hand;
            btnWin7.FlatAppearance.BorderSize = 0;
            btnWin7.ForeColor = Color.White;
            btnWin7.Image = Properties.Resources.pngWin7;
            btnWin7.Name = "btnWin7";
            btnWin7.UseVisualStyleBackColor = true;
            btnWin7.Click += btnWin7_Click;
            // 
            // btnWin8dot1
            // 
            resources.ApplyResources(btnWin8dot1, "btnWin8dot1");
            btnWin8dot1.Cursor = Cursors.Hand;
            btnWin8dot1.FlatAppearance.BorderSize = 0;
            btnWin8dot1.ForeColor = Color.White;
            btnWin8dot1.Image = Properties.Resources.pngWin8dot1;
            btnWin8dot1.Name = "btnWin8dot1";
            btnWin8dot1.UseVisualStyleBackColor = true;
            btnWin8dot1.Click += btnWin8dot1_Click;
            // 
            // btnWin11
            // 
            resources.ApplyResources(btnWin11, "btnWin11");
            btnWin11.Cursor = Cursors.Hand;
            btnWin11.FlatAppearance.BorderSize = 0;
            btnWin11.ForeColor = Color.White;
            btnWin11.Image = Properties.Resources.pngWindows11;
            btnWin11.Name = "btnWin11";
            btnWin11.UseVisualStyleBackColor = true;
            btnWin11.Click += btnWin11_Click;
            // 
            // btnWin10
            // 
            resources.ApplyResources(btnWin10, "btnWin10");
            btnWin10.Cursor = Cursors.Hand;
            btnWin10.FlatAppearance.BorderSize = 0;
            btnWin10.ForeColor = Color.White;
            btnWin10.Image = Properties.Resources.pngWin10;
            btnWin10.Name = "btnWin10";
            btnWin10.UseVisualStyleBackColor = true;
            btnWin10.Click += btnWin10_Click;
            // 
            // btnWinLive
            // 
            resources.ApplyResources(btnWinLive, "btnWinLive");
            btnWinLive.Cursor = Cursors.Hand;
            btnWinLive.FlatAppearance.BorderSize = 0;
            btnWinLive.ForeColor = Color.White;
            btnWinLive.Image = Properties.Resources.pngWinLive;
            btnWinLive.Name = "btnWinLive";
            btnWinLive.UseVisualStyleBackColor = true;
            btnWinLive.Click += btnWinLive_Click;
            // 
            // btnWin12
            // 
            resources.ApplyResources(btnWin12, "btnWin12");
            btnWin12.Cursor = Cursors.Hand;
            btnWin12.FlatAppearance.BorderSize = 0;
            btnWin12.ForeColor = Color.White;
            btnWin12.Image = Properties.Resources.pngWinWhat;
            btnWin12.Name = "btnWin12";
            btnWin12.UseVisualStyleBackColor = true;
            // 
            // lblInfoWin12
            // 
            resources.ApplyResources(lblInfoWin12, "lblInfoWin12");
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Name = "lblInfoWin12";
            // 
            // btnAttivaWin
            // 
            resources.ApplyResources(btnAttivaWin, "btnAttivaWin");
            btnAttivaWin.Cursor = Cursors.Hand;
            btnAttivaWin.FlatAppearance.BorderSize = 0;
            btnAttivaWin.ForeColor = Color.White;
            btnAttivaWin.Image = Properties.Resources.pngAttivaWin;
            btnAttivaWin.Name = "btnAttivaWin";
            btnAttivaWin.UseVisualStyleBackColor = true;
            btnAttivaWin.Click += btnAttivaWin_Click;
            // 
            // btnCambioEdizione
            // 
            resources.ApplyResources(btnCambioEdizione, "btnCambioEdizione");
            btnCambioEdizione.Cursor = Cursors.Hand;
            btnCambioEdizione.FlatAppearance.BorderSize = 0;
            btnCambioEdizione.ForeColor = Color.White;
            btnCambioEdizione.Image = Properties.Resources.pngCambioEdizione;
            btnCambioEdizione.Name = "btnCambioEdizione";
            btnCambioEdizione.UseVisualStyleBackColor = true;
            btnCambioEdizione.Click += btnCambioEdizione_Click;
            // 
            // FormWin
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(btnCambioEdizione);
            Controls.Add(btnAttivaWin);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnWin12);
            Controls.Add(btnWinLive);
            Controls.Add(btnWin11);
            Controls.Add(btnWin10);
            Controls.Add(btnWin8dot1);
            Controls.Add(btnWin7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnWin7;
        private Button btnWin8dot1;
        private Button btnWin11;
        private Button btnWin10;
        private Button btnWinLive;
        private Button btnWin12;
        private Label lblInfoWin12;
        private Button btnAttivaWin;
        private Button btnCambioEdizione;
    }
}