using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 1; i < 20; i++)
            {
                list.AddHead(new Node(i));
            }

            Console.WriteLine($"Popped {list.Pop().Value}");
            Console.WriteLine($"Popped {list.Pop().Value}");
            Console.WriteLine($"Popped {list.Pop().Value}");

            Console.WriteLine($"Peeked {list.Peek().Value}");
            
            list.PrintList();

        }
    }
}
