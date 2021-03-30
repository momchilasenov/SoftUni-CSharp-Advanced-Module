using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 + 5 + 10 - 2 - 1 = 14

            //string expression = Console.ReadLine();

            //string[] parts = expression.Split(' ');

            //Stack<string> stack = new Stack<string>(parts.Reverse());

            //int result = 0;

            //while (stack.Count > 0)
            //{
            //    string currentElement = stack.Pop();

            //    if (currentElement == "+")
            //    {
            //        string nextElement = stack.Pop();
            //        result += int.Parse(nextElement);
            //    }
            //    else if (currentElement == "-")
            //    {
            //        string nextElement = stack.Pop();
            //        result -= int.Parse(nextElement);
            //    }
            //    else
            //    {
            //        result = int.Parse(currentElement);
            //    }
            //}

            //Console.WriteLine(result);

            //Alternative Solution

            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();

            for (int i=input.Length-1; i>=0; i--)
            {
                stack.Push(input[i]);
            }

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }

            }
            Console.WriteLine(stack.Pop());

        }
    }
}
