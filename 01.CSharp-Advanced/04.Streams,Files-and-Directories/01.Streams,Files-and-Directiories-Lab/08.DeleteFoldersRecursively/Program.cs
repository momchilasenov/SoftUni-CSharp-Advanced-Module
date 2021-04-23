using System;
using System.IO;

namespace _08.DeleteFoldersRecursively
{
    class Program
    {
        static void Main(string[] args)
        {
            //if you put for path "C:\\" everything in C folder will be deleted
            string folderPath = Console.ReadLine();
            DeleteFoldersRecursively(folderPath);

        }


        static void DeleteFoldersRecursively(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                File.Delete(filePath);
            }

            Directory.Delete(folderPath);

        }


    }
}
