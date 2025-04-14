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
            btnAvviaSelezionatiDebloat.Cursor = Cursors.Hand;
            btnAvviaSelezionatiDebloat.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiDebloat.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiDebloat.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiDebloat.ForeColor = Color.White;
            btnAvviaSelezionatiDebloat.Location = new Point(737, 5);
            btnAvviaSelezionatiDebloat.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionatiDebloat.Name = "btnAvviaSelezionatiDebloat";
            btnAvviaSelezionatiDebloat.Size = new Size(154, 61);
            btnAvviaSelezionatiDebloat.TabIndex = 24;
            btnAvviaSelezionatiDebloat.Text = "Avvia Selezionati";
            btnAvviaSelezionatiDebloat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiDebloat.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiDebloat.Click += btnAvviaSelezionatiDebloat_Click;
            // 
            // btnDebloatAuto
            // 
            btnDebloatAuto.Cursor = Cursors.Hand;
            btnDebloatAuto.FlatAppearance.BorderSize = 0;
            btnDebloatAuto.FlatStyle = FlatStyle.Flat;
            btnDebloatAuto.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDebloatAuto.ForeColor = Color.White;
            btnDebloatAuto.Location = new Point(737, 154);
            btnDebloatAuto.Margin = new Padding(3, 2, 3, 2);
            btnDebloatAuto.Name = "btnDebloatAuto";
            btnDebloatAuto.Size = new Size(154, 61);
            btnDebloatAuto.TabIndex = 26;
            btnDebloatAuto.Text = "Debloat Automatico";
            btnDebloatAuto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDebloatAuto.UseVisualStyleBackColor = true;
            btnDebloatAuto.Click += btnDebloatAuto_Click;
            // 
            // lblInfoWin12
            // 
            lblInfoWin12.AutoSize = true;
            lblInfoWin12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Location = new Point(682, 217);
            lblInfoWin12.Name = "lblInfoWin12";
            lblInfoWin12.Size = new Size(209, 34);
            lblInfoWin12.TabIndex = 80;
            lblInfoWin12.Text = "Rimuovi tutte le app(bloatware) \r\nTranne calcolatrice, foto e store";
            lblInfoWin12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(12, 34);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(664, 412);
            flowLayoutPanel1.TabIndex = 81;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(37, 38, 39);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(514, 5);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Cerca...";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 82;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // btnDebloatAvanzato
            // 
            btnDebloatAvanzato.Cursor = Cursors.Hand;
            btnDebloatAvanzato.FlatAppearance.BorderSize = 0;
            btnDebloatAvanzato.FlatStyle = FlatStyle.Flat;
            btnDebloatAvanzato.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDebloatAvanzato.ForeColor = Color.White;
            btnDebloatAvanzato.Location = new Point(735, 268);
            btnDebloatAvanzato.Margin = new Padding(3, 2, 3, 2);
            btnDebloatAvanzato.Name = "btnDebloatAvanzato";
            btnDebloatAvanzato.Size = new Size(154, 61);
            btnDebloatAvanzato.TabIndex = 83;
            btnDebloatAvanzato.Text = "Debloat Avanzato";
            btnDebloatAvanzato.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDebloatAvanzato.UseVisualStyleBackColor = true;
            btnDebloatAvanzato.Click += btnDebloatAvanzato_Click;
            // 
            // btnServizi
            // 
            btnServizi.Cursor = Cursors.Hand;
            btnServizi.FlatAppearance.BorderSize = 0;
            btnServizi.FlatStyle = FlatStyle.Flat;
            btnServizi.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnServizi.ForeColor = Color.White;
            btnServizi.Location = new Point(735, 386);
            btnServizi.Margin = new Padding(3, 2, 3, 2);
            btnServizi.Name = "btnServizi";
            btnServizi.Size = new Size(154, 61);
            btnServizi.TabIndex = 84;
            btnServizi.Text = "Modifica Servizi";
            btnServizi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServizi.UseVisualStyleBackColor = true;
            btnServizi.Click += btnServizi_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(467, 23);
            progressBar1.TabIndex = 85;
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
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(progressBar1);
            Controls.Add(btnServizi);
            Controls.Add(btnDebloatAvanzato);
            Controls.Add(textBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnDebloatAuto);
            Controls.Add(btnAvviaSelezionatiDebloat);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDebloat";
            Text = "FormDebloat";
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