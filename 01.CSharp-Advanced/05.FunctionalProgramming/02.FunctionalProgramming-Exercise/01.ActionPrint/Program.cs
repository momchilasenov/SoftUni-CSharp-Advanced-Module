using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] names = Console.ReadLine().Split();

            //Action<string> printName = name => Console.WriteLine(name);

            //foreach (var name in names)
            //{
            //    printName(name);
            //}

            //Alternative Solution

            string[] names = Console.ReadLine().Split();

            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(names);
        }

    }
}
