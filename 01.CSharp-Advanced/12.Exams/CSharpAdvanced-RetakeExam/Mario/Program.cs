using System;

namespace Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesOfMario = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            while (livesOfMario > 0)
            {
                string[] input = Console.ReadLine().Split();
                string moveCommand = input[0].ToString().ToLower();
                int enemyRow = int.Parse(input[1]);
                int enemyCol = int.Parse(input[2]);

                matrix[enemyRow, enemyCol] = 'B';
                matrix[currentRow, currentCol] = '-';

                int previousRow = currentRow;
                int previousCol = currentCol;

                if (moveCommand == "w" && IsInside(currentRow - 1, currentCol, matrix))
                {
                    currentRow -= 1;
                }
                else if (moveCommand == "s" && IsInside(currentRow + 1, currentCol, matrix))
                {
                    currentRow += 1;
                }
                else if (moveCommand == "a" && IsInside(currentRow, currentCol - 1, matrix))
                {
                    currentCol -= 1;
                }
                else if (moveCommand == "d" && IsInside(currentRow, currentCol + 1, matrix))
                {
                    currentCol += 1;
                }
                else
                {
                    currentRow = previousRow;
                    currentCol = previousCol;
                    matrix[currentRow, currentCol] = 'M';
                }

                livesOfMario--;

                if (livesOfMario <= 0)
                {
                    matrix[currentRow, currentCol] = 'X';
                    Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                    break;
                }

                if (matrix[currentRow, currentCol] == 'B')
                {
                    livesOfMario -= 2;

                    if (livesOfMario <= 0)
                    {
                        matrix[currentRow, currentCol] = 'X';
                        Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                        break;
                    }
                }

                if (matrix[currentRow, currentCol] == 'P')
                {
                    matrix[currentRow, currentCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
                    break;
                }
                else
                {
                    matrix[currentRow, currentCol] = 'M';
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
