using System;
using System.Linq;

namespace _05.SquareWithMaxSum_SecondDynamicSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray(); //7, 9
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

            int bestSum = int.MinValue;

            int maxRow = 0;
            int maxCol = 0;

            //set the size of the matrix you want to find the max sum of elements for
            int subMatrixRows = 3;
            int subMatrixCols = 3;

            for (int row = 0; row < matrix.GetLength(0) - subMatrixRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - subMatrixCols + 1; col++)
                {
                    int subMatrixSum = 0;

                    for (int subRow = 0; subRow < subMatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCols; subCol++)
                        {
                            subMatrixSum += matrix[subRow + row, subCol + col]; 
                        }
                    }

                    if (subMatrixSum > bestSum)
                    {
                        bestSum = subMatrixSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = 0; row < subMatrixRows; row++)
            {
                for (int col = 0; col < subMatrixCols; col++)
                {
                    Console.Write(matrix[maxRow + row, maxCol + col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(bestSum);

        }
    }
}

