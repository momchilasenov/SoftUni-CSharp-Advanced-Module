using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter folder path: ") ;
            string folderPath = Console.ReadLine();

            string[] files = Directory.GetFiles(folderPath);

            int fileSize = 0;

            foreach (string filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                fileSize += (int)file.Length;

                Console.WriteLine("Full name: " + file.FullName);
                Console.WriteLine("Name: " + file.Name);
                Console.WriteLine("Length: " + file.Length);
                Console.WriteLine();
            }

            Console.WriteLine($"Total size of folder: {fileSize/1024/1024/1024.0:f3} GB");
        }
    }
}
