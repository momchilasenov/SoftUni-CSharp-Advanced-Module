using System;

namespace _02.DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

            for (int i = 1; i < 4; i++)
            {
                list.AddHead(new Node(i));
            }

            for (int i = 1; i < 4; i++)
            {
                list.AddLast(new Node(i));
            }

            Console.WriteLine("Entire list:");
            list.PrintList();

            Console.WriteLine("Entire list:");
            list.ReversePrintList();

            Console.WriteLine($"Removed Head: {list.RemoveFirst().Value}");
            Console.WriteLine($"Removed Head: {list.RemoveFirst().Value}");
            Console.WriteLine($"Removed Head: {list.RemoveFirst().Value}");

            Console.WriteLine($"Peeked {list.Peek().Value}");

            
        }
    }
}
