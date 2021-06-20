using System;
using System.Diagnostics;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.Contains(4);
            Console.WriteLine(list.Count);
            list.Swap(2, 6);
            list.Reverse();
            Console.WriteLine(list);

            

            

        }
    }
}
