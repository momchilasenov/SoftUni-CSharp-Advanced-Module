﻿using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../fileCopy.png", FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];

                    while (reader.Position != reader.Length)
                    {
                        int bytesRead = reader.Read(buffer, 0, buffer.Length);

                        writer.Write(buffer, 0, buffer.Length);
                    }

                }
            }
        }
    }
}
