using System;

namespace P02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int[] burrows = new int[4];
            int burrowCount = 0;

            int currentRow = 0;
            int currentCol = 0;

            int foodQuantity = 0;
            int requiredFood = 10;

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
                    else if (matrix[row, col] == 'B')
                    {
                        burrows[burrowCount++] = row;
                        burrows[burrowCount++] = col;
                    }
                }
            }

            while (foodQuantity < requiredFood)
            {
                string command = Console.ReadLine();

                matrix[currentRow, currentCol] = '.';

                if (command == "up" && IsInside(currentRow - 1, currentCol, n))
                {
                    currentRow--;
                }
                else if (command == "down" && IsInside(currentRow + 1, currentCol, n))
                {
                    currentRow++;
                }
                else if (command == "right" && IsInside(currentRow, currentCol + 1, n))
                {
                    currentCol++;
                }
                else if (command == "left" && IsInside(currentRow, currentCol - 1, n))
                {
                    currentCol--;
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[currentRow,currentCol] == '*')
                {
                    foodQuantity++; 
                }
                else if (matrix[currentRow, currentCol] == 'B')
                {
                    int firstBurrowRow = burrows[0];
                    int firstBurrowCol = burrows[1];
                    int secondBurrowRow = burrows[2];
                    int secondBurrowCol = burrows[3];

                    matrix[currentRow, currentCol] = '.';

                    if (currentRow == firstBurrowRow && currentCol == firstBurrowCol)
                    {
                        currentRow = secondBurrowRow;
                        currentCol = secondBurrowCol;
                    }
                    else
                    {
                        currentRow = firstBurrowRow;
                        currentCol = firstBurrowCol;
                    }
                }

                matrix[currentRow, currentCol] = 'S';


            }

            if (foodQuantity >= requiredFood)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
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
