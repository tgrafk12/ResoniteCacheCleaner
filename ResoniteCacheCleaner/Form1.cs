using System.Diagnostics;

namespace ResoniteCacheCleaner
{
    public partial class Form1 : Form
    {
        private const int MaxLogEntries = 1000; // Limit the log size

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if Resonite.exe is running
                if (IsProcessRunning("Resonite"))
                {
                    MessageBox.Show("Resonite.exe is currently running. Please close it completely before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppendLog("Cleaning was aborted: Resonite.exe was running upon last attempt.");
                    return;
                }

                // Get the path of the current user
                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                // Build the full path dynamically
                string cacheFolderPath = Path.Combine(userProfilePath, @"AppData\Local\Temp\Yellow Dog Man Studios\Resonite\Cache");

                // Verify the directory exists
                if (Directory.Exists(cacheFolderPath))
                {
                    // Get the size of the folder before clearing
                    long folderSize = GetDirectorySize(cacheFolderPath);
                    string folderSizeFormatted = FormatSize(folderSize);

                    // Log the size before clearing
                    AppendLog($"Cache folder size before cleaning: {folderSizeFormatted}");

                    // Clear the contents of the folder
                    DeleteFilesInDirectory(cacheFolderPath);

                    // Log completion message
                    AppendLog($"Cache cleaning complete! Saved {folderSizeFormatted} in storage!");
                }
                else
                {
                    MessageBox.Show("The specified directory does not exist. Please Contact NalaTheThird");

                    AppendLog($"Error Code: 104 (Directory not found)");
                    return;
                }
            }
            catch (Exception ex)
            {
                // Handle errors and log them
                AppendLog($"An error occurred: {ex.Message}");
                MessageBox.Show($"Error: {ex.Message}. Please report this to NalaTheThird.");
            }
        }

        // Helper function to check if a process is running
        private bool IsProcessRunning(string processName)
        {
            return Process.GetProcessesByName(processName).Any();
        }

        // Helper function to get the size of a directory
        private long GetDirectorySize(string directoryPath)
        {
            long size = 0;

            // Get all files in the directory and subdirectories
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            return size;
        }

        // Helper function to delete files inside a directory
        private void DeleteFilesInDirectory(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    // Ensure hidden and read-only files can also be deleted
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file); // Delete each file
                }
                catch (Exception ex)
                {
                    // Log any errors deleting files
                    AppendLog($"Error deleting file {file}: {ex.Message}");
                }
            }
        }

        // Helper function to format the size to human-readable format
        private string FormatSize(long sizeInBytes)
        {
            if (sizeInBytes < 1024)
                return $"{sizeInBytes} bytes";
            else if (sizeInBytes < 1048576)
                return $"{sizeInBytes / 1024.0:F2} KB";
            else if (sizeInBytes < 1073741824)
                return $"{sizeInBytes / 1048576.0:F2} MB";
            else
                return $"{sizeInBytes / 1073741824.0:F2} GB";
        }

        // Helper function to append log entries with size limit
        private void AppendLog(string message)
        {
            // Get the current timestamp
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Create the log message with timestamp
            string logMessage = $"{timestamp} - {message}";

            // Append the log message to the TextBox
            txtLog.AppendText(logMessage + "\r\n");

            // Limit the number of log entries (MaxLogEntries is a constant that you define)
            if (txtLog.Lines.Length > MaxLogEntries)
            {
                txtLog.Lines = txtLog.Lines.Skip(txtLog.Lines.Length - MaxLogEntries).ToArray();
            }
        }

        private void btnCopyLog_Click(object sender, EventArgs e)
        {
            // Copy the log text to the clipboard
            Clipboard.SetText(txtLog.Text);
            MessageBox.Show("Log copied to clipboard!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Perform cleanup if necessary
            txtLog.Clear(); // Clear the log to release memory
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }
    }
}
