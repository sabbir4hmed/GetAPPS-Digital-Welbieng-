using System.Diagnostics;

namespace GetAPPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Execute ADB command to get device model and serial number
                string deviceInfoOutput = ExecuteAdbCommand("shell getprop ro.product.model")?.Trim();
                string serialNumberOutput = ExecuteAdbCommand("shell getprop ro.serialno")?.Trim();

                if (string.IsNullOrEmpty(deviceInfoOutput) || string.IsNullOrEmpty(serialNumberOutput))
                {
                    MessageBox.Show("Failed to retrieve device information. Make sure the device is connected and ADB is properly configured.");
                    return;
                }

                string deviceModel = deviceInfoOutput.Replace(" ", "_");
                string serialNumber = serialNumberOutput.Replace(" ", "_");

                // Execute ADB command to get list of installed third-party applications
                string appListOutput = ExecuteAdbCommand("shell pm list packages -3");

                if (string.IsNullOrEmpty(appListOutput))
                {
                    MessageBox.Show("No third-party applications found on the device.");
                    return;
                }

                // Save the app list to a text file on the desktop
                string fileName = $"{deviceModel}_{serialNumber}_AppList.txt";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(appListOutput);
                }

                // Count the number of packages and display in label
                int packageCount = appListOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                label1.Text = packageCount.ToString() +" " + "Apps Installed";

                MessageBox.Show($"App list exported successfully to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private string ExecuteAdbCommand(string arguments)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
        }
    }
}
