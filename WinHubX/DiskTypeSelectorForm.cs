namespace WinHubX
{
    public partial class DiskTypeSelectorForm : Form
    {
        public string SelectedDriveType { get; private set; } = "Unknown";

        public DiskTypeSelectorForm()
        {
            InitializeComponent();
        }

        private void btnSSD_Click(object sender, EventArgs e)
        {
            SelectedDriveType = "SSD";
            DialogResult = DialogResult.OK;
        }

        private void btnNVMe_Click(object sender, EventArgs e)
        {
            SelectedDriveType = "SSD (NVMe)";
            DialogResult = DialogResult.OK;
        }

        private void btnHDD_Click(object sender, EventArgs e)
        {
            SelectedDriveType = "HDD";
            DialogResult = DialogResult.OK;
        }
    }
}
