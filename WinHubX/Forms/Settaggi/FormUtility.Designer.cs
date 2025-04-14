﻿namespace WinHubX.Forms.Settaggi
{
    partial class FormUtility
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
            DisabilitaUtility = new CheckedListBox();
            AbilitaUtility = new CheckedListBox();
            btnAvviaSelezionatiUti = new Button();
            lblWin7Lite = new Label();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Location = new Point(10, 9);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 41);
            btnBack.TabIndex = 7;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaUtility
            // 
            DisabilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaUtility.BorderStyle = BorderStyle.None;
            DisabilitaUtility.Cursor = Cursors.Hand;
            DisabilitaUtility.Font = new Font("Segoe UI", 9.5F);
            DisabilitaUtility.ForeColor = Color.White;
            DisabilitaUtility.FormattingEnabled = true;
            DisabilitaUtility.Items.AddRange(new object[] { "Disabilita Background App", "Disabilita Feedback", "Disabilita Advertising ID", "Disabilita Filtro Smart Screen", "Disabilita Desktop Remoto", "Disabilita attivazione del Numlock in avvio", "Disabilita News e Interessi", "Disabilita Index File", "Disabilita Edge PDF", "Disabilita Mappe", "Disabilita UWP apps", "Disabilita Esperienze Personalizzate Microsoft", "Disabilita Storage Check", "Disabilita Superfetch", "Disabilita Ibernazione", "Disabilita Ottimizzazione FullScreen", "Disabilita Avvio Rapido", "Normal Bandwidth" });
            DisabilitaUtility.Location = new Point(79, 32);
            DisabilitaUtility.Name = "DisabilitaUtility";
            DisabilitaUtility.Size = new Size(346, 380);
            DisabilitaUtility.TabIndex = 8;
            // 
            // AbilitaUtility
            // 
            AbilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaUtility.BorderStyle = BorderStyle.None;
            AbilitaUtility.Cursor = Cursors.Hand;
            AbilitaUtility.Font = new Font("Segoe UI", 9.5F);
            AbilitaUtility.ForeColor = Color.White;
            AbilitaUtility.FormattingEnabled = true;
            AbilitaUtility.Items.AddRange(new object[] { "Abilita Background App", "Abilita Feedback", "Abilita Advertising ID", "Abilita Filtro Smart Screen", "Abilita Desktop Remoto", "Abilita attivazione del Numlock in avvio", "Abilita News e Interessi", "Abilita Index File", "Abilita Risparmio Energetico Personalizzato", "Abilita Mappe", "Abilita UWP apps", "Abilita Esperienze Personalizzate Microsoft", "Abilita Storage Check", "Abilita Superfetch", "Abilita Ibernazione", "Abilita Ottimizzazione FullScreen", "Abilita Avvio Rapido", "All Bandwidth", "Migliora uso SSD" });
            AbilitaUtility.Location = new Point(429, 32);
            AbilitaUtility.Name = "AbilitaUtility";
            AbilitaUtility.Size = new Size(309, 380);
            AbilitaUtility.TabIndex = 9;
            // 
            // btnAvviaSelezionatiUti
            // 
            btnAvviaSelezionatiUti.Cursor = Cursors.Hand;
            btnAvviaSelezionatiUti.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiUti.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiUti.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiUti.ForeColor = Color.White;
            btnAvviaSelezionatiUti.Location = new Point(735, 11);
            btnAvviaSelezionatiUti.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionatiUti.Name = "btnAvviaSelezionatiUti";
            btnAvviaSelezionatiUti.Size = new Size(154, 74);
            btnAvviaSelezionatiUti.TabIndex = 23;
            btnAvviaSelezionatiUti.Text = "Avvia Selezionati";
            btnAvviaSelezionatiUti.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiUti.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiUti.Click += btnAvviaSelezionatiUti_Click;
            // 
            // lblWin7Lite
            // 
            lblWin7Lite.AutoSize = true;
            lblWin7Lite.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Location = new Point(79, -2);
            lblWin7Lite.Name = "lblWin7Lite";
            lblWin7Lite.Size = new Size(218, 31);
            lblWin7Lite.TabIndex = 24;
            lblWin7Lite.Text = "Disabilita Utility";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(429, -2);
            label1.Name = "label1";
            label1.Size = new Size(178, 31);
            label1.TabIndex = 25;
            label1.Text = "Abilita Utility";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 428);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(877, 23);
            progressBar1.TabIndex = 26;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // FormUtility
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionatiUti);
            Controls.Add(AbilitaUtility);
            Controls.Add(DisabilitaUtility);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormUtility";
            Text = "FormUtility";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private CheckedListBox DisabilitaUtility;
        private CheckedListBox AbilitaUtility;
        private Button btnAvviaSelezionatiUti;
        private Label lblWin7Lite;
        private Label label1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolTip toolTip1;
    }
}