namespace WinHubX.Forms.Settaggi
{
    partial class FormRipristinoSO
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
            btnBack = new Button();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            checkBox_hw = new CheckBox();
            checkBox_sw = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            richTextBox2 = new RichTextBox();
            label3 = new Label();
            btnStop = new Button();
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
            btnBack.TabIndex = 41;
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Coral;
            label2.Location = new Point(245, 25);
            label2.Name = "label2";
            label2.Size = new Size(187, 26);
            label2.TabIndex = 82;
            label2.Text = "Verifica Computer";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 347);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(883, 23);
            progressBar1.TabIndex = 83;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(37, 38, 39);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(6, 70);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(543, 271);
            richTextBox1.TabIndex = 84;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(470, 399);
            button1.Name = "button1";
            button1.Size = new Size(114, 45);
            button1.TabIndex = 85;
            button1.Text = "Avvia";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonStart_Click;
            // 
            // checkBox_hw
            // 
            checkBox_hw.AutoSize = true;
            checkBox_hw.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBox_hw.ForeColor = Color.White;
            checkBox_hw.Location = new Point(15, 397);
            checkBox_hw.Name = "checkBox_hw";
            checkBox_hw.Size = new Size(134, 25);
            checkBox_hw.TabIndex = 86;
            checkBox_hw.Text = "Test Hardware";
            checkBox_hw.UseVisualStyleBackColor = true;
            checkBox_hw.CheckedChanged += checkBox_hw_CheckedChanged;
            // 
            // checkBox_sw
            // 
            checkBox_sw.AutoSize = true;
            checkBox_sw.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            checkBox_sw.ForeColor = Color.White;
            checkBox_sw.Location = new Point(15, 428);
            checkBox_sw.Name = "checkBox_sw";
            checkBox_sw.Size = new Size(126, 25);
            checkBox_sw.TabIndex = 87;
            checkBox_sw.Text = "Test Software";
            checkBox_sw.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(170, 398);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(59, 23);
            dateTimePicker1.TabIndex = 88;
            dateTimePicker1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(230, 399);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 89;
            label1.Text = "/min";
            label1.Visible = false;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(37, 38, 39);
            richTextBox2.ForeColor = Color.White;
            richTextBox2.Location = new Point(555, 70);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(334, 271);
            richTextBox2.TabIndex = 90;
            richTextBox2.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Coral;
            label3.Location = new Point(617, 31);
            label3.Name = "label3";
            label3.Size = new Size(136, 20);
            label3.TabIndex = 91;
            label3.Text = "Verifica Computer";
            label3.TextAlign = ContentAlignment.BottomCenter;
            label3.Visible = false;
            // 
            // btnStop
            // 
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(623, 399);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(114, 45);
            btnStop.TabIndex = 92;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Visible = false;
            btnStop.Click += btnStop_Click;
            // 
            // FormRipristinoSO
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(901, 458);
            Controls.Add(btnStop);
            Controls.Add(label3);
            Controls.Add(richTextBox2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBox_sw);
            Controls.Add(checkBox_hw);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormRipristinoSO";
            Text = "FormRipristinoSO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Label label2;
        private ProgressBar progressBar1;
        private RichTextBox richTextBox1;
        private Button button1;
        private CheckBox checkBox_hw;
        private CheckBox checkBox_sw;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private RichTextBox richTextBox2;
        private Label label3;
        private Button btnStop;
    }
}