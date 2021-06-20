using System;
using System.Linq;

namespace P02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] garden = new int[rows, cols];

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                int[] plantArray = input.Split().Select(int.Parse).ToArray();
                int plantRow = plantArray[0];
                int plantCol = plantArray[1];

                if (plantRow < 0 || plantRow > garden.GetLength(0)
                    || plantCol < 0 || plantCol > garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    garden[plantRow, plantCol] = 1;

                    BloomFlowers(garden, plantRow, plantCol);
                }

                input = Console.ReadLine();
            }

            

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row,col] + " ");
                }
                Console.WriteLine();
            }


        }

        static void BloomFlowers(int[,] garden, int currentRow, int currentCol)
        {
            int defaultRow = currentRow;
            int defaultCol = currentCol;

            while (currentCol > 0) //left
            {
                currentCol--;
                garden[currentRow, currentCol] += 1;
            }
            ResetPosition(out currentRow, out currentCol, defaultRow, defaultCol);

            while (currentRow > 0) //up
            {
                currentRow--;
                garden[currentRow, currentCol] += 1;
            }
            ResetPosition(out currentRow, out currentCol, defaultRow, defaultCol);

            while (currentCol < garden.GetLength(1)-1) //right
            {
                currentCol++;
                garden[currentRow, currentCol] += 1;
            }
            ResetPosition(out currentRow, out currentCol, defaultRow, defaultCol);

            while (currentRow < garden.GetLength(0)-1) //down
            {
                currentRow++;
                garden[currentRow, currentCol] += 1;
            } 
        }

        private static void ResetPosition(out int currentRow, out int currentCol, int defaultRow, int defaultCol)
        {
            currentRow = defaultRow;
            currentCol = defaultCol;
        }
    }
}
