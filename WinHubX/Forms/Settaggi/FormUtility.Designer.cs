namespace WinHubX.Forms.Settaggi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtility));
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
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Name = "btnBack";
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // DisabilitaUtility
            // 
            resources.ApplyResources(DisabilitaUtility, "DisabilitaUtility");
            DisabilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaUtility.BorderStyle = BorderStyle.None;
            DisabilitaUtility.Cursor = Cursors.Hand;
            DisabilitaUtility.ForeColor = Color.White;
            DisabilitaUtility.FormattingEnabled = true;
            DisabilitaUtility.Items.AddRange(new object[] { resources.GetString("DisabilitaUtility.Items"), resources.GetString("DisabilitaUtility.Items1"), resources.GetString("DisabilitaUtility.Items2"), resources.GetString("DisabilitaUtility.Items3"), resources.GetString("DisabilitaUtility.Items4"), resources.GetString("DisabilitaUtility.Items5"), resources.GetString("DisabilitaUtility.Items6"), resources.GetString("DisabilitaUtility.Items7"), resources.GetString("DisabilitaUtility.Items8"), resources.GetString("DisabilitaUtility.Items9"), resources.GetString("DisabilitaUtility.Items10"), resources.GetString("DisabilitaUtility.Items11"), resources.GetString("DisabilitaUtility.Items12"), resources.GetString("DisabilitaUtility.Items13"), resources.GetString("DisabilitaUtility.Items14"), resources.GetString("DisabilitaUtility.Items15"), resources.GetString("DisabilitaUtility.Items16"), resources.GetString("DisabilitaUtility.Items17") });
            DisabilitaUtility.Name = "DisabilitaUtility";
            // 
            // AbilitaUtility
            // 
            resources.ApplyResources(AbilitaUtility, "AbilitaUtility");
            AbilitaUtility.BackColor = Color.FromArgb(37, 38, 39);
            AbilitaUtility.BorderStyle = BorderStyle.None;
            AbilitaUtility.Cursor = Cursors.Hand;
            AbilitaUtility.ForeColor = Color.White;
            AbilitaUtility.FormattingEnabled = true;
            AbilitaUtility.Items.AddRange(new object[] { resources.GetString("AbilitaUtility.Items"), resources.GetString("AbilitaUtility.Items1"), resources.GetString("AbilitaUtility.Items2"), resources.GetString("AbilitaUtility.Items3"), resources.GetString("AbilitaUtility.Items4"), resources.GetString("AbilitaUtility.Items5"), resources.GetString("AbilitaUtility.Items6"), resources.GetString("AbilitaUtility.Items7"), resources.GetString("AbilitaUtility.Items8"), resources.GetString("AbilitaUtility.Items9"), resources.GetString("AbilitaUtility.Items10"), resources.GetString("AbilitaUtility.Items11"), resources.GetString("AbilitaUtility.Items12"), resources.GetString("AbilitaUtility.Items13"), resources.GetString("AbilitaUtility.Items14"), resources.GetString("AbilitaUtility.Items15"), resources.GetString("AbilitaUtility.Items16"), resources.GetString("AbilitaUtility.Items17"), resources.GetString("AbilitaUtility.Items18") });
            AbilitaUtility.Name = "AbilitaUtility";
            // 
            // btnAvviaSelezionatiUti
            // 
            resources.ApplyResources(btnAvviaSelezionatiUti, "btnAvviaSelezionatiUti");
            btnAvviaSelezionatiUti.Cursor = Cursors.Hand;
            btnAvviaSelezionatiUti.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionatiUti.ForeColor = Color.White;
            btnAvviaSelezionatiUti.Name = "btnAvviaSelezionatiUti";
            btnAvviaSelezionatiUti.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiUti.Click += btnAvviaSelezionatiUti_Click;
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
            // FormUtility
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(lblWin7Lite);
            Controls.Add(btnAvviaSelezionatiUti);
            Controls.Add(AbilitaUtility);
            Controls.Add(DisabilitaUtility);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUtility";
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