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
            resources.ApplyResources(btnSSD, "btnSSD");
            btnSSD.Name = "btnSSD";
            btnSSD.UseVisualStyleBackColor = true;
            btnSSD.Click += btnSSD_Click;
            // 
            // btnNVMe
            // 
            resources.ApplyResources(btnNVMe, "btnNVMe");
            btnNVMe.Name = "btnNVMe";
            btnNVMe.UseVisualStyleBackColor = true;
            btnNVMe.Click += btnNVMe_Click;
            // 
            // btnHDD
            // 
            resources.ApplyResources(btnHDD, "btnHDD");
            btnHDD.Name = "btnHDD";
            btnHDD.UseVisualStyleBackColor = true;
            btnHDD.Click += btnHDD_Click;
            // 
            // lblInstruction
            // 
            resources.ApplyResources(lblInstruction, "lblInstruction");
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Name = "lblInstruction";
            // 
            // DiskTypeSelectorForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(37, 38, 39);
            Controls.Add(lblInstruction);
            Controls.Add(btnSSD);
            Controls.Add(btnNVMe);
            Controls.Add(btnHDD);
            Name = "DiskTypeSelectorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}