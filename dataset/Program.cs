namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CleanDataSet();
        }
        static bool DoesItContainSpecialCharacters(string input)
        {
            var regex = new Regex(@"[!@#$%^&*(),.?""'{}|<>]");
            return regex.IsMatch(input);
        }

        static void CleanDataSet()
        {
            string inputFilePath = "C:\\test\\file.csv";
            string outputFilePath = "C:\\test\\ddleanedFile.csv";

            var lines = new List<string>(File.ReadAllLines(inputFilePath));

            string header = lines[0]; 
            var cleanedLines = new List<string> { header };

            for (int i = 1; i < lines.Count; i++)
            {
                string[] columns = lines[i].Split(',');

                if (!columns.Any(column => DoesItContainSpecialCharacters(column)))
                {
                    cleanedLines.Add(lines[i]);
                }
            }

            File.WriteAllLines(outputFilePath, cleanedLines);

            Console.WriteLine($"CSV file is cleaned and saved to {outputFilePath}");
        }
    }
}

