using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.Data.Analysis;
using Microsoft.AspNetCore.Html;
using System.IO;
using System.Net.Http;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using XPlot.Plotly;
using System.IO.Compression;
using Microsoft.DotNet.Interactive.Formatting;
using static Microsoft.DotNet.Interactive.Formatting.PocketViewTags;

namespace Cricket
{
    class Program
    {
        // Formats the table
        private static string DATASET_DIRECTORY = "t20s_male_csv2";
        private static string DATASET_FILE = "t20s_male_csv2.zip";
        private static string DATASET_URL = "https://cricsheet.org/downloads/";
        private static string FINAL_CSV = "t20_final.csv";
        private static string FINAL_CSV_OUTPUT = "t20_final_output.csv";

        public static void Foramte()
        {
            Formatter.Register(typeof(DataFrame),(dataFrame, writer) =>
            {
                var df = dataFrame as DataFrame;
                var headers = new List<IHtmlContent>();
                headers.Add(th(i("index")));
                headers.AddRange(df.Columns.Select(c => (IHtmlContent)th(c.Name)));
                var rows = new List<List<IHtmlContent>>();
                var take = 10;
                for (var i = 0; i < Math.Min(take, df.Rows.Count); i++)
                {
                    var cells = new List<IHtmlContent>();
                    cells.Add(td(i));
                    foreach (var obj in df.Rows[i])
                    {
                        cells.Add(td(obj));
                    }
                    rows.Add(cells);
                }

                var t = table(
                    thead(
                        headers),
                    tbody(
                        rows.Select(
                            r => tr(r))));

                writer.Write(t);
            }, "text/html");
        }

        public static async Task<DataFrame> LoadDatasetAsync(string url, string fileName)
        {
            // Delete previous data
            CleanPreviousData();

            // Loads zip file from remote URL
            var remoteFilePath = Path.Combine(url, fileName);
            using (var httpClient = new HttpClient())
            {
                var contents = await httpClient.GetByteArrayAsync(remoteFilePath);
                await File.WriteAllBytesAsync(fileName, contents);
            }

            // Unzip file -> Merge CSV -> Load to DataFrame
            if (File.Exists(fileName))
            {
                var extractedDirectory = Path.Combine(Directory.GetCurrentDirectory(), DATASET_DIRECTORY);

                try
                {
                    Type[] columnTypes = new[]
                    {
                        typeof(int),              // 0 - Match_id
                        typeof(string),           // 1 - Season
                        typeof(string),           // 2 - start_date
                        typeof(string),           // 3 - venue
                        typeof(string),           // 4 - innings
                        typeof(double),           // 5 - ball
                        typeof(string),           // 6 - batting_team
                        typeof(string),           // 7 - bowling_team
                        typeof(string),           // 8 - striker
                        typeof(string),           // 9 - non-striker
                        typeof(string),           // 10 - bowler
                        typeof(int),              // 11 - runs_off_bat
                        typeof(int),              // 12 - extras
                        typeof(int),              // 13 - wides
                        typeof(int),              // 14 - noballs
                        typeof(int),              // 15 - byes
                        typeof(int),              // 16 - legbyes
                        typeof(int),              // 17 - penalty
                        typeof(string),           // 18 - wicket_type
                        typeof(string),           // 19 - player_dismissed
                        typeof(string),           // 20 - other_wicket_type
                        typeof(string)            // 21 - other_player_dismissed
                    };

                    ZipFile.ExtractToDirectory(fileName, extractedDirectory);
                    MergeCsv(extractedDirectory, FINAL_CSV);
                    
                    return DataFrame.LoadCsv(FINAL_CSV_OUTPUT);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }

            return new DataFrame();
        }

        public static void CopyCsv(string source, string destination)
        {
            var culture = CultureInfo.InvariantCulture;
            using var reader = new StreamReader(source);
            using var csvIn = new CsvReader(reader, new CsvConfiguration(culture));
            using var recordsIn = new CsvDataReader(csvIn);
            using var writer = new StreamWriter(destination);
            using var outCsv = new CsvWriter(writer, culture);


            // Write Header
            csvIn.ReadHeader();
            var headers = csvIn.HeaderRecord;
            foreach (var header in headers)
            {
                outCsv.WriteField(header);
            }
            outCsv.NextRecord();

            // Write rows
            while (recordsIn.Read())
            {
                var columns = recordsIn.FieldCount;
                for (var index = 0; index < columns; index++)
                {
                    var cellValue = recordsIn.GetString(index);
                    outCsv.WriteField(cellValue);
                }
                outCsv.NextRecord();
            }
        }

        public static void MergeCsv(string sourceFolder, string destinationFile)
        {
            /*
             https://chris.koester.io/index.php/2017/01/27/combine-csv-files/
             C# script combines multiple csv files without duplicating headers.
             Combining 8 files with a combined total of about 9.2 million rows 
             took about 3.5 minutes on a network share and 44 seconds on an SSD.
            */

            // Specify wildcard search to match CSV files that will be combined
            string[] filePaths = Directory.GetFiles(sourceFolder, "*.csv");
            StreamWriter fileDest = new StreamWriter(destinationFile, true);

            int i;
            for (i = 0; i < filePaths.Length; i++)
            {
                string file = filePaths[i];

                string[] lines = File.ReadAllLines(file);

                if (i > 0)
                {
                    lines = lines.Skip(1).ToArray(); // Skip header row for all but first file
                }

                foreach (string line in lines)
                {
                    fileDest.WriteLine(line);
                }
            }

            fileDest.Close();
        }

        /// <summary>
        /// Cleans previous data present in current working directory
        /// </summary>
        public static void CleanPreviousData()
        {
            if (File.Exists(DATASET_FILE))
            {
                File.Delete(DATASET_FILE);
            }

            if (File.Exists(FINAL_CSV))
            {
                File.Delete(FINAL_CSV);
            }

            if (File.Exists(FINAL_CSV_OUTPUT))
            {
                File.Delete(FINAL_CSV_OUTPUT);
            }

            if (Directory.Exists(DATASET_DIRECTORY))
            {
                Directory.Delete(DATASET_DIRECTORY, true);
            }
        }
    }
}
