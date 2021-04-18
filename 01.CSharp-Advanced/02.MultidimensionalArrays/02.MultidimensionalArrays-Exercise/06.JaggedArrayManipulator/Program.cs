using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            bool isValid = false;

            for (int rows = 0; rows < n; rows++)
            {
                double[] colData = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                jaggedArray[rows] = new double[colData.Length];

                for (int cols = 0; cols < jaggedArray[rows].Length; cols++)
                {
                    jaggedArray[rows][cols] = colData[cols];
                }
            }

            for (int rows = 0; rows < n - 1; rows++)
            {
                if (jaggedArray[rows].Length == jaggedArray[rows + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[rows].Length; col++)
                    {
                        jaggedArray[rows][col] *= 2;
                        jaggedArray[rows + 1][col] *= 2;
                    }

                }
                else
                {
                    for (int firstCol = 0; firstCol < jaggedArray[rows].Length; firstCol++)
                    {
                        jaggedArray[rows][firstCol] /= 2;
                    }
                    for (int secondCol = 0; secondCol < jaggedArray[rows + 1].Length; secondCol++)
                    {
                        jaggedArray[rows + 1][secondCol] /= 2;
                    }
                }
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                isValid = ValidateCommands(jaggedArray, command);

                if (isValid)
                {
                    string[] commands = command.Split().ToArray();

                    string mainCommand = commands[0];
                    int row = int.Parse(commands[1]);
                    int column = int.Parse(commands[2]);
                    double value = double.Parse(commands[3]);

                    if (mainCommand == "Add")
                    {
                        jaggedArray[row][column] += value;
                    }
                    else if (mainCommand == "Subtract")
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
            }

            foreach (double[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }

        }

        static bool ValidateCommands(double[][] jaggedArray, string command)
        {
            string[] commands = command.Split(' ').ToArray();

            if ((commands[0] == "Add" || commands[0] == "Subtract") &&
                commands.Length == 4 &&
                double.Parse(commands[1]) >= 0 && double.Parse(commands[1]) < jaggedArray.Length &&
                double.Parse(commands[2]) >= 0 && double.Parse(commands[2]) < jaggedArray[1].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

