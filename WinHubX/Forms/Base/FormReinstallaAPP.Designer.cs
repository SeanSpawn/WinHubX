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
            btnAvviaSelezionatiApp.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionatiApp.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionatiApp.ForeColor = Color.White;
            btnAvviaSelezionatiApp.Location = new Point(155, 5);
            btnAvviaSelezionatiApp.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionatiApp.Name = "btnAvviaSelezionatiApp";
            btnAvviaSelezionatiApp.Size = new Size(154, 61);
            btnAvviaSelezionatiApp.TabIndex = 26;
            btnAvviaSelezionatiApp.Text = "Avvia Selezionati";
            btnAvviaSelezionatiApp.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionatiApp.UseVisualStyleBackColor = true;
            btnAvviaSelezionatiApp.Click += btnAvviaSelezionatiApp_Click;
            // 
            // App1
            // 
            App1.BackColor = Color.FromArgb(37, 38, 39);
            App1.BorderStyle = BorderStyle.None;
            App1.ForeColor = Color.White;
            App1.FormattingEnabled = true;
            App1.Items.AddRange(new object[] { "Microsoft Edge", "Microsoft Store", "Windows Defender" });
            App1.Location = new Point(10, 12);
            App1.Name = "App1";
            App1.Size = new Size(163, 54);
            App1.TabIndex = 25;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 102);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Cerca app...";
            txtSearch.Size = new Size(249, 23);
            txtSearch.TabIndex = 27;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 386);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(877, 23);
            txtOutput.TabIndex = 31;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(10, 133);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new Size(879, 247);
            dataGridViewResults.TabIndex = 32;
            dataGridViewResults.CellDoubleClick += dataGridViewResults_CellDoubleClick;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(265, 90);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(108, 38);
            btnSearch.TabIndex = 33;
            btnSearch.Text = "Ricerca";
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.6F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(444, 99);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 36;
            label1.Text = "label1";
            // 
            // btn_AggiornaTutto
            // 
            btn_AggiornaTutto.Cursor = Cursors.Hand;
            btn_AggiornaTutto.FlatAppearance.BorderSize = 0;
            btn_AggiornaTutto.FlatStyle = FlatStyle.Flat;
            btn_AggiornaTutto.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AggiornaTutto.ForeColor = Color.White;
            btn_AggiornaTutto.Location = new Point(695, 90);
            btn_AggiornaTutto.Margin = new Padding(3, 2, 3, 2);
            btn_AggiornaTutto.Name = "btn_AggiornaTutto";
            btn_AggiornaTutto.Size = new Size(192, 38);
            btn_AggiornaTutto.TabIndex = 37;
            btn_AggiornaTutto.Text = "Aggiorna Tutto";
            btn_AggiornaTutto.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btn_AggiornaTutto, "Aggiorna tutte le tue app sul PC se presenti su WinGet");
            btn_AggiornaTutto.UseVisualStyleBackColor = true;
            // 
            // btn_Aggiorna
            // 
            btn_Aggiorna.Cursor = Cursors.Hand;
            btn_Aggiorna.FlatAppearance.BorderSize = 0;
            btn_Aggiorna.FlatStyle = FlatStyle.Flat;
            btn_Aggiorna.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Aggiorna.ForeColor = Color.White;
            btn_Aggiorna.Location = new Point(10, 414);
            btn_Aggiorna.Margin = new Padding(3, 2, 3, 2);
            btn_Aggiorna.Name = "btn_Aggiorna";
            btn_Aggiorna.Size = new Size(120, 38);
            btn_Aggiorna.TabIndex = 38;
            btn_Aggiorna.Text = "Aggiorna";
            btn_Aggiorna.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_Aggiorna.UseVisualStyleBackColor = true;
            btn_Aggiorna.Click += btn_Aggiorna_Click;
            // 
            // btnInstalla
            // 
            btnInstalla.Cursor = Cursors.Hand;
            btnInstalla.FlatAppearance.BorderSize = 0;
            btnInstalla.FlatStyle = FlatStyle.Flat;
            btnInstalla.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInstalla.ForeColor = Color.White;
            btnInstalla.Location = new Point(771, 414);
            btnInstalla.Margin = new Padding(3, 2, 3, 2);
            btnInstalla.Name = "btnInstalla";
            btnInstalla.Size = new Size(120, 38);
            btnInstalla.TabIndex = 39;
            btnInstalla.Text = "Installa";
            btnInstalla.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInstalla.UseVisualStyleBackColor = true;
            btnInstalla.Click += btnInstalla_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(419, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(19, 20);
            panel1.TabIndex = 34;
            // 
            // FormReinstallaAPP
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormReinstallaAPP";
            Text = "FormReinstallaAPP";
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