using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>(input.Length);

            foreach(char element in input)
            {
                reversedString.Push(element);
            }

            while (reversedString.Count > 0)
            {
                Console.Write(reversedString.Pop());

            }
            




        }
    }
}
