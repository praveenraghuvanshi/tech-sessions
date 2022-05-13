using System;

namespace Cricket
{
    public class Program
    {
        private static string DatasetFile = "t20_cleaned.csv";

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Prediction.Execute(DatasetFile);

            Console.ReadLine();
        }
    }
}
