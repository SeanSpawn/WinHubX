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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRipristinoSO));
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
            resources.ApplyResources(btnBack, "btnBack");
            btnBack.Image = Properties.Resources.pngBackArrow;
            btnBack.Name = "btnBack";
            btnBack.UseMnemonic = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.Coral;
            label2.Name = "label2";
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(37, 38, 39);
            richTextBox1.ForeColor = Color.White;
            resources.ApplyResources(richTextBox1, "richTextBox1");
            richTextBox1.Name = "richTextBox1";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = Color.White;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonStart_Click;
            // 
            // checkBox_hw
            // 
            resources.ApplyResources(checkBox_hw, "checkBox_hw");
            checkBox_hw.ForeColor = Color.White;
            checkBox_hw.Name = "checkBox_hw";
            checkBox_hw.UseVisualStyleBackColor = true;
            checkBox_hw.CheckedChanged += checkBox_hw_CheckedChanged;
            // 
            // checkBox_sw
            // 
            resources.ApplyResources(checkBox_sw, "checkBox_sw");
            checkBox_sw.ForeColor = Color.White;
            checkBox_sw.Name = "checkBox_sw";
            checkBox_sw.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(dateTimePicker1, "dateTimePicker1");
            dateTimePicker1.Name = "dateTimePicker1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.FromArgb(37, 38, 39);
            richTextBox2.ForeColor = Color.White;
            resources.ApplyResources(richTextBox2, "richTextBox2");
            richTextBox2.Name = "richTextBox2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.Coral;
            label3.Name = "label3";
            // 
            // btnStop
            // 
            resources.ApplyResources(btnStop, "btnStop");
            btnStop.ForeColor = Color.White;
            btnStop.Name = "btnStop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // FormRipristinoSO
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
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
            Name = "FormRipristinoSO";
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