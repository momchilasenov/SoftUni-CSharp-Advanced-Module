using System;
using System.Linq;

namespace P02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            const int moneyNeeded = 50;

            int n = int.Parse(Console.ReadLine());

            int currentRow = 0;
            int currentCol = 0;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                    if (data[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            int currentMoney = 0;

            while (currentMoney < moneyNeeded)
            {
                string moveCommand = Console.ReadLine();

                if (moveCommand == "right" &&
                    IsInMatrix(matrix, currentRow, currentCol + 1))
                {
                    matrix[currentRow, currentCol] = '-';
                    currentCol = currentCol + 1;

                }
                else if (moveCommand == "left" &&
                    IsInMatrix(matrix, currentRow, currentCol - 1))
                {
                    matrix[currentRow, currentCol] = '-';
                    currentCol = currentCol - 1;
                }
                else if (moveCommand == "up" &&
                    IsInMatrix(matrix, currentRow - 1, currentCol))
                {
                    matrix[currentRow, currentCol] = '-';
                    currentRow = currentRow - 1;
                }
                else if (moveCommand == "down" &&
                    IsInMatrix(matrix, currentRow + 1, currentCol))
                {
                    matrix[currentRow, currentCol] = '-';
                    currentRow = currentRow + 1;
                }
                else
                {
                    matrix[currentRow, currentCol] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                char currentElement = matrix[currentRow, currentCol];

                if (currentElement == 'O')
                {
                    MoveToOtherPillar(matrix, currentRow, currentCol);
                    Tuple<int, int> newPosition = GetCurrentPosition(matrix);
                    currentRow = newPosition.Item1;
                    currentCol = newPosition.Item2;
                }
                
                else if (char.IsDigit(currentElement))
                {
                    currentMoney += int.Parse(currentElement.ToString());
                    matrix[currentRow, currentCol] = 'S';
                }
            }

            if (currentMoney >= moneyNeeded)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {currentMoney}");
            PrintMatrix(matrix);

        }

        static bool IsInMatrix(char[,] matrix, int targetRow, int targetCol)
        {
            bool isInMatrix = targetRow >= 0 && targetRow < matrix.GetLength(0)
                && targetCol >= 0 && targetCol < matrix.GetLength(1);

            return isInMatrix;
        }

        static void MoveToOtherPillar(char[,] matrix, int currentRow, int currentCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O' && row != currentRow && col != currentCol)
                    {
                        matrix[currentRow, currentCol] = '-';
                        matrix[row, col] = 'S';
                        return;
                    }
                }
            }
        }

        static Tuple<int, int> GetCurrentPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }
            return null;
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
