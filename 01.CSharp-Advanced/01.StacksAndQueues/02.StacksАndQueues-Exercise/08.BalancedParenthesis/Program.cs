using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //string parenthesis = Console.ReadLine();

            //Queue<char> leftParenthesis = new Queue<char>();
            //Stack<char> rightParenthesis = new Stack<char>();

            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < parenthesis.Length / 2; i++)
            //{
            //    leftParenthesis.Enqueue(parenthesis[i]);

            //    switch (parenthesis[i])
            //    {
            //        case '[': rightParenthesis.Push(']'); break;
            //        case '(': rightParenthesis.Push(')'); break;
            //        case '{': rightParenthesis.Push('}'); break;
            //        case ']': rightParenthesis.Push('['); break;
            //        case ')': rightParenthesis.Push('('); break;
            //        case '}': rightParenthesis.Push('{'); break;
            //    }
            //}

            //for (int i = 0; i < parenthesis.Length / 2; i++)
            //{
            //    char leftElement = leftParenthesis.Dequeue();

            //    sb.Append(leftElement);
            //}
            //for (int i = 0; i < parenthesis.Length / 2; i++)
            //{
            //    char rightElement = rightParenthesis.Pop();

            //    sb.Append(rightElement);
            //}


            //if (parenthesis == sb.ToString())
            //{
            //    Console.WriteLine("YES");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}

            //Alternative Solution
            string input = Console.ReadLine();

            Stack<char> parenthesis = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (currentSymbol == '(' || currentSymbol =='[' || currentSymbol == '{')
                {
                    parenthesis.Push(currentSymbol);
                }
                else if (currentSymbol ==')' || currentSymbol ==']' || currentSymbol == '}')
                {
                    if (parenthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        char openingParenthesis = parenthesis.Pop();

                        if ((currentSymbol == ')' && openingParenthesis == '(') ||
                            (currentSymbol == ']' && openingParenthesis == '[') ||
                            (currentSymbol == '}' && openingParenthesis == '{'))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }

            if (parenthesis.Count== 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
