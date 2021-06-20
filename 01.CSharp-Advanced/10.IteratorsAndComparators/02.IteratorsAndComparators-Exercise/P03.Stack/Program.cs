using System;
using System.Linq;


namespace P03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            CustomStack<int> stack = new CustomStack<int>();

            while (command != "END")
            {
                if (command.Contains("Push"))
                {
                    string[] elements = command
                        .Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();

                    foreach (var element in elements)
                    {
                        stack.Push(int.Parse(element));
                    }

                }
                else if (command.Contains("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                        
                }

                command = Console.ReadLine();
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

        }
    }
}
