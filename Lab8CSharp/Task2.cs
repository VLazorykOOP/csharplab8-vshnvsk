using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        public static void Main_Task2()
        {
            string inputFile = "C:\\Users\\YANA\\source\\repos\\csharplab8-vshnvsk\\Lab8CSharp\\inputTask2.txt";
            string outputFile = "C:\\Users\\YANA\\source\\repos\\csharplab8-vshnvsk\\Lab8CSharp\\outputTask2.txt";

            string inputText = File.ReadAllText(inputFile);

            string pattern = @"\b[АаОоЕеУуИиІіЄєЯяЮюЇї]\w*\b";

            string result = Regex.Replace(inputText, pattern, "");

            File.WriteAllText(outputFile, result);

            Console.WriteLine("Ukrainian words starting with a vowel letter have been removed successfully");
        }
    }
}
