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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrivacy));
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
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Name = "btnBack";
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaPrivacy
            // 
            resources.ApplyResources(DisabilitaPrivacy, "DisabilitaPrivacy");
            DisabilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaPrivacy.BorderStyle = BorderStyle.None;
            DisabilitaPrivacy.Cursor = Cursors.Hand;
            DisabilitaPrivacy.ForeColor = Color.White;
            DisabilitaPrivacy.FormattingEnabled = true;
            DisabilitaPrivacy.Items.AddRange(new object[] { resources.GetString("DisabilitaPrivacy.Items"), resources.GetString("DisabilitaPrivacy.Items1"), resources.GetString("DisabilitaPrivacy.Items2"), resources.GetString("DisabilitaPrivacy.Items3"), resources.GetString("DisabilitaPrivacy.Items4"), resources.GetString("DisabilitaPrivacy.Items5"), resources.GetString("DisabilitaPrivacy.Items6"), resources.GetString("DisabilitaPrivacy.Items7"), resources.GetString("DisabilitaPrivacy.Items8"), resources.GetString("DisabilitaPrivacy.Items9"), resources.GetString("DisabilitaPrivacy.Items10"), resources.GetString("DisabilitaPrivacy.Items11"), resources.GetString("DisabilitaPrivacy.Items12"), resources.GetString("DisabilitaPrivacy.Items13"), resources.GetString("DisabilitaPrivacy.Items14"), resources.GetString("DisabilitaPrivacy.Items15"), resources.GetString("DisabilitaPrivacy.Items16") });
            DisabilitaPrivacy.Name = "DisabilitaPrivacy";
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
            // lblWin7Lite
            // 
            resources.ApplyResources(lblWin7Lite, "lblWin7Lite");
            lblWin7Lite.ForeColor = Color.White;
            lblWin7Lite.Name = "lblWin7Lite";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // AbilitaPrivacy
            // 
            resources.ApplyResources(AbilitaPrivacy, "AbilitaPrivacy");
            AbilitaPrivacy.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaPrivacy.BorderStyle = BorderStyle.None;
            AbilitaPrivacy.Cursor = Cursors.Hand;
            AbilitaPrivacy.ForeColor = Color.White;
            AbilitaPrivacy.FormattingEnabled = true;
            AbilitaPrivacy.Items.AddRange(new object[] { resources.GetString("AbilitaPrivacy.Items"), resources.GetString("AbilitaPrivacy.Items1"), resources.GetString("AbilitaPrivacy.Items2"), resources.GetString("AbilitaPrivacy.Items3"), resources.GetString("AbilitaPrivacy.Items4"), resources.GetString("AbilitaPrivacy.Items5"), resources.GetString("AbilitaPrivacy.Items6"), resources.GetString("AbilitaPrivacy.Items7"), resources.GetString("AbilitaPrivacy.Items8"), resources.GetString("AbilitaPrivacy.Items9"), resources.GetString("AbilitaPrivacy.Items10"), resources.GetString("AbilitaPrivacy.Items11"), resources.GetString("AbilitaPrivacy.Items12"), resources.GetString("AbilitaPrivacy.Items13"), resources.GetString("AbilitaPrivacy.Items14"), resources.GetString("AbilitaPrivacy.Items15"), resources.GetString("AbilitaPrivacy.Items16") });
            AbilitaPrivacy.Name = "AbilitaPrivacy";
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
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // FormPrivacy
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(progressBar1);
            Controls.Add(AbilitaPrivacy);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionati);
            Controls.Add(DisabilitaPrivacy);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPrivacy";
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