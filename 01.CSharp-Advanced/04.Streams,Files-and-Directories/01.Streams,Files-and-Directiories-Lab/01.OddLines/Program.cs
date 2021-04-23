using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine(currentDirectory);

            using (StreamReader reader = new StreamReader("../../../reader.txt"))
            {
                string currentRow = reader.ReadLine();
                int row = 0;
                using (StreamWriter writer = new StreamWriter("../../../writer.txt"))
                {
                    while (currentRow != null)
                    {
                        if (row % 2 != 0)
                        {
                            writer.WriteLine(currentRow);
                        }
                        row++;
                        currentRow = reader.ReadLine();
                    }
                }
            }
        }
    }
}
