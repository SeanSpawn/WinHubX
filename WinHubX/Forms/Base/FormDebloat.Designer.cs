namespace WinHubX.Forms.Base
{
    partial class FormDebloat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebloat));
            btnAvviaSelezionatiDebloat = new Button();
            btnDebloatAuto = new Button();
            lblInfoWin12 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            textBox1 = new TextBox();
            btnDebloatAvanzato = new Button();
            btnServizi = new Button();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // btnAvviaSelezionatiDebloat
            // 
            resources.ApplyResources(btnAvviaSelezionatiDebloat, "btnAvviaSelezionatiDebloat");
            btnAvviaSelezionatiDebloat.Cursor = Cursors.Hand;
            btnAvviaSelezionatiDebloat.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiDebloat.ForeColor = Color.White;
            btnAvviaSelezionatiDebloat.Name = "btnAvviaSelezionatiDebloat";
            btnAvviaSelezionatiDebloat.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiDebloat.Click += btnAvviaSelezionatiDebloat_Click;
            // 
            // btnDebloatAuto
            // 
            resources.ApplyResources(btnDebloatAuto, "btnDebloatAuto");
            btnDebloatAuto.Cursor = Cursors.Hand;
            btnDebloatAuto.FlatAppearance.BorderSize = 0;
            btnDebloatAuto.ForeColor = Color.White;
            btnDebloatAuto.Name = "btnDebloatAuto";
            btnDebloatAuto.UseVisualStyleBackColor = true;
            btnDebloatAuto.Click += btnDebloatAuto_Click;
            // 
            // lblInfoWin12
            // 
            resources.ApplyResources(lblInfoWin12, "lblInfoWin12");
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Name = "lblInfoWin12";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackColor = Color.FromArgb(37, 38, 39);
            textBox1.ForeColor = Color.White;
            textBox1.Name = "textBox1";
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // btnDebloatAvanzato
            // 
            resources.ApplyResources(btnDebloatAvanzato, "btnDebloatAvanzato");
            btnDebloatAvanzato.Cursor = Cursors.Hand;
            btnDebloatAvanzato.FlatAppearance.BorderSize = 0;
            btnDebloatAvanzato.ForeColor = Color.White;
            btnDebloatAvanzato.Name = "btnDebloatAvanzato";
            btnDebloatAvanzato.UseVisualStyleBackColor = true;
            btnDebloatAvanzato.Click += btnDebloatAvanzato_Click;
            // 
            // btnServizi
            // 
            resources.ApplyResources(btnServizi, "btnServizi");
            btnServizi.Cursor = Cursors.Hand;
            btnServizi.FlatAppearance.BorderSize = 0;
            btnServizi.ForeColor = Color.White;
            btnServizi.Name = "btnServizi";
            btnServizi.UseVisualStyleBackColor = true;
            btnServizi.Click += btnServizi_Click;
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // FormDebloat
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(progressBar1);
            Controls.Add(btnServizi);
            Controls.Add(btnDebloatAvanzato);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnDebloatAuto);
            Controls.Add(btnAvviaSelezionatiDebloat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDebloat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAvviaSelezionatiDebloat;
        private Button btnDebloatAuto;
        private Label lblInfoWin12;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private Button btnDebloatAvanzato;
        private Button btnServizi;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}