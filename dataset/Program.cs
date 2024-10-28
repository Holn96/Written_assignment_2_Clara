namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CleanDataSet();
        }
        static bool ContainsSpecialCharacters(string input)
        {
            // Define the regex for special characters (adjust as necessary)
            Regex regex = new Regex(@"[!@#$%^&*(),.?""'{}|<>]");
            return regex.IsMatch(input);
        }
        static void CleanDataSet()
        {
            string inputFilePath = "C:\\test\\file.csv";
            string outputFilePath = "C:\\test\\ddleanedFile.csv";

            // Read the CSV file
            List<string> lines = new List<string>(File.ReadAllLines(inputFilePath));

            // If the CSV contains a header, keep it
            string header = lines[0]; // Assuming the first line is the header
            List<string> cleanedLines = new List<string> { header };

            // Process the rest of the lines
            for (int i = 1; i < lines.Count; i++)
            {
                string[] columns = lines[i].Split(',');

                // Check if any column contains special characters
                if (!columns.Any(column => ContainsSpecialCharacters(column)))
                {
                    cleanedLines.Add(lines[i]);
                }
            }

            // Write the cleaned CSV to disk
            File.WriteAllLines(outputFilePath, cleanedLines);

            Console.WriteLine($"Cleaned CSV saved to {outputFilePath}");
        }
    }
}

