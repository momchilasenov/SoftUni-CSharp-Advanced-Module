using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Core.IO
{
    public class FileReader : IReader
    {
        private readonly string[] fileLines;
        private const string filePath = "../../../input.txt";

        private int rowCounter;

        public FileReader()
        {
            this.fileLines = File.ReadAllLines(filePath);
        }

        public string ReadLine()
        {
            return this.fileLines[this.rowCounter++];
        }
    }
}
