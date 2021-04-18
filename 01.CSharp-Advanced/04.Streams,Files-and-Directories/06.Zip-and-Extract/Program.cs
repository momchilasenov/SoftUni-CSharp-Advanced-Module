using System;
using System.IO;
using System.IO.Compression;

namespace _06.Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"../../../Media", @"../../../Zip-Folder/myZip.zip");
            ZipFile.ExtractToDirectory(@"../../../Zip-Folder/myZip.zip", @"../../../Unzip-Folder");
        }
    }
}
