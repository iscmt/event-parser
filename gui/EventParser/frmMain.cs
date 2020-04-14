using CsvHelper;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EventParser.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = ConfigurationManager.AppSettings["ConnectionString"];
        }

        private ConnectionSettings connectionSettings = new ConnectionSettings();

        public void btnSetConnectionString_Click(object sender, EventArgs e)
        {
            frmConnection frm = new frmConnection();
            frm.ShowDialog();
            this.txtConnectionString.Text = Arguments.connString;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFile_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttonValidate()
        {
            btnStart.Enabled = Arguments.input != null && Arguments.output != null && Arguments.connString != null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCSVLog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Open CSV log file",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = @"CSV files (*.csv)|*.csv",
                //Filter = @"All files (*.*)|*.*|CSV files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (openCSVLog.ShowDialog() == DialogResult.OK)
            {
                txtOpenLogFile.Text = openCSVLog.FileName;
                Arguments.input = openCSVLog.FileName;
                buttonValidate();
            }
        }

        private void btnLogOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCSVLog = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Save formatted CSV log file",

                CheckPathExists = true,

                Filter = @"All files (*.*)|*.*|CSV files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (saveCSVLog.ShowDialog() == DialogResult.OK)
            {
                txtSaveLogFile.Text = saveCSVLog.FileName;
                Arguments.output = saveCSVLog.FileName;
                buttonValidate();
            }
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            Arguments.connString = txtConnectionString.Text;
            buttonValidate();
        }

        private void setAppSetting(string key, string value)
        {
            // Load App Settings.
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                                    System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Check if key exists in the settings.
            if (config.AppSettings.Settings[key] != null)
            {
                // If key exists, delete it.
                config.AppSettings.Settings.Remove(key);
            }
            // Add new key-value pair.
            config.AppSettings.Settings.Add(key, value);
            // Save the changed settings.
            config.Save(ConfigurationSaveMode.Modified);
        }

        // Logfile is generated with five column headers instead of six. This method ensures the logfile matches the column name headings specified in DataRecords.
        private void AddMissingHeader()
        {
            txtOutput.AppendText("Replacing log file header...\r\n");
            StreamReader reader = new StreamReader(Arguments.input);
            string content = reader.ReadToEnd();
            reader.Close(); 

            content = Regex.Replace(content, "Level,Date and Time,Source,Event ID,Task Category", "Level,DateAndTime,Source,EventID,TaskCategory,InformationDump");

            StreamWriter writer = new StreamWriter(Arguments.input); //overwrites existing file instead of creating new file
            writer.Write(content);
            writer.Close();
        }

        // Extracts account name and generates Unique ID. Writes parsed CSV file to specified output.
        public void ParseLog()
        {
            txtOutput.AppendText("Parsing log file...\r\n");

            using (var sr = new StreamReader(Arguments.input))
            {
                using (var sw = new StreamWriter(Arguments.output))
                {
                    // CSVHelper initialization.
                    var reader = new CsvReader(sr);
                    var writer = new CsvWriter(sw);

                    // Counters for records processed, and unique-ID logic respectively.
                    // int i = 0;
                    int x = 0;

                    // CSVReader will  read the whole file into an enumerable.
                    IEnumerable records = reader.GetRecords<DataRecord>().ToList();

                    foreach (DataRecord record in records)
                    {
                        // RegEx pattern to extract account name.
                        string pattern1 = @"(?<=New Logon:\r\n\tSecurity\ ID\:\t\t).*";
                        //string pattern2 = @"REGEX GOES HERE";

                        string uniqueID_timestamp = record.DateAndTime;

                        // Logic for UniqueID.
                        var uniqueID = $"{uniqueID_timestamp}-{x++}";

                        // Order columns in CSV file will be written.
                        writer.WriteField(uniqueID);
                        writer.WriteField(record.Level);
                        writer.WriteField(record.DateAndTime);
                        writer.WriteField(record.Source);
                        writer.WriteField(record.EventID);
                        writer.WriteField(record.TaskCategory);

                        string str = record.InformationDump;
                        if (Regex.IsMatch(str, pattern1))
                        {
                            var matches = Regex.Matches(str, pattern1);
                            foreach (Match m in matches)
                            {
                                string accountName = m.Value;
                                writer.WriteField(accountName);
                            }
                        }
                        else
                        {
                            // There are instances where a record has no account name to be extracted.
                            writer.WriteField("Account name unavailable.");
                        }

                        //if (Regex.IsMatch(str, pattern2))
                        //{
                        //    var matches = Regex.Matches(str, pattern2);
                        //    foreach (Match m in matches)
                        //    {
                        //        string extractedField = m.Value;

                        //        //extractedField = extractedField.Replace(@"", "");
                        //        writer.WriteField(extractedField);
                        //    }
                        //}
                        //else
                        //{
                        //    writer.WriteField("Extracted field unavailable.");
                        //}

                        // Ensure end-of-record is specified when using WriteField method.
                        writer.NextRecord();

                        // Display number of records processed.
                        // i++
                        //i = i + 1;
                        //txtOutput.AppendText($"Records processed: {i}");
                    }
                }
            }
        }

        // Imports parsed CSV file into MS SQL Server through a Stored Procedure.
        public void ImportToMSSQL()
        {
            txtOutput.AppendText("Importing log file into MSSQL server...\r\n");

            string connectionString = Arguments.connString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ImportLogs", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // See Stored Procedure.
                    cmd.Parameters.Add("@filepath", SqlDbType.VarChar).Value = Arguments.output;

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            // Save the connection string to app settings.
            setAppSetting("ConnectionString", Arguments.connString);

            txtOutput.AppendText($"Begin processing: {Arguments.input} \r\n");

            try
            {
                AddMissingHeader();
                ParseLog();
                ImportToMSSQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
                return;
            }

            txtOutput.AppendText("Done."); // fix to only output if no errors are returned
        }
    }
}