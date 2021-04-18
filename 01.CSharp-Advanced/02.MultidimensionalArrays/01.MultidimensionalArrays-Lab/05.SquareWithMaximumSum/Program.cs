using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = data[c];
                }
            }

            int currentSum = 0;
            int bestSum = int.MinValue;
            
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currentSum = 0;

                    int firstElement = matrix[row + 0, col + 0];
                    int secondElement = matrix[row + 0, col + 1];
                    int thirdElement = matrix[row + 1, col + 0];
                    int fourthElement = matrix[row + 1, col + 1];

                    currentSum = firstElement + secondElement + thirdElement + fourthElement;

                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row <= maxRow + 1; row++)
            {
                for (int col = maxCol; col <= maxCol + 1; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
