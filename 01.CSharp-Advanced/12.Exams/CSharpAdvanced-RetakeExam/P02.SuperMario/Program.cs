using System;
using System.Linq;

namespace P02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesOfMario = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                string rowData = Console.ReadLine();
                matrix[row] = new char[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];

                    if (matrix[row][col] == 'M')
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

                matrix[enemyRow][enemyCol] = 'B';

                if (moveCommand == "w" && IsInside(currentRow - 1, currentCol, matrix))
                {
                    matrix[currentRow][currentCol] = '-';
                    currentRow--;
                }
                else if (moveCommand == "s" && IsInside(currentRow + 1, currentCol, matrix))
                {
                    matrix[currentRow][currentCol] = '-';
                    currentRow++;
                }
                else if (moveCommand == "a" && IsInside(currentRow, currentCol - 1, matrix))
                {
                    matrix[currentRow][currentCol] = '-';
                    currentCol--;
                }
                else if (moveCommand == "d" && IsInside(currentRow, currentCol + 1, matrix))
                {
                    matrix[currentRow][currentCol] = '-';
                    currentCol++;
                }
                else
                {
                    livesOfMario--;

                    if (livesOfMario <= 0)
                    {
                        Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                        matrix[currentRow][currentCol] = 'X';
                        break;
                    }

                    continue;
                }

                livesOfMario--;

                if (livesOfMario <= 0)
                {
                    Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                    matrix[currentRow][currentCol] = 'X';
                    break;
                }

                if (matrix[currentRow][currentCol] == 'B')
                {
                    livesOfMario -= 2;

                    if (livesOfMario > 0)
                    {
                        matrix[currentRow][currentCol] = 'M';
                    }
                    else
                    {
                        matrix[currentRow][currentCol] = 'X';
                        Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
                        break;
                    }
                }
                else if (matrix[currentRow][currentCol] == 'P')
                {
                    matrix[currentRow][currentCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
                    break;
                }
                else
                {
                    matrix[currentRow][currentCol] = 'M';
                }

            }

            PrintMatrix(matrix);
        }

        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix[row].Length && col >= 0 && col < matrix[col].Length;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }
    }
}
