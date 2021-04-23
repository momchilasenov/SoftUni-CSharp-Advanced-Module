using System;
using System.IO;

namespace _05.SliceAFile_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5; //how much files do you want to generate
            var totalSize = new FileInfo("../../../output-File.txt").Length; //get the total file size

            var sizePerFile = (int)Math.Ceiling(totalSize / 5.0); 

            using(FileStream reader = new FileStream("../../../output-File.txt", FileMode.Open))
            {
                for (int i = 1; i <= n; i++)
                {
                    byte[] buffer = new byte[sizePerFile];

                    int bytesRead = reader.Read(buffer, 0, sizePerFile);

                    using(FileStream writer = new FileStream($"../../../file-{i}.txt", FileMode.OpenOrCreate))
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                } 
            }
            


        }
    }
}
