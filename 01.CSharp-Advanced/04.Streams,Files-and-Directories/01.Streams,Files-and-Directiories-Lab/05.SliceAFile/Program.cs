using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (FileStream stream = new FileStream("../../../textToBeSliced.txt", FileMode.Open))
            //{
            //    byte[] buffer = new byte[stream.Length / 4];

            //    int filesCounter = 0;

            //    while (stream.Read(buffer, 0, buffer.Length)>0) //четем докато не изчетем целия текст
            //    {
            //        filesCounter++;

            //        using (FileStream writeStream = new FileStream($"../../../slicedFile-{filesCounter}.txt",FileMode.Create, FileAccess.Write))
            //        {
            //            writeStream.Write(buffer, 0, buffer.Length);
            //        }
            //    }
            //}

            //Решение Виктор

            using (FileStream streamReader = new FileStream("../../../input.txt", FileMode.Open))
            {
                int chunkSize = (int)streamReader.Length / 4;

                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;

                    using (FileStream streamWriter = new FileStream($"../../../output-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (count < chunkSize)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            Console.WriteLine(buffer[0]);
                            streamWriter.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;

                        }
                    }
                }
            }



        }
    }
}
