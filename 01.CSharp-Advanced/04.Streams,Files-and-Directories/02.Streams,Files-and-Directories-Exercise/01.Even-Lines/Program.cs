using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    int row = 0;

                    while (!reader.EndOfStream)
                    {
                        string currentRow = reader.ReadLine();

                        if (row % 2 == 0)
                        {
                            Regex regex = new Regex("[-,.!?]");
                            currentRow = regex.Replace(currentRow, "@");

                            var rowData = currentRow.Split().ToArray().Reverse();

                            writer.WriteLine(string.Join(' ', rowData));
                        }

                        row++;

                    }
                }
            }
        }
    }
}
