using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openIndex = stack.Pop();
                    int closeIndex = i;
                    Console.WriteLine(input.Substring(openIndex, closeIndex - openIndex + 1));
                }
            }

        }
    }
}
