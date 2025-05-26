using WinHubX.Bottoni;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitoraggio));
            pic_termcpu = new PictureBox();
            pic_termgpu = new PictureBox();
            labelCpuTemp = new Label();
            labelGpuTemp = new Label();
            BarRAM = new CircularProgressBar();
            BarCPU = new CircularProgressBar();
            swapButton1 = new BottoniSwap();
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
            resources.ApplyResources(pic_termcpu, "pic_termcpu");
            pic_termcpu.Image = Properties.Resources.term_verde;
            pic_termcpu.Name = "pic_termcpu";
            pic_termcpu.TabStop = false;
            // 
            // pic_termgpu
            // 
            resources.ApplyResources(pic_termgpu, "pic_termgpu");
            pic_termgpu.Image = Properties.Resources.term_giallo;
            pic_termgpu.Name = "pic_termgpu";
            pic_termgpu.TabStop = false;
            // 
            // labelCpuTemp
            // 
            resources.ApplyResources(labelCpuTemp, "labelCpuTemp");
            labelCpuTemp.Name = "labelCpuTemp";
            // 
            // labelGpuTemp
            // 
            resources.ApplyResources(labelGpuTemp, "labelGpuTemp");
            labelGpuTemp.Name = "labelGpuTemp";
            // 
            // BarRAM
            // 
            resources.ApplyResources(BarRAM, "BarRAM");
            BarRAM.Maximum = 100;
            BarRAM.Minimum = 0;
            BarRAM.Name = "BarRAM";
            BarRAM.Value = 30;
            // 
            // BarCPU
            // 
            resources.ApplyResources(BarCPU, "BarCPU");
            BarCPU.Maximum = 100;
            BarCPU.Minimum = 0;
            BarCPU.Name = "BarCPU";
            BarCPU.Value = 30;
            // 
            // swapButton1
            // 
            resources.ApplyResources(swapButton1, "swapButton1");
            swapButton1.Name = "swapButton1";
            swapButton1.OffBackColor = Color.Gray;
            swapButton1.OffToggleColor = Color.Gainsboro;
            swapButton1.OnBackColor = Color.MediumSlateBlue;
            swapButton1.OnToggleColor = Color.WhiteSmoke;
            swapButton1.UseVisualStyleBackColor = true;
            swapButton1.CheckedChanged += swapButton1_CheckedChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // btn_pulisciram
            // 
            resources.ApplyResources(btn_pulisciram, "btn_pulisciram");
            btn_pulisciram.Name = "btn_pulisciram";
            btn_pulisciram.UseVisualStyleBackColor = true;
            btn_pulisciram.Click += btn_pulisciram_Click;
            // 
            // btn_puliscicpu
            // 
            resources.ApplyResources(btn_puliscicpu, "btn_puliscicpu");
            btn_puliscicpu.Name = "btn_puliscicpu";
            btn_puliscicpu.UseVisualStyleBackColor = true;
            btn_puliscicpu.Click += btn_puliscicpu_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(radioButton_taskbar);
            panel1.Controls.Add(radioButton_notifica);
            panel1.Name = "panel1";
            // 
            // radioButton_taskbar
            // 
            resources.ApplyResources(radioButton_taskbar, "radioButton_taskbar");
            radioButton_taskbar.ForeColor = Color.White;
            radioButton_taskbar.Name = "radioButton_taskbar";
            radioButton_taskbar.TabStop = true;
            radioButton_taskbar.UseVisualStyleBackColor = true;
            radioButton_taskbar.CheckedChanged += radioButton_taskbar_CheckedChanged;
            // 
            // radioButton_notifica
            // 
            resources.ApplyResources(radioButton_notifica, "radioButton_notifica");
            radioButton_notifica.ForeColor = Color.White;
            radioButton_notifica.Name = "radioButton_notifica";
            radioButton_notifica.TabStop = true;
            radioButton_notifica.UseVisualStyleBackColor = true;
            radioButton_notifica.CheckedChanged += radioButton_notifica_CheckedChanged;
            // 
            // FormMonitoraggio
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
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

        private CircularProgressBar BarRAM;
        private PictureBox pic_termcpu;
        private PictureBox pic_termgpu;
        private Label labelCpuTemp;
        private Label labelGpuTemp;
        private CircularProgressBar BarCPU;
        private BottoniSwap swapButton1;
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