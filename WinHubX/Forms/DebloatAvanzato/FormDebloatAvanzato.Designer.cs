namespace WinHubX.Forms.DebloatAvanzato
{
    partial class FormDebloatAvanzato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebloatAvanzato));
            checkedListBox1 = new CheckedListBox();
            checkBox_WindowsDefender = new CheckBox();
            btnAvviaSelezionati = new Button();
            lblInfoWin12 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBox1.BackColor = Color.FromArgb(37, 38, 39);
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.ForeColor = Color.White;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 30);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(388, 416);
            checkedListBox1.TabIndex = 0;
            // 
            // checkBox_WindowsDefender
            // 
            checkBox_WindowsDefender.Anchor = AnchorStyles.Top;
            checkBox_WindowsDefender.AutoSize = true;
            checkBox_WindowsDefender.ForeColor = Color.White;
            checkBox_WindowsDefender.Location = new Point(410, 30);
            checkBox_WindowsDefender.Name = "checkBox_WindowsDefender";
            checkBox_WindowsDefender.Size = new Size(123, 19);
            checkBox_WindowsDefender.TabIndex = 1;
            checkBox_WindowsDefender.Text = "WindowsDefender";
            checkBox_WindowsDefender.UseVisualStyleBackColor = true;
            // 
            // btnAvviaSelezionati
            // 
            btnAvviaSelezionati.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAvviaSelezionati.Cursor = Cursors.Hand;
            btnAvviaSelezionati.FlatAppearance.BorderSize = 0;
            btnAvviaSelezionati.FlatStyle = FlatStyle.Flat;
            btnAvviaSelezionati.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAvviaSelezionati.ForeColor = Color.White;
            btnAvviaSelezionati.Location = new Point(410, 378);
            btnAvviaSelezionati.Margin = new Padding(3, 2, 3, 2);
            btnAvviaSelezionati.Name = "btnAvviaSelezionati";
            btnAvviaSelezionati.Size = new Size(154, 61);
            btnAvviaSelezionati.TabIndex = 84;
            btnAvviaSelezionati.Text = "Avvia Selezionati";
            btnAvviaSelezionati.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAvviaSelezionati.UseVisualStyleBackColor = true;
            btnAvviaSelezionati.Click += btnAvviaSelezionati_Click;
            // 
            // lblInfoWin12
            // 
            lblInfoWin12.AutoSize = true;
            lblInfoWin12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInfoWin12.ForeColor = Color.Coral;
            lblInfoWin12.Location = new Point(12, 9);
            lblInfoWin12.Name = "lblInfoWin12";
            lblInfoWin12.Size = new Size(200, 17);
            lblInfoWin12.TabIndex = 85;
            lblInfoWin12.Text = "Seleziona le app da rimuovere";
            lblInfoWin12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(37, 38, 39);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(410, 70);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Cerca...";
            textBox1.Size = new Size(123, 23);
            textBox1.TabIndex = 86;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(539, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 28);
            pictureBox1.TabIndex = 87;
            pictureBox1.TabStop = false;
            // 
            // FormDebloatAvanzato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(576, 450);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(lblInfoWin12);
            Controls.Add(btnAvviaSelezionati);
            Controls.Add(checkBox_WindowsDefender);
            Controls.Add(checkedListBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDebloatAvanzato";
            Text = "DebloatAvanzato";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private CheckBox checkBox_WindowsDefender;
        private Button btnAvviaSelezionati;
        private Label lblInfoWin12;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}