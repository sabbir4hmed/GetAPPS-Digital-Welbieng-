using System.Diagnostics;
using System.Globalization;

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

                // Get the country or region of the PC
                string countryRegion = GetCountryRegion();

                // Execute ADB command to get list of installed third-party applications
                string appListOutput = ExecuteAdbCommand("shell pm list packages -3");

                if (string.IsNullOrEmpty(appListOutput))
                {
                    MessageBox.Show("No third-party applications found on the device.");
                    return;
                }

                // Get desktop path
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Create folder for the device model if it doesn't exist
                string folderPath = Path.Combine(desktopPath, $"{deviceModel}_{countryRegion}");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Save the app list to a text file on the desktop
                string fileName = $"{deviceModel}_{serialNumber}_{countryRegion}_AppList.txt";
                // Combine folder path with file name
                string filePath = Path.Combine(folderPath, fileName);
                

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

        private string GetCountryRegion()
        {

            RegionInfo region = RegionInfo.CurrentRegion;

            return region.DisplayName.Replace(" ", "_");

            //throw new NotImplementedException();
        }

        private string ExecuteAdbCommand(string arguments)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "adb.exe",
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
