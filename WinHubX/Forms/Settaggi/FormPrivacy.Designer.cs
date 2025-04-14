namespace WinHubX.Forms.Settaggi
{
    partial class FormPrivacy
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
            components = new System.ComponentModel.Container();
            btnBack = new Button();
            DisabilitaPrivacy = new CheckedListBox();
            btnAvviaSelezionati = new Button();
            lblWin7Lite = new Label();
            label1 = new Label();
            AbilitaPrivacy = new CheckedListBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(12, 11);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 41);
            btnBack.TabIndex = 6;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaPrivacy
            // 
            DisabilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaPrivacy.BorderStyle = BorderStyle.None;
            DisabilitaPrivacy.Cursor = Cursors.Hand;
            DisabilitaPrivacy.Font = new Font("Segoe UI", 10F);
            DisabilitaPrivacy.ForeColor = Color.White;
            DisabilitaPrivacy.FormattingEnabled = true;
            DisabilitaPrivacy.Items.AddRange(new object[] { "Disabilita Opzioni Lingua", "Disabilita Suggerimenti App", "Disabilita Telemetria", "Disabilita Tracking", "Disabilita Segnalazione Errori", "Disabilita Tracking Diagnostica", "Disabilita WAP Push Service", "Disbailita Home Group", "Disabilita Assistenza Remota", "Disbailita Schedul Defrag", "Disabilita Xbox Features", "Disabilita Auto Manteinance", "Disabilita Spazio Riservato", "Disabilita Tweaks Game DVR", "Disabilita Storia Attivita", "Disabilita Wifi-Sense", "Disabilita Notifiche Tray/Calendario" });
            DisabilitaPrivacy.Location = new Point(122, 38);
            DisabilitaPrivacy.Name = "DisabilitaPrivacy";
            DisabilitaPrivacy.Size = new Size(240, 360);
            DisabilitaPrivacy.TabIndex = 7;
            // 
            // btnAvviaSelezionati
            // 
            btnAvviaSelezionati.Cursor = Cursors.Hand;
            btnAvviaSelezionati.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionati.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionati.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionati.ForeColor = Color.White;
            btnAvviaSelezionati.Location = new Point(708, 11);
            btnAvviaSelezionati.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionati.Name = "btnAvviaSelezionati";
            btnAvviaSelezionati.Size = new Size(181, 75);
            btnAvviaSelezionati.TabIndex = 22;
            btnAvviaSelezionati.Text = "Avvia Selezionati";
            btnAvviaSelezionati.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionati.UseVisualStyleBackColor = true;
            btnAvviaSelezionati.Click += btnAvviaSelezionati_Click;
            // 
            // lblWin7Lite
            // 
            lblWin7Lite.AutoSize = true;
            lblWin7Lite.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Location = new Point(122, 4);
            lblWin7Lite.Name = "lblWin7Lite";
            lblWin7Lite.Size = new Size(240, 31);
            lblWin7Lite.TabIndex = 23;
            lblWin7Lite.Text = "Disabilita Privacy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(421, 4);
            label1.Name = "label1";
            label1.Size = new Size(200, 31);
            label1.TabIndex = 24;
            label1.Text = "Abilita Privacy";
            // 
            // AbilitaPrivacy
            // 
            AbilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaPrivacy.BorderStyle = BorderStyle.None;
            AbilitaPrivacy.Cursor = Cursors.Hand;
            AbilitaPrivacy.Font = new Font("Segoe UI", 10F);
            AbilitaPrivacy.ForeColor = Color.White;
            AbilitaPrivacy.FormattingEnabled = true;
            AbilitaPrivacy.Items.AddRange(new object[] { "Abilita Opzioni Lingua", "Abilita Suggerimenti App", "Abilita Telemetria", "Abilita Tracking", "Abilita Segnalazione Errori", "Abilita Tracking Diagnostica", "Abilita WAP Push Service", "Abilita Home Group", "Abilita Assistenza Remota", "Abilita Schedul Defrag", "Abilita Xbox Features", "Abilita Auto Manteinance", "Abilita Spazio Riservato", "Abilita Tweaks Game DVR", "Abilita Storia Attivita", "Abilita Wifi-Sense", "Abilita Notifiche Tray/Calendario" });
            AbilitaPrivacy.Location = new Point(421, 38);
            AbilitaPrivacy.Name = "AbilitaPrivacy";
            AbilitaPrivacy.Size = new Size(254, 360);
            AbilitaPrivacy.TabIndex = 25;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 423);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(877, 23);
            progressBar1.TabIndex = 26;
            // 
            // FormPrivacy
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(progressBar1);
            Controls.Add(AbilitaPrivacy);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionati);
            Controls.Add(DisabilitaPrivacy);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPrivacy";
            Text = "FormPrivacy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaPrivacy;
        private Button btnAvviaSelezionati;
        private Label lblWin7Lite;
        private Label label1;
        private CheckedListBox AbilitaPrivacy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private ToolTip toolTip1;
    }
}