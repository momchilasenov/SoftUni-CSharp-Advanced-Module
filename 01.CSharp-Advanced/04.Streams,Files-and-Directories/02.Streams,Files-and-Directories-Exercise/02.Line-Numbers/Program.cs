using System;
using System.IO;
using System.Linq;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input.txt");
            string[] newLine = new string[lines.Length];

            int lettersCount = 0;
            int marksCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                lettersCount = GetLetters(line);
                marksCount = GetMarks(line);

                newLine[i] = $"Line {i+1}: {lines[i]} ({lettersCount})({marksCount})";
            }

            File.WriteAllLines("../../../output.txt", newLine);

        }

        static int GetLetters(string line)
        {
            int counter = 0;

            for (int j = 0; j < line.Length; j++)
            {
                if (char.IsLetter(line[j]))
                {
                    counter++;
                }
            }

            return counter;
        }

        static int GetMarks(string line)
        {
            int counter = 0;
            char[] marks = new char[] { ',', '.', '-', '?', '!', ':', '"', '\'' };

            for (int i = 0; i < line.Length; i++)
            {
                if (marks.Contains(line[i]))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
