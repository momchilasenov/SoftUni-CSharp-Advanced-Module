using System;

namespace P02.Beee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int polinatedFlowers = 0;
            int requiredFlowers = 5;

            char[,] matrix = new char[n, n];

            int currentRow = 0;
            int currentCol = 0;

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

            string command = Console.ReadLine();

            while (command != "End")
            {
                matrix[currentRow, currentCol] = '.';

                if (command == "up" && IsInside(currentRow - 1, currentCol, n))
                {
                    currentRow--;
                }
                else if (command == "right" && IsInside(currentRow, currentCol + 1, n))
                {
                    currentCol++;
                }
                else if (command == "left" && IsInside(currentRow, currentCol - 1, n))
                {
                    currentCol--;
                }
                else if (command == "down" && IsInside(currentRow + 1, currentCol, n))
                {
                    currentRow++;
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[currentRow, currentCol] == 'O')
                {
                    matrix[currentRow, currentCol] = '.';
                    continue;
                }
                if (matrix[currentRow, currentCol] == 'f')
                {
                    polinatedFlowers++;
                }

                matrix[currentRow, currentCol] = 'B';

                command = Console.ReadLine();
            }

            if (polinatedFlowers < requiredFlowers)
            {
                Console.WriteLine
                    ($"The bee couldn't pollinate the flowers, she needed {requiredFlowers - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine
                    ($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
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
        private static bool IsInside(int currentRow, int currentCol, int n)
        {
            return currentRow < n
                && currentRow >= 0
                && currentCol < n
                && currentCol >= 0;
        }
    }
}

