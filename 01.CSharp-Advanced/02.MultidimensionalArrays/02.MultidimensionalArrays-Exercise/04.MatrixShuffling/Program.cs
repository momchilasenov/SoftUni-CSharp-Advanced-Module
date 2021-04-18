using System;
using System.Linq;

namespace _04.MatrixShuffling
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

            bool isValid = false;

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] inputData = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputData[0] == "swap" && inputData.Length == 5 && matrix.Length > 1)
                {
                    int first = int.Parse(inputData[1]);
                    int second = int.Parse(inputData[2]);
                    int third = int.Parse(inputData[3]);
                    int fourth = int.Parse(inputData[4]);

                    isValid = CheckCoordinates(matrix, first, second, third, fourth);

                    if (isValid)
                    {
                        string temp = matrix[first, second];
                        matrix[first, second] = matrix[third, fourth];
                        matrix[third, fourth] = temp;

                        PrintMatrix(matrix);

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

                input = Console.ReadLine().ToLower();
            }
        }

        static void ReadMatrix(string[,] matrix)
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

        static bool CheckCoordinates(string[,] matrix, int first, int second, int third, int fourth)
        {
            if (first >= 0 && first < matrix.GetLength(0) &&
                second >= 0 && second < matrix.GetLength(1) &&
                third >= 0 && third < matrix.GetLength(0) &&
                fourth >= 0 && fourth < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}

