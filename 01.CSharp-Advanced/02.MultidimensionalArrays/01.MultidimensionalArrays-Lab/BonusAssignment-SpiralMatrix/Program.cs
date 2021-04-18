using System;

namespace BonusAssignment_SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //the spiral matrix has to be a square
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            string direction = "right"; //state machine - the current state which changes later
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * n; i++) //a loop for ALL the squares
            {
                matrix[row, col] = i + 1;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "up")
                {
                    row--;
                }

                if ((col == n || isSpaceTaken(matrix, row, col, n)) && direction == "right") //if you reach the right end of the matrix you start to go down
                { //matrix[row, col] != 0 - means that the square is already taken and you should change direction
                    col--; //you went outside so you go one step back 
                    row++; //and then you go down one row
                    direction = "down";
                }

                if ((row == n || isSpaceTaken(matrix, row, col, n)) && direction == "down") //if you reach the bottom end of the matrix you start moving left
                {
                    row--;
                    col--;
                    direction = "left";
                }
                if ((col == -1 || isSpaceTaken(matrix, row, col, n)) && direction == "left") //if you go outside the matrix start going up
                {
                    row--;
                    col++;
                    direction = "up";
                }
                if ((row == -1 || isSpaceTaken(matrix, row, col, n)) && direction == "up") //if you go outside the matrix start going up
                {
                    col++;
                    row++;
                    direction = "right";
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],3} "); //every number takes up 3 characters

                }
                Console.WriteLine();
            }

        }

        static bool isSpaceTaken(int[,] matrix, int row, int col, int n)
        {
            return row >= 0 && col >= 0 && row < n && col < n && matrix[row, col] != 0;
        }
    }
}
