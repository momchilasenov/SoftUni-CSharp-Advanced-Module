using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = data[0];
            int cols = data[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int colSum;

            for (int col=0; col < matrix.GetLength(1); col++)
            {
                colSum = 0;

                for (int row = 0; row<matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                    
                }
                Console.WriteLine(colSum);
            }

        }
    }
}
