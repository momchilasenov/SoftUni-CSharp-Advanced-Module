using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] arrayData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArray[row] = new int[arrayData.Length];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = arrayData[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputData = input.Split().ToArray();
                string command = inputData[0];
                int row = int.Parse(inputData[1]);
                int col = int.Parse(inputData[2]);
                int number = int.Parse(inputData[3]);

                if (row < jaggedArray.Length && row >= 0 && col >= 0 && col < jaggedArray[row].Length)
                {
                    if (command == "Add")
                    {
                        jaggedArray[row][col] += number;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= number;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }
            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
