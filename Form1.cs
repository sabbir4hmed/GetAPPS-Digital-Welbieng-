using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace GetAPPS
{
    public partial class Form1 : Form
    {

        private readonly string[] numbers =
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160", "161", "162", "163", "164", "165", "166", "167", "168", "169", "170", "171", "172", "173", "174", "175", "176", "177", "178", "179", "180", "181", "182", "183", "184", "185", "186", "187", "188", "189", "190", "191", "192", "193", "194", "195", "196", "197", "198", "199", "200"
        };

        public Form1()
        {
            InitializeComponent();

            comboBox.Items.AddRange(numbers);
            Array.Sort(numbers);
            comboBox.KeyPress += ComboBox_KeyPress;
          
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Find the first item starting with the pressed key
            var index = Array.FindIndex(numbers, number => number.StartsWith(e.KeyChar.ToString(), StringComparison.InvariantCultureIgnoreCase));

            // If found, select the item and scroll to it
            if (index != -1)
            {
                comboBox.SelectedIndex = index;
                comboBox.Select();
            }

            //throw new NotImplementedException();
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





                // Get the selected district from the dropdown
                string selectedDistrict = comboBoxDistrict.SelectedItem.ToString();

                string seletednumber = comboBox.SelectedIndex.ToString();

                comboBoxDistrict.KeyPress += ComboBoxDistrict_KeyPress;


                //string placename = Getplacename(longitude, latitude);

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
                string folderPath = Path.Combine(desktopPath, $"{deviceModel}_{selectedDistrict}");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Save the app list to a text file on the desktop
                string fileName = $"{deviceModel}_{serialNumber}_{selectedDistrict}_AppList.txt";
                // Combine folder path with file name
                string filePath = Path.Combine(folderPath, fileName);


                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(appListOutput);
                }

                // Count the number of packages and display in label
                int packageCount = appListOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                label1.Text = packageCount.ToString() + " " + "Apps Installed";

                MessageBox.Show($"App list exported successfully to {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ComboBoxDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {

            var index = comboBoxDistrict.SelectedIndex;

            // If found, select the item and scroll to it
            if (index != -1)
            {
                comboBoxDistrict.SelectedIndex = index;
                comboBoxDistrict.Select();
            }


           // throw new NotImplementedException();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DevInfo devInfo = new DevInfo();
            devInfo.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
