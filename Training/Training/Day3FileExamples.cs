using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Training
{
    public class Day3FileExamples
    {
        private const string textFile1 = @"C:\Users\closs\source\repos\PowerAppsDotNetBatchNotes\Training\Training\TextFile1.txt";
        private const string textFile2 = @"C:\Users\closs\source\repos\PowerAppsDotNetBatchNotes\Training\Training\TextFile2.csv";
        private const string csvFile = @"C:\Users\closs\source\repos\PowerAppsDotNetBatchNotes\Training\Training\contacts.csv";

        //private string fileDir = Directory.GetCurrentDirectory();
        //private string fileDir = System.AppContext.BaseDirectory;
        //private string fileDir = Environment.CurrentDirectory;

        public void ReadFromTextFile1()
        {
            //string textFileContents = File.ReadAllText(textFile1);

            //Console.WriteLine($"All text {textFileContents}");

            //string[] eachLine = File.ReadAllLines(textFile1);

            //Console.WriteLine("================================");
            //int lineNumber = 1;
            //foreach (string line in eachLine)
            //{
            //    Console.WriteLine($"{lineNumber}. {line}");
            //    lineNumber++;
            //}

            using (StreamReader reader = new StreamReader(textFile1))
            {
                while (reader.Peek() > -1)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        public void WriteToTextFile()
        {
            //if (!File.Exists(textFile2))
            //{
            //    File.Create(textFile2);
            //}
                        
            using (StreamWriter writer = File.AppendText(textFile1))
            {
                writer.WriteLine("---------------------------------");
                writer.WriteLine("More text added to the end of the file");
                writer.Write("This text appears on a different line \n");
                writer.WriteLine(" - But this is on the same line as the last ");
                writer.WriteLine("---------------------------------");
            }
            

        }

        public IEnumerable<CSVData> ReadCsvData()
        {
            List<CSVData> csvData = new List<CSVData>();
            
            using StreamReader reader = new StreamReader(csvFile);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                csvData.Add(new CSVData(values[0], values[1], values[2]));
            }
            
            return csvData;
        }

        

    }
}
