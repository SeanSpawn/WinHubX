namespace WinHubX.Forms.DebloatAvanzato
{
    partial class FormServizi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServizi));
            button1 = new Button();
            DisabilitaServizi = new CheckedListBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            richTextBox1 = new RichTextBox();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(237, 473);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(154, 61);
            button1.TabIndex = 86;
            button1.Text = "Modifica Servizi";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += ModificaServiziButton_Click;
            // 
            // DisabilitaServizi
            // 
            DisabilitaServizi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DisabilitaServizi.BackColor = Color.FromArgb(37, 38, 39);
            DisabilitaServizi.BorderStyle = BorderStyle.None;
            DisabilitaServizi.Cursor = Cursors.Hand;
            DisabilitaServizi.Font = new Font("Segoe UI", 10F);
            DisabilitaServizi.ForeColor = Color.White;
            DisabilitaServizi.FormattingEnabled = true;
            DisabilitaServizi.Location = new Point(12, 12);
            DisabilitaServizi.Name = "DisabilitaServizi";
            DisabilitaServizi.Size = new Size(269, 420);
            DisabilitaServizi.TabIndex = 87;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox1.BackColor = Color.FromArgb(37, 38, 39);
            richTextBox1.Font = new Font("Segoe UI", 8F);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(287, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(320, 420);
            richTextBox1.TabIndex = 88;
            richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 445);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(595, 23);
            progressBar1.TabIndex = 89;
            // 
            // FormServizi
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(619, 545);
            Controls.Add(progressBar1);
            Controls.Add(richTextBox1);
            Controls.Add(DisabilitaServizi);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormServizi";
            Text = "WinHubX-Servizi";
            Load += FormServizi_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private CheckedListBox DisabilitaServizi;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RichTextBox richTextBox1;
        private ProgressBar progressBar1;
    }
}