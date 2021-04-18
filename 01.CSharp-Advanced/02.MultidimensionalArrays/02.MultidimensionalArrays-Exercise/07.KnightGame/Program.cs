using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessMatrix = new char[n, n];

            for (int row = 0; row < chessMatrix.GetLength(0); row++)
            {
                string chessBoard = Console.ReadLine();

                for (int col = 0; col < chessMatrix.GetLength(1); col++)
                {
                    chessMatrix[row, col] = chessBoard[col];
                }
            }
            
            int maxRow = 0;
            int maxCol = 0;

            int horsesRemoved = 0;

            while (true)
            {
                int maxHorseAttacks = int.MinValue;

                for (int row = 0; row < chessMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < chessMatrix.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (chessMatrix[row, col] == 'K')
                        {
                            currentAttacks = GetAttacks(chessMatrix, row, col, currentAttacks);

                            if (currentAttacks > maxHorseAttacks)
                            {
                                maxHorseAttacks = currentAttacks;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                if (maxHorseAttacks > 0) //if there are any horses that attack other horses, remove the max one
                {
                    chessMatrix[maxRow, maxCol] = '0';
                    horsesRemoved++;
                }

                else //if there are no more attackers print the horses you removed
                {
                    Console.WriteLine(horsesRemoved);
                    break;
                }
            }
        }

        private static int GetAttacks(char[,] chessMatrix, int row, int col, int currentAttacks)
        {
            if (IsInside(chessMatrix, row - 2, col - 1) && chessMatrix[row - 2, col - 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row + 2, col - 1) && chessMatrix[row + 2, col - 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row - 2, col + 1) && chessMatrix[row - 2, col + 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row + 2, col + 1) && chessMatrix[row + 2, col + 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row - 1, col - 2) && chessMatrix[row - 1, col - 2] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row + 1, col - 2) && chessMatrix[row + 1, col - 2] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row - 1, col + 2) && chessMatrix[row - 1, col + 2] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(chessMatrix, row + 1, col + 2) && chessMatrix[row + 1, col + 2] == 'K')
            {
                currentAttacks++;
            }

            return currentAttacks;
        }

        static bool IsInside(char[,] chessMatrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessMatrix.GetLength(0) &&
               targetCol >= 0 && targetCol < chessMatrix.GetLength(1);
        }
    }
}
