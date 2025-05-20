namespace WinHubX.Forms
{
    partial class FormWinHubXLiteOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWinHubXLiteOS));
            richTextBox1 = new RichTextBox();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnBack = new Button();
            btnAvvia = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            resources.ApplyResources(richTextBox1, "richTextBox1");
            richTextBox1.BackColor = Color.DimGray;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Name = "richTextBox1";
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // progressBar2
            // 
            resources.ApplyResources(progressBar2, "progressBar2");
            progressBar2.Name = "progressBar2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.DarkOrange;
            label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.Coral;
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.Coral;
            label2.Name = "label2";
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
            // btnAvvia
            // 
            resources.ApplyResources(btnAvvia, "btnAvvia");
            btnAvvia.ForeColor = Color.White;
            btnAvvia.Name = "btnAvvia";
            btnAvvia.UseVisualStyleBackColor = true;
            btnAvvia.Click += btnAvvia_Click;
            // 
            // FormWinHubXLiteOS
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(btnAvvia);
            Controls.Add(btnBack);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormWinHubXLiteOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button btnBack;
        private Button btnAvvia;
    }
}