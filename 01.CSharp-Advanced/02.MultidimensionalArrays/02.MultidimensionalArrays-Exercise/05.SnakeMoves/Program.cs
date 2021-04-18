using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int rows = rowsAndCols[0];
            //int cols = rowsAndCols[1];

            ////SoftUni

            //char[,] matrix = new char[rows, cols];

            //char[] snake = Console.ReadLine().ToCharArray();

            //Queue<char> snakeQueue = new Queue<char>();

            //while (snakeQueue.Count < matrix.Length)
            //{
            //    for (int i = 0; i<snake.Length; i++)
            //    {
            //        snakeQueue.Enqueue(snake[i]);
            //    }
            //}

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    if (row % 2 == 0)
            //    {
            //        for (int col = 0; col < matrix.GetLength(1); col++)
            //        {
            //            matrix[row, col] = snakeQueue.Dequeue();
            //        }
            //    }

            //    else if (row % 2 != 0)
            //    {
            //        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            //        {
            //            matrix[row, col] = snakeQueue.Dequeue();
            //        }
            //    }
            //}

            //for (int row = 0; row<matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col<matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col]);
            //    }
            //    Console.WriteLine();
            //}


            //Alternative Solution
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();
            int currentLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[currentLetter];
                        currentLetter++;
                        if (currentLetter == snake.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }

                else if (row % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[currentLetter];
                        currentLetter++;
                        if (currentLetter == snake.Length)
                        {
                            currentLetter = 0;
                        }
                    }
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
    }
}
