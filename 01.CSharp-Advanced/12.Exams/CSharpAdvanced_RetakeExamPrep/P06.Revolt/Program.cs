using System;

namespace P02.Revolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int currentRow = 0;
            int currentCol = 0;

            int lastPositionRow = 0;
            int lastPositionCol = 0;

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
                    }
                }
            }

            for (int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();

                matrix[currentRow, currentCol] = '-';

                lastPositionRow = currentRow;
                lastPositionCol = currentCol;

                MoveRevolt(matrix, ref currentRow, ref currentCol, command);

                if (matrix[currentRow, currentCol] == 'B')
                {
                    MoveRevolt(matrix, ref currentRow, ref currentCol, command);
                }
                if (matrix[currentRow, currentCol] == 'T')
                {
                    currentRow = lastPositionRow;
                    currentCol = lastPositionCol;
                }
                if (matrix[currentRow, currentCol] == 'F')
                {
                    matrix[currentRow, currentCol] = 'f';
                    Console.WriteLine("Player won!");
                    break;
                }

                matrix[currentRow, currentCol] = 'f';

            }

            if (matrix[currentRow,currentCol] != 'F')
            {
                Console.WriteLine("Player lost!");
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

        private static void MoveRevolt(char[,] matrix, ref int currentRow, ref int currentCol, string command)
        {
            if (command == "up")
            {
                if (currentRow - 1 < 0)
                {
                    currentRow = matrix.GetLength(0) - 1;
                }
                else
                {
                    currentRow--;
                }
            }
            else if (command == "down")
            {
                if (currentRow + 1 == matrix.GetLength(0))
                {
                    currentRow = 0;
                }
                else
                {
                    currentRow++;
                }
            }
            else if (command == "right")
            {
                if (currentCol + 1 == matrix.GetLength(1))
                {
                    currentCol = 0;
                }
                else
                {
                    currentCol++;
                }
            }
            else if (command == "left")
            {
                if (currentCol - 1 < 0)
                {
                    currentCol = matrix.GetLength(1) - 1;
                }
                else
                {
                    currentCol--;
                }
            }
        }
    }
}
