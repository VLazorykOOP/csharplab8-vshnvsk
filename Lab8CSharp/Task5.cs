using System;

namespace Task5
{
    class Program
    {
        public static void Main_Task5()
        {
            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();

            string folder1Path = @"d:\temp\" + surname + "1"; 
            string folder2Path = @"d:\temp\" + surname + "2"; 
            string allFolderPath = @"d:\temp\ALL"; 

            try
            {
                // Перевіряємо наявність папок та видаляємо їх, якщо вони вже існують
                if (Directory.Exists(folder1Path))
                    Directory.Delete(folder1Path, true);
                if (Directory.Exists(folder2Path))
                    Directory.Delete(folder2Path, true);
                if (Directory.Exists(allFolderPath))
                    Directory.Delete(allFolderPath, true);

                // Створюємо папки
                Directory.CreateDirectory(folder1Path);
                Directory.CreateDirectory(folder2Path);

                // 1. Створення файлів і запис в них тексту
                string t1FilePath = Path.Combine(folder1Path, "t1.txt");
                string t2FilePath = Path.Combine(folder1Path, "t2.txt");
                string t3FilePath = Path.Combine(folder2Path, "t3.txt");

                File.WriteAllText(t1FilePath, "Вишньовська Яна Іванівна №1, 2003 року народження, місце проживання м. Чернівці");
                File.WriteAllText(t2FilePath, "Вишньовська Яна Іванівна №2, 2003 року народження, місце проживання м. Чернівці");

                // 2. Зчитування та запис тексту з файлів
                string t1Content = File.ReadAllText(t1FilePath);
                string t2Content = File.ReadAllText(t2FilePath);
                File.WriteAllText(t3FilePath, t1Content + Environment.NewLine + t2Content);

                // 3. Перенесення файлу t2.txt у папку <прізвище_студента>2
                File.Move(t2FilePath, Path.Combine(folder2Path, "t2.txt"));

                // 4. Копіювання файлу t1.txt у папку <прізвище_студента>2
                File.Copy(t1FilePath, Path.Combine(folder2Path, "t1.txt"), true);

                // 5. Перейменування папок
                Directory.Move(folder2Path, allFolderPath);
                Directory.Delete(folder1Path, true);

                // 6. Виведення інформації про файли папки All
                string[] allFiles = Directory.GetFiles(allFolderPath);
                Console.WriteLine("Information about the files in the All folder:");
                foreach (string file in allFiles)
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
