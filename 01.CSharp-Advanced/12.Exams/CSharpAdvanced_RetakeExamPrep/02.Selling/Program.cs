using System;
using System.Collections.Generic;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;
            int moneyNeeded = 50;
            int sum = 0;

            char[,] matrix = new char[n, n];

            int[] pillars = new int[4];
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        pillars[counter++] = row;
                        pillars[counter++] = col;
                    }
                }
            }

            while (sum < moneyNeeded)
            {
                string command = Console.ReadLine();

                matrix[currentRow, currentCol] = '-';

                if (command == "up" && IsInside(currentRow - 1, currentCol, n))
                {
                    currentRow--;
                }
                else if (command == "down" && IsInside(currentRow + 1, currentCol, n))
                {
                    currentRow++;
                }
                else if (command == "left" && IsInside(currentRow, currentCol - 1, n))
                {
                    currentCol--;
                }
                else if (command == "right" && IsInside(currentRow, currentCol + 1, n))
                {
                    currentCol++;
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(matrix[currentRow, currentCol]))
                {
                    int number = int.Parse(matrix[currentRow, currentCol].ToString());
                    sum += number;
                    matrix[currentRow, currentCol] = 'S';
                }
                if (matrix[currentRow, currentCol] == 'O')
                {
                    matrix[currentRow, currentCol] = '-';

                    int firstPillarRow = pillars[0];
                    int firstPillarCol = pillars[1];
                    int secondPillarRow = pillars[2];
                    int secondPillarCol = pillars[3];

                    if (firstPillarRow == currentRow && firstPillarCol == currentCol)
                    {
                        currentRow = secondPillarRow;
                        currentCol = secondPillarCol;
                    }
                    else
                    {
                        currentRow = firstPillarRow;
                        currentCol = firstPillarCol;
                    }

                    matrix[currentRow, currentCol] = 'S';
                }

            }

            if (sum >= moneyNeeded)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        private static bool IsInside(int currentRow, int currentCol, int n)
        {
            return currentRow >= 0 && currentRow < n
                && currentCol >= 0 && currentCol < n;
        }
    }
}
