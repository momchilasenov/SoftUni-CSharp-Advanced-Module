using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            // element is on main diagonal -> row == col
            // element is on second diagonal -> col == n - 1 - row

            //int n = int.Parse(Console.ReadLine());

            //int[,] matrix = new int[n, n];

            //int primarySum = 0;
            //int secondarySum = 0;

            //int colCounter = -1;

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        matrix[row, col] = inputData[col];

            //        if (row == col)
            //        {
            //            primarySum += matrix[row, col];
            //        }

                    
            //    }
            //}

            //for (int rows = matrix.GetLength(0) - 1; rows >= 0; rows--)
            //{
            //    colCounter++;
            //    secondarySum += matrix[rows, colCounter];
            //}

            //Console.WriteLine(Math.Abs(primarySum - secondarySum));

            //Another Solution
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputData[col];

                    if (row == col)
                    {
                        primarySum += matrix[row, col];
                    }

                    if (col == n - 1 - row) //2 ifs because the center square is on both diagonals
                    {
                        secondarySum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
