using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using(StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    int counter = 0;

                    string currentRow = reader.ReadLine();

                    while (currentRow != null)
                    {
                        counter++;
                        writer.WriteLine($"{counter}. {currentRow}");
                        currentRow = reader.ReadLine();
                    }
                }
            }
        }
    }
}
