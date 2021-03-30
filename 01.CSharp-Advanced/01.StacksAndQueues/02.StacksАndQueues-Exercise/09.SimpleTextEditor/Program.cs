using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> stateStack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string number = input[0];

                if (number == "1")
                {
                    stateStack.Push(text.ToString());
                    string subString = input[1];
                    text.Append(subString);
                }
                else if (number == "2")
                {
                    stateStack.Push(text.ToString());
                    int count = int.Parse(input[1]);
                    text.Remove(text.Length - count, count);
                }
                else if (number == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (number == "4")
                {
                    text = new StringBuilder(stateStack.Pop());
                }
            }
        }
    }
}
