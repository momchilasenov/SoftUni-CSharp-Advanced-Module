using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charInput[col];
                }

            }

            char symbol = char.Parse(Console.ReadLine());

            if (matrix.Cast<char>().Contains(symbol))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        char currentSymbol = matrix[i, j];
                        if (currentSymbol == symbol)
                        {
                            Console.WriteLine($"({i}, {j})");
                            return;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine(symbol + " does not occur in the matrix");

            }
        }
    }
}
