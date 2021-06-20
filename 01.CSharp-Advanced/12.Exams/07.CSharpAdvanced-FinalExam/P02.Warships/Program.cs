using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] attackCommands = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> attacks = new Queue<int>(attackCommands);

            char[,] matrix = new char[n, n];

            int firstShipCount = 0;
            int secondShipCount = 0;
            int shipsSunkCount = 0;
            int attacksCount = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputData = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputData[col];
                    if (matrix[row, col] == '<')
                    {
                        firstShipCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondShipCount++;
                    }
                }
            }

            while (firstShipCount > 0 && secondShipCount > 0)
            {
                if (attacks.Count() == 0)
                {
                    Console.WriteLine($"It's a draw! Player One has {firstShipCount} ships left. Player Two has {secondShipCount} ships left.");
                    break;
                }
                attacksCount++;
                int attackRow = attacks.Dequeue();
                int attackCol = attacks.Dequeue();

                if (attackRow < 0 || attackRow >= matrix.GetLength(0)
                    || attackCol < 0 || attackCol >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[attackRow, attackCol] == '#')
                {
                    if (attackRow > 0)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow - 1, attackCol))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow - 1, attackCol))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackRow < matrix.GetLength(0)-1)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow + 1, attackCol))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow + 1, attackCol))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackCol > 0 )
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow, attackCol-1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow, attackCol-1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackCol < matrix.GetLength(1)-1)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow, attackCol + 1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow, attackCol + 1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackRow>0 && attackCol > 0)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow-1, attackCol - 1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow-1, attackCol - 1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackRow > 0 && attackCol < matrix.GetLength(1)-1)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow - 1, attackCol + 1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow - 1, attackCol + 1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackRow < matrix.GetLength(0)-1 && attackCol > 0)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow + 1, attackCol - 1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow + 1, attackCol - 1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                    if (attackRow < matrix.GetLength(0)-1 && attackCol < matrix.GetLength(1)-1)
                    {
                        if (CheckFirstPlayerShip(matrix, attackRow + 1, attackCol + 1))
                        {
                            firstShipCount--;
                            shipsSunkCount++;
                        }
                        else if (CheckSecondPlayerShip(matrix, attackRow + 1, attackCol + 1))
                        {
                            secondShipCount--;
                            shipsSunkCount++;
                        }
                    }
                }
                else if (matrix[attackRow, attackCol] == '<')
                {
                    matrix[attackRow, attackCol] = 'X';
                    firstShipCount--;
                    shipsSunkCount++;

                }
                else if (matrix[attackRow, attackCol] == '>')
                {
                    matrix[attackRow, attackCol] = 'X';
                    secondShipCount--;
                    shipsSunkCount++;
                }

                if (secondShipCount <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {shipsSunkCount} ships have been sunk in the battle.");
                }
                else if (firstShipCount <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsSunkCount} ships have been sunk in the battle.");
                }
            }
        }

        static bool CheckFirstPlayerShip(char[,] matrix, int attackRow, int attackCol)
        {
            if (matrix[attackRow, attackCol] == '<')
            {
                matrix[attackRow, attackCol] = 'X';
                return true;
            }
            return false;
        }

        static bool CheckSecondPlayerShip(char[,] matrix, int attackRow, int attackCol)
        {
            if (matrix[attackRow, attackCol] == '>')
            {
                matrix[attackRow, attackCol] = 'X';
                return true;
                
            }
            return false;
        }

    }
}
