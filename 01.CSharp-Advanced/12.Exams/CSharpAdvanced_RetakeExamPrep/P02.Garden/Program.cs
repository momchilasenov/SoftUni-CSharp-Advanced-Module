using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];

            //Create matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            List<int> flowerPositions = new List<int>();

            //Plant Flowers
            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int row = int.Parse(input[0].ToString());
                int col = int.Parse(input[2].ToString());

                flowerPositions.Add(row);
                flowerPositions.Add(col);

                if (IsInside(row, col, n, m) == false)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                input = Console.ReadLine();
            }

            //Bloom Flowers
            for (int i = 0; i < flowerPositions.Count; i++)
            {
                int flowerRow = flowerPositions[i++];
                int flowerCol = flowerPositions[i];

                BloomFlower(n, m, matrix, ref flowerRow, ref flowerCol);

            }

            //Print matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        private static void BloomFlower(int n, int m, int[,] matrix, ref int row, ref int col)
        {
            int staticRow = row;
            int staticCol = col;

            matrix[row, col] = 1;

            //moveUp
            while (IsInside(row - 1, col, n, m) != false)
            {
                row--;
                matrix[row, col] += 1;
            }

            ResetPosition(out row, out col, staticRow, staticCol);

            //moveDown
            while (IsInside(row + 1, col, n, m) != false)
            {
                row++;
                matrix[row, col] += 1;
            }

            ResetPosition(out row, out col, staticRow, staticCol);
            //moveRight
            while (IsInside(row, col + 1, n, m) != false)
            {
                col++;
                matrix[row, col] += 1;
            }

            ResetPosition(out row, out col, staticRow, staticCol);
            //moveLeft
            while (IsInside(row, col - 1, n, m) != false)
            {
                col--;
                matrix[row, col] += 1;
            }

        }

        private static void ResetPosition(out int row, out int col, int staticRow, int staticCol)
        {
            row = staticRow;
            col = staticCol;
        }

        private static bool IsInside(int row, int col, int n, int m)
        {
            return row >= 0 && row < n
                && col >= 0 && col < m;
        }
    }
}
