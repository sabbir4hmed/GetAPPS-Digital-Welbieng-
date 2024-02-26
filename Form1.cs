using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Net;

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

                // Get the latitude and longitude using a web service
                string latitude = "";
                string longitude = "";

                using (WebClient wc = new WebClient())
                {
                    string response = wc.DownloadString("http://ip-api.com/json/");
                    JObject json = JObject.Parse(response);
                    latitude = json["lat"].ToString();
                    longitude = json["lon"].ToString();
                }

               string placename = Getplacename(longitude, latitude);

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
                string folderPath = Path.Combine(desktopPath, $"{deviceModel}_{placename}");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Save the app list to a text file on the desktop
                string fileName = $"{deviceModel}_{serialNumber}_{latitude}_{longitude}_AppList.txt";
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

        private string Getplacename(string longitude, string latitude)
        {
            //string apiKey = "AIzaSyAMeQ5jkhgFPgwyHxdObkeQ0LoVagCLrBs"; // Replace with your actual API key
            string apiKey = "AIzaSyArg3tjawe0G5pKVX5kPb84-V2jdAPat1o"; // Replace with your actual API key
            string apiUrl = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={latitude},{longitude}&inputtype=textquery&fields=name&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(responseBody);

                    // Check if the response contains a valid result
                    if (json["candidates"] != null && json["candidates"].HasValues)
                    {
                        string placeName = json["candidates"][0]["name"].ToString();
                        return placeName;
                    }
                    else
                    {
                        return "Unknown";
                    }
                }
                else
                {
                    return "Unknown";
                }
            }

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
