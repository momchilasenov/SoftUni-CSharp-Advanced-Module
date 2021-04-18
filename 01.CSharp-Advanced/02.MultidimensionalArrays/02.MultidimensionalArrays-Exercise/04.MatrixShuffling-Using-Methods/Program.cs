using System;
using System.Linq;

namespace _04.MatrixShuffling_Using_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] matrix = new string[rows, cols];

            ReadMatrix(matrix);

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                VerifyInput(matrix, input);

                input = Console.ReadLine().ToLower();
            }

        }
        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputData = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void VerifyInput(string[,] matrix, string input)
        {
            string[] inputData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            if (inputData.Length == 5 && inputData[0] == "swap" && matrix.Length > 1)
            {
                int first = int.Parse(inputData[1]);
                int second = int.Parse(inputData[2]);
                int third = int.Parse(inputData[3]);
                int fourth = int.Parse(inputData[4]);

                if (first >= 0 && first < matrix.GetLength(0) &&
                    second >= 0 && second < matrix.GetLength(1) &&
                    third >= 0 && third < matrix.GetLength(0) &&
                    fourth >= 0 && fourth < matrix.GetLength(1))
                {
                    SwapElements(matrix, first, second, third, fourth);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        static void SwapElements(string[,] matrix, int first, int second, int third, int fourth)
        {
            string temp = matrix[first, second];
            matrix[first, second] = matrix[third, fourth];
            matrix[third, fourth] = temp;

            PrintMatrix(matrix);
        }
    }
}
