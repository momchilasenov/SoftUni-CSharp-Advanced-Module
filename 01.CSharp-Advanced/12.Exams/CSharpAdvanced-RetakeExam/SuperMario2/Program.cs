//using System;
//using System.Linq;

//namespace P02.SuperMario
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int livesOfMario = int.Parse(Console.ReadLine());

//            int n = int.Parse(Console.ReadLine());

//            char[][] matrix = new char[n][];

//            int currentRow = 0;
//            int currentCol = 0;

//            for (int row = 0; row < matrix.Length; row++)
//            {
//                string rowData = Console.ReadLine();
//                matrix[row] = new char[matrix.Length];

//                for (int col = 0; col < matrix[row].Length; col++)
//                {
//                    matrix[row][col] = rowData[col];
//                }
//            }

//            while (livesOfMario > 0)
//            {
//                char[] inputData = Console.ReadLine()
//                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
//                .Select(char.Parse)
//                .ToArray();

//                //string[] input = Console.ReadLine().Split(' ', StringSplitOptions.None);
//                char moveCommand = inputData[0];
//                int enemyRow = int.Parse(inputData[1].ToString());
//                int enemyCol = int.Parse(inputData[2].ToString());

//                matrix[enemyRow, enemyCol] = 'B';

//                if (moveCommand == 'W' && IsInside(currentRow - 1, currentCol, n))
//                {
//                    matrix[currentRow, currentCol] = '-';
//                    currentRow--;
//                }
//                else if (moveCommand == 'S' && IsInside(currentRow + 1, currentCol, n))
//                {
//                    matrix[currentRow, currentCol] = '-';
//                    currentRow++;
//                }
//                else if (moveCommand == 'A' && IsInside(currentRow, currentCol - 1, n))
//                {
//                    matrix[currentRow, currentCol] = '-';
//                    currentCol--;
//                }
//                else if (moveCommand == 'D' && IsInside(currentRow, currentCol + 1, n))
//                {
//                    matrix[currentRow, currentCol] = '-';
//                    currentCol++;
//                }
//                else
//                {
//                    livesOfMario--;

//                    if (livesOfMario <= 0)
//                    {
//                        Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
//                        matrix[currentRow, currentCol] = 'X';
//                        break;
//                    }

//                    continue;
//                }

//                livesOfMario--;

//                if (livesOfMario <= 0)
//                {
//                    Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
//                    matrix[currentRow, currentCol] = 'X';
//                    break;
//                }

//                if (matrix[currentRow, currentCol] == 'B')
//                {
//                    livesOfMario -= 2;

//                    if (livesOfMario > 0)
//                    {
//                        matrix[currentRow, currentCol] = 'M';
//                    }
//                    else
//                    {
//                        matrix[currentRow, currentCol] = 'X';
//                        Console.WriteLine($"Mario died at {currentRow};{currentCol}.");
//                        break;
//                    }
//                }
//                else if (matrix[currentRow, currentCol] == 'P')
//                {
//                    matrix[currentRow, currentCol] = '-';
//                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
//                    break;
//                }
//                else
//                {
//                    matrix[currentRow, currentCol] = 'M';
//                }

//            }

//            PrintMatrix(matrix);
//        }

//        private static bool IsInside(int row, int col, int n)
//        {
//            return row >= 0 && row < n && col >= 0 && col < n;
//        }

//        private static void PrintMatrix(char[,] matrix)
//        {
//            for (int row = 0; row < matrix.GetLength(0); row++)
//            {
//                for (int col = 0; col < matrix.GetLength(1); col++)
//                {
//                    Console.Write(matrix[row, col]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}
