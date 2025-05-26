namespace WinHubX.Forms.ReinstallaAPP
{
    partial class FormReinstallaAPP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReinstallaAPP));
            btnAvviaSelezionatiApp = new Button();
            App1 = new CheckedListBox();
            txtSearch = new TextBox();
            txtOutput = new TextBox();
            dataGridViewResults = new DataGridView();
            btnSearch = new Button();
            label1 = new Label();
            btn_AggiornaTutto = new Button();
            btn_Aggiorna = new Button();
            btnInstalla = new Button();
            panel1 = new Panel();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // btnAvviaSelezionatiApp
            // 
            btnAvviaSelezionatiApp.Cursor = Cursors.Hand;
            btnAvviaSelezionatiApp.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btnAvviaSelezionatiApp, "btnAvviaSelezionatiApp");
            btnAvviaSelezionatiApp.ForeColor = Color.White;
            btnAvviaSelezionatiApp.Name = "btnAvviaSelezionatiApp";
            btnAvviaSelezionatiApp.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiApp.Click += btnAvviaSelezionatiApp_Click;
            // 
            // App1
            // 
            App1.BackColor = Color.FromArgb(37, 38, 39);
            App1.BorderStyle = BorderStyle.None;
            App1.ForeColor = Color.White;
            App1.FormattingEnabled = true;
            App1.Items.AddRange(new object[] { resources.GetString("App1.Items"), resources.GetString("App1.Items1"), resources.GetString("App1.Items2") });
            resources.ApplyResources(App1, "App1");
            App1.Name = "App1";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // txtOutput
            // 
            resources.ApplyResources(txtOutput, "txtOutput");
            txtOutput.Name = "txtOutput";
            // 
            // dataGridViewResults
            // 
            resources.ApplyResources(dataGridViewResults, "dataGridViewResults");
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.CellDoubleClick += dataGridViewResults_CellDoubleClick;
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.ForeColor = Color.White;
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Name = "label1";
            // 
            // btn_AggiornaTutto
            // 
            resources.ApplyResources(btn_AggiornaTutto, "btn_AggiornaTutto");
            btn_AggiornaTutto.Cursor = Cursors.Hand;
            btn_AggiornaTutto.FlatAppearance.BorderSize = 0;
            btn_AggiornaTutto.ForeColor = Color.White;
            btn_AggiornaTutto.Name = "btn_AggiornaTutto";
            toolTip1.SetToolTip(btn_AggiornaTutto, resources.GetString("btn_AggiornaTutto.ToolTip"));
            btn_AggiornaTutto.UseVisualStyleBackColor = true;
            // 
            // btn_Aggiorna
            // 
            resources.ApplyResources(btn_Aggiorna, "btn_Aggiorna");
            btn_Aggiorna.Cursor = Cursors.Hand;
            btn_Aggiorna.FlatAppearance.BorderSize = 0;
            btn_Aggiorna.ForeColor = Color.White;
            btn_Aggiorna.Name = "btn_Aggiorna";
            btn_Aggiorna.UseVisualStyleBackColor = true;
            btn_Aggiorna.Click += btn_Aggiorna_Click;
            // 
            // btnInstalla
            // 
            resources.ApplyResources(btnInstalla, "btnInstalla");
            btnInstalla.Cursor = Cursors.Hand;
            btnInstalla.FlatAppearance.BorderSize = 0;
            btnInstalla.ForeColor = Color.White;
            btnInstalla.Name = "btnInstalla";
            btnInstalla.UseVisualStyleBackColor = true;
            btnInstalla.Click += btnInstalla_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // FormReinstallaAPP
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(btnInstalla);
            Controls.Add(btn_Aggiorna);
            Controls.Add(btn_AggiornaTutto);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(btnSearch);
            Controls.Add(dataGridViewResults);
            Controls.Add(txtOutput);
            Controls.Add(txtSearch);
            Controls.Add(btnAvviaSelezionatiApp);
            Controls.Add(App1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormReinstallaAPP";
            Load += FormReinstallaAPP_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAvviaSelezionatiApp;
        private CheckedListBox App1;
        private TextBox txtSearch;
        private TextBox txtOutput;
        private DataGridView dataGridViewResults;
        private Button btnSearch;
        private Label label1;
        private Button btn_AggiornaTutto;
        private Button btn_Aggiorna;
        private Button btnInstalla;
        private Panel panel1;
        private ToolTip toolTip1;
    }
}