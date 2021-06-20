using System;
using System.Collections.Generic;

namespace P02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;

            int lastPositionRow = 0;
            int lastPositionCol = 0;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        currentRow = row;
                        currentCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            for (int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();

                lastPositionRow = currentRow;
                lastPositionCol = currentCol;

                MoveCar(ref currentRow, ref currentCol, matrix, command);

                if (matrix[currentRow, currentCol] == 'B')
                {
                    MoveCar(ref currentRow, ref currentCol, matrix, command);
                }
                else if (matrix[currentRow, currentCol] == 'T')
                {
                    currentRow = lastPositionRow;
                    currentCol = lastPositionCol;
                }
                else if (matrix[currentRow, currentCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    break;
                }
            }

            if (matrix[currentRow, currentCol] != 'F')
            {
                Console.WriteLine("Player lost!");
            }
            matrix[currentRow, currentCol] = 'f';
            PrintMatrix(matrix);
        }

        private static void MoveCar(ref int currentRow, ref int currentCol, char[,] matrix, string command)
        {
            if (command == "right")
            {
                if (currentCol < matrix.GetLength(1) - 1)
                {
                    currentCol++;
                }
                else
                {
                    currentCol = 0;
                }
            }
            else if (command == "down")
            {
                if (currentRow < matrix.GetLength(1) - 1)
                {
                    currentRow++;
                }
                else
                {
                    currentRow = 0;
                }
            }
            else if (command == "left")
            {
                if (currentCol > 0)
                {
                    currentCol--;
                }
                else
                {
                    currentCol = matrix.GetLength(1) - 1;
                }
            }
            else if (command == "up")
            {
                if (currentRow > 0)
                {
                    currentRow--;
                }
                else
                {
                    currentRow = matrix.GetLength(0) - 1;
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

    }
}
