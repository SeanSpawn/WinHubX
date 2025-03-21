namespace WinHubX
{
    partial class DiskTypeSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button btnSSD;
        private Button btnNVMe;
        private Button btnHDD;
        private Label lblInstruction;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiskTypeSelectorForm));
            btnSSD = new Button();
            btnNVMe = new Button();
            btnHDD = new Button();
            lblInstruction = new Label();
            SuspendLayout();
            // 
            // btnSSD
            // 
            btnSSD.Location = new Point(45, 39);
            btnSSD.Name = "btnSSD";
            btnSSD.Size = new Size(150, 30);
            btnSSD.TabIndex = 1;
            btnSSD.Text = "SSD";
            btnSSD.UseVisualStyleBackColor = true;
            btnSSD.Click += btnSSD_Click;
            // 
            // btnNVMe
            // 
            btnNVMe.Location = new Point(45, 79);
            btnNVMe.Name = "btnNVMe";
            btnNVMe.Size = new Size(150, 30);
            btnNVMe.TabIndex = 2;
            btnNVMe.Text = "SSD (NVMe)";
            btnNVMe.UseVisualStyleBackColor = true;
            btnNVMe.Click += btnNVMe_Click;
            // 
            // btnHDD
            // 
            btnHDD.Location = new Point(45, 119);
            btnHDD.Name = "btnHDD";
            btnHDD.Size = new Size(150, 30);
            btnHDD.TabIndex = 3;
            btnHDD.Text = "HDD";
            btnHDD.UseVisualStyleBackColor = true;
            btnHDD.Click += btnHDD_Click;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 10F);
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Location = new Point(45, 9);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(156, 19);
            lblInstruction.TabIndex = 0;
            lblInstruction.Text = "Seleziona il tipo di disco:";
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DiskTypeSelectorForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            ClientSize = new Size(246, 162);
            Controls.Add(lblInstruction);
            Controls.Add(btnSSD);
            Controls.Add(btnNVMe);
            Controls.Add(btnHDD);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DiskTypeSelectorForm";
            Text = "Seleziona Tipo Disco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}