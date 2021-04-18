using System;
using System.Linq;

namespace _05.SquareWithMaxSum_DynamicSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3; //the size of the biggest matrix 2=2x2 ; 3 = 3x3 etc...
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

            for (int row = 0; row < matrix.GetLength(0) - n + 1; row++) //exclude the rows we can't use 
            {
                for (int col = 0; col < matrix.GetLength(1) - n + 1; col++)
                {
                    int squareSum = 0;

                    for (int squareRow = row; squareRow < row + n; squareRow++)
                    {
                        for (int squareCol = col; squareCol < col + n; squareCol++)
                        {
                            squareSum += matrix[squareRow, squareCol];
                        }
                    }

                    if (squareSum > bestSum)
                    {
                        bestSum = squareSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row < maxRow + n; row++)
            {
                for (int col = maxCol; col < maxCol + n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
