using System;
using System.Collections.Generic;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            for (int i=1; i<10; i++)
            {
                stack.Push(i);
            }

            stack.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(stack.Pop());
            ;
        }
    }
}
