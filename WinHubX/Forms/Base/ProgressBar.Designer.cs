using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinHubX.Forms.Base
{
    partial class ProgressForm
    {
        private System.ComponentModel.IContainer components = null;
        private ProgressBar progressBar;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            progressBar = new ProgressBar();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            resources.ApplyResources(progressBar, "progressBar");
            progressBar.Name = "progressBar";
            // 
            // lblStatus
            // 
            resources.ApplyResources(lblStatus, "lblStatus");
            lblStatus.Name = "lblStatus";
            // 
            // ProgressForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProgressForm";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
