namespace WinHubX.Forms.Base
{
    partial class FormMonitoraggio
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
            pic_termcpu = new PictureBox();
            pic_termgpu = new PictureBox();
            labelCpuTemp = new Label();
            labelGpuTemp = new Label();
            BarRAM = new WinHubX.Forms.Bottoni.CircularProgressBar();
            BarCPU = new WinHubX.Forms.Bottoni.CircularProgressBar();
            swapButton1 = new WinHubX.Forms.Bottoni.BottoniSwap();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btn_pulisciram = new Button();
            btn_puliscicpu = new Button();
            panel1 = new Panel();
            radioButton_taskbar = new RadioButton();
            radioButton_notifica = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pic_termcpu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_termgpu).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pic_termcpu
            // 
            pic_termcpu.Image = Properties.Resources.term_giallo;
            pic_termcpu.Location = new Point(628, 286);
            pic_termcpu.Name = "pic_termcpu";
            pic_termcpu.Size = new Size(57, 112);
            pic_termcpu.SizeMode = PictureBoxSizeMode.Zoom;
            pic_termcpu.TabIndex = 3;
            pic_termcpu.TabStop = false;
            // 
            // pic_termgpu
            // 
            pic_termgpu.Image = Properties.Resources.term_giallo;
            pic_termgpu.Location = new Point(108, 286);
            pic_termgpu.Name = "pic_termgpu";
            pic_termgpu.Size = new Size(57, 112);
            pic_termgpu.SizeMode = PictureBoxSizeMode.Zoom;
            pic_termgpu.TabIndex = 4;
            pic_termgpu.TabStop = false;
            // 
            // labelCpuTemp
            // 
            labelCpuTemp.AutoSize = true;
            labelCpuTemp.Location = new Point(633, 247);
            labelCpuTemp.Name = "labelCpuTemp";
            labelCpuTemp.Size = new Size(38, 15);
            labelCpuTemp.TabIndex = 5;
            labelCpuTemp.Text = "label1";
            // 
            // labelGpuTemp
            // 
            labelGpuTemp.AutoSize = true;
            labelGpuTemp.Location = new Point(108, 247);
            labelGpuTemp.Name = "labelGpuTemp";
            labelGpuTemp.Size = new Size(38, 15);
            labelGpuTemp.TabIndex = 6;
            labelGpuTemp.Text = "label2";
            // 
            // BarRAM
            // 
            BarRAM.Location = new Point(67, 98);
            BarRAM.Maximum = 100;
            BarRAM.Minimum = 0;
            BarRAM.Name = "BarRAM";
            BarRAM.Size = new Size(135, 133);
            BarRAM.TabIndex = 7;
            BarRAM.Text = "circularProgressBar1";
            BarRAM.Value = 30;
            // 
            // BarCPU
            // 
            BarCPU.Location = new Point(594, 98);
            BarCPU.Maximum = 100;
            BarCPU.Minimum = 0;
            BarCPU.Name = "BarCPU";
            BarCPU.Size = new Size(135, 133);
            BarCPU.TabIndex = 9;
            BarCPU.Text = "circularProgressBar2";
            BarCPU.Value = 30;
            // 
            // swapButton1
            // 
            swapButton1.AutoSize = true;
            swapButton1.Location = new Point(456, 24);
            swapButton1.MinimumSize = new Size(45, 24);
            swapButton1.Name = "swapButton1";
            swapButton1.OffBackColor = Color.Gray;
            swapButton1.OffToggleColor = Color.Gainsboro;
            swapButton1.OnBackColor = Color.MediumSlateBlue;
            swapButton1.OnToggleColor = Color.WhiteSmoke;
            swapButton1.Size = new Size(45, 24);
            swapButton1.TabIndex = 10;
            swapButton1.UseVisualStyleBackColor = true;
            swapButton1.CheckedChanged += swapButton1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 70);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 11;
            label1.Text = "RAM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(633, 70);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 12;
            label2.Text = "CPU";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 29);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 13;
            label3.Text = "Attivare il monitoraggio?";
            // 
            // btn_pulisciram
            // 
            btn_pulisciram.FlatStyle = FlatStyle.Flat;
            btn_pulisciram.Location = new Point(335, 148);
            btn_pulisciram.Name = "btn_pulisciram";
            btn_pulisciram.Size = new Size(125, 32);
            btn_pulisciram.TabIndex = 14;
            btn_pulisciram.Text = "Pulisci RAM";
            btn_pulisciram.UseVisualStyleBackColor = true;
            btn_pulisciram.Click += btn_pulisciram_Click;
            // 
            // btn_puliscicpu
            // 
            btn_puliscicpu.FlatStyle = FlatStyle.Flat;
            btn_puliscicpu.Location = new Point(335, 286);
            btn_puliscicpu.Name = "btn_puliscicpu";
            btn_puliscicpu.Size = new Size(125, 32);
            btn_puliscicpu.TabIndex = 15;
            btn_puliscicpu.Text = "Pulisci CPU";
            btn_puliscicpu.UseVisualStyleBackColor = true;
            btn_puliscicpu.Click += btn_puliscicpu_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton_taskbar);
            panel1.Controls.Add(radioButton_notifica);
            panel1.Location = new Point(709, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(174, 63);
            panel1.TabIndex = 16;
            // 
            // radioButton_taskbar
            // 
            radioButton_taskbar.AutoSize = true;
            radioButton_taskbar.ForeColor = Color.White;
            radioButton_taskbar.Location = new Point(7, 37);
            radioButton_taskbar.Name = "radioButton_taskbar";
            radioButton_taskbar.Size = new Size(129, 19);
            radioButton_taskbar.TabIndex = 1;
            radioButton_taskbar.TabStop = true;
            radioButton_taskbar.Text = "Nascondi in taskbar";
            radioButton_taskbar.UseVisualStyleBackColor = true;
            radioButton_taskbar.CheckedChanged += radioButton_taskbar_CheckedChanged;
            // 
            // radioButton_notifica
            // 
            radioButton_notifica.AutoSize = true;
            radioButton_notifica.ForeColor = Color.White;
            radioButton_notifica.Location = new Point(6, 6);
            radioButton_notifica.Name = "radioButton_notifica";
            radioButton_notifica.Size = new Size(169, 19);
            radioButton_notifica.TabIndex = 0;
            radioButton_notifica.TabStop = true;
            radioButton_notifica.Text = "Nascondi in area di notifica";
            radioButton_notifica.UseVisualStyleBackColor = true;
            radioButton_notifica.CheckedChanged += radioButton_notifica_CheckedChanged;
            // 
            // FormMonitoraggio
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(885, 419);
            Controls.Add(panel1);
            Controls.Add(btn_puliscicpu);
            Controls.Add(btn_pulisciram);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(swapButton1);
            Controls.Add(BarCPU);
            Controls.Add(BarRAM);
            Controls.Add(labelGpuTemp);
            Controls.Add(labelCpuTemp);
            Controls.Add(pic_termgpu);
            Controls.Add(pic_termcpu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMonitoraggio";
            Text = "<";
            FormClosing += FormMonitoraggio_FormClosing;
            Load += FormMonitoraggio_Load;
            ((System.ComponentModel.ISupportInitialize)pic_termcpu).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_termgpu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Bottoni.CircularProgressBar BarRAM;
        private PictureBox pic_termcpu;
        private PictureBox pic_termgpu;
        private Label labelCpuTemp;
        private Label labelGpuTemp;
        private Bottoni.CircularProgressBar BarCPU;
        private Bottoni.BottoniSwap swapButton1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn_pulisciram;
        private Button btn_puliscicpu;
        private Panel panel1;
        private RadioButton radioButton_taskbar;
        private RadioButton radioButton_notifica;
    }
}