using System;
using System.IO;

namespace _07.RecursiveFolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();
            long totalSize = ScanFolderRecursively(folderPath); //calling the method
            Console.WriteLine($"Total size in bytes: {totalSize}");
            Console.WriteLine($"Total size in KB: {totalSize/1024}");
        }

        static long ScanFolderRecursively(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            long fileSize = 0;

            foreach (string filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                fileSize += (int)file.Length;

                Console.WriteLine(file.FullName);
                Console.WriteLine(file.Length);
                Console.WriteLine(file.Extension);
            }

            string[] directories = Directory.GetDirectories(folderPath);

            foreach (var directory in directories)
            {
                fileSize += ScanFolderRecursively(directory); //извикваме метода за всички подпапки, всички деца
            }


            return fileSize;
        }
    }
}
