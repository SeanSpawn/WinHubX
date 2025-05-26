namespace WinHubX.Forms.DebloatAvanzato
{
    partial class FormDebloatAvanzato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebloatAvanzato));
            checkedListBox1 = new CheckedListBox();
            checkBox_WindowsDefender = new CheckBox();
            btnAvviaSelezionati = new Button();
            lblInfoWin12 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            resources.ApplyResources(checkedListBox1, "checkedListBox1");
            checkedListBox1.BackColor = Color.FromArgb(37, 38, 39);
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.ForeColor = Color.White;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Name = "checkedListBox1";
            // 
            // checkBox_WindowsDefender
            // 
            resources.ApplyResources(checkBox_WindowsDefender, "checkBox_WindowsDefender");
            checkBox_WindowsDefender.ForeColor = Color.White;
            checkBox_WindowsDefender.Name = "checkBox_WindowsDefender";
            checkBox_WindowsDefender.UseVisualStyleBackColor = true;
            // 
            // btnAvviaSelezionati
            // 
            resources.ApplyResources(btnAvviaSelezionati, "btnAvviaSelezionati");
            btnAvviaSelezionati.Cursor = Cursors.Hand;
            btnAvviaSelezionati.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionati.ForeColor = Color.White;
            btnAvviaSelezionati.Name = "btnAvviaSelezionati";
            btnAvviaSelezionati.UseVisualStyleBackColor = true;
            btnAvviaSelezionati.Click += btnAvviaSelezionati_Click;
            // 
            // lblInfoWin12
            // 
            resources.ApplyResources(lblInfoWin12, "lblInfoWin12");
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Name = "lblInfoWin12";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(37, 38, 39);
            textBox1.ForeColor = Color.White;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.pngDefenderWin;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // FormDebloatAvanzato
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnAvviaSelezionati);
            Controls.Add(checkBox_WindowsDefender);
            Controls.Add(checkedListBox1);
            Name = "FormDebloatAvanzato";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private CheckBox checkBox_WindowsDefender;
        private Button btnAvviaSelezionati;
        private Label lblInfoWin12;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
    }
}