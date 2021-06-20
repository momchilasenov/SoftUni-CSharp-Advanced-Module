using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int foodNeeded = 10;
            int n = int.Parse(Console.ReadLine());
            int currentRow = 0;
            int currentCol = 0;
            int foodEaten = 0;

            List<Lair> lairs = new List<Lair>();

            char[,] matrix = new char[n, n];

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
                    else if (matrix[row,col] == 'B')
                    {
                        Lair lair = new Lair(row, col);
                        lairs.Add(lair);
                    }
                }
            }

            while (foodEaten < 10)
            {
                string moveCommand = Console.ReadLine();

                matrix[currentRow, currentCol] = '.';

                if (moveCommand == "right" && currentCol < matrix.GetLength(1) - 1)
                {
                    currentCol++;
                }
                else if (moveCommand == "down" && currentRow < matrix.GetLength(0) - 1)
                {
                    currentRow++;
                }
                else if (moveCommand == "left" && currentCol > 0)
                {
                    currentCol--;
                }
                else if (moveCommand == "up" && currentRow > 0)
                {
                    currentRow--;
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[currentRow, currentCol] == '*')
                {
                    foodEaten++;
                }
                else if (matrix[currentRow, currentCol] == 'B')
                {
                    matrix[currentRow, currentCol] = '.';

                    foreach(Lair lair in lairs)
                    {
                        if (lair.Row != currentRow && lair.Col != currentCol)
                        {
                            currentRow = lair.Row;
                            currentCol = lair.Col;
                        }
                    }
                }

                matrix[currentRow, currentCol] = 'S';
            }

            if (foodEaten >= foodNeeded)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
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

    public class Lair
    {
        public Lair(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; set; }

        public int Col { get; set; }
    }
}
