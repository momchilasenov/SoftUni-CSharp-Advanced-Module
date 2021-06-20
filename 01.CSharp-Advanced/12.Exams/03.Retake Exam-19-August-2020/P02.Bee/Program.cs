using System;
using System.Collections.Generic;

namespace P02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            const int flowersNeeded = 5;
            int flowersCount = 0;
            int currentRow = 0;
            int currentCol = 0;
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string moveCommand = Console.ReadLine();

            while (moveCommand != "End")
            {
                if (moveCommand == "right" && currentCol < matrix.GetLength(0)-1)
                {
                    matrix[currentRow, currentCol] = '.';
                    currentCol++;
                }
                else if (moveCommand == "down" && currentRow < matrix.GetLength(1) - 1)
                {
                    matrix[currentRow, currentCol] = '.';
                    currentRow++;
                }
                else if (moveCommand == "up" && currentRow > 0)
                {
                    matrix[currentRow, currentCol] = '.';
                    currentRow--;
                }
                else if (moveCommand == "left" && currentCol > 0)
                {
                    matrix[currentRow, currentCol] = '.';
                    currentCol--;
                }
                else
                {
                    matrix[currentRow, currentCol] = '.';
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[currentRow, currentCol] == 'f')
                {
                    matrix[currentRow, currentCol] = 'B';
                    flowersCount++;
                }
                else if (matrix[currentRow, currentCol] == 'O')
                {
                    matrix[currentRow, currentCol] = 'B';
                    continue;
                }
                else if (matrix[currentRow, currentCol] == '.')
                {
                    matrix[currentRow, currentCol] = 'B';
                }



                moveCommand = Console.ReadLine();
            }

            if (flowersCount< flowersNeeded)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {flowersNeeded-flowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }

            PrintMatrix(matrix);


        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
