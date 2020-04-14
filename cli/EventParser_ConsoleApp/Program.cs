using CommandLineParser.Arguments;
using CommandLineParser.Exceptions;
using CsvHelper;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EventParser.ConsoleApp
{
    public static class Arguments
    {
        public static string connString;
        public static string input;
        public static string output;
    }

    internal class Program
    {
        // Logfile is generated with five column headers instead of six. This method ensures the logfile matches the column name headings specified in DataRecords.
        private static void AddMissingHeader()
        {
            Console.WriteLine("Replacing log file header...");
            StreamReader reader = new StreamReader(Arguments.input);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, "Level,Date and Time,Source,Event ID,Task Category", "Level,DateAndTime,Source,EventID,TaskCategory,InformationDump");

            StreamWriter writer = new StreamWriter(Arguments.input); //overwrites existing file instead of creating new file
            writer.Write(content);
            writer.Close();
        }

        // Extracts account name and generates Unique ID. Writes parsed CSV file to specified output.
        private static void ParseLog()
        {
            Console.WriteLine("Parsing log file...");

            using (var sr = new StreamReader(Arguments.input))
            {
                using (var sw = new StreamWriter(Arguments.output))
                {
                    // CSVHelper initialization.
                    var reader = new CsvReader(sr);
                    var writer = new CsvWriter(sw);

                    // Counters for records processed, and unique-ID logic respectively.
                    int i = 0;
                    int x = 0;

                    // CSVReader will  read the whole file into an enumerable.
                    IEnumerable records = reader.GetRecords<DataRecord>().ToList();

                    foreach (DataRecord record in records)
                    {
                        // RegEx to extract account name.
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
                        //Console.WriteLine($"Records processed: {i}");
                    }
                }
            }
        }

        // Imports parsed CSV file into MS SQL Server through a Stored Procedure.
        private static void ImportToMSSQL()
        {
            Console.WriteLine("Importing log file into MSSQL server...");

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

        private static void Main(string[] args)
        {
            CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();

            ValueArgument<string> inputLogFile = new ValueArgument<string>('i', "input", "Specify filepath of CSV file to process");
            inputLogFile.Optional = false;
            ValueArgument<string> outputLogFile = new ValueArgument<string>('o', "output", "Specify filepath to save CSV file");
            outputLogFile.Optional = false;
            ValueArgument<string> connectionString = new ValueArgument<string>('c', "connection", "Specify connection string");
            connectionString.Optional = false;

            parser.Arguments.Add(inputLogFile);
            parser.Arguments.Add(outputLogFile);
            parser.Arguments.Add(connectionString);

            //parser.ShowUsageHeader = "Welcome to EventParser!";
            //parser.ShowUsageFooter = "Thank you for using the application.";
            //parser.ShowUsage();

            try
            {
                parser.ParseCommandLine(args);
                if (inputLogFile.Parsed)
                { Arguments.input = inputLogFile.Value; }
                if (outputLogFile.Parsed)
                { Arguments.output = outputLogFile.Value; }
                if (connectionString.Parsed)
                { Arguments.connString = connectionString.Value; }
            }
            catch (CommandLineException e)
            {
                Console.WriteLine(e.Message);
                parser.ShowUsage();
            }

            // Validation
            if (Arguments.input != null && Arguments.output != null && Arguments.connString != null)
            {
                Console.WriteLine($"PROCESSING: {Arguments.input}");
                Stopwatch sw = Stopwatch.StartNew();

                AddMissingHeader();
                ParseLog();
                ImportToMSSQL();

                Console.WriteLine("Success.");
                Console.WriteLine($"Time elapsed: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}
