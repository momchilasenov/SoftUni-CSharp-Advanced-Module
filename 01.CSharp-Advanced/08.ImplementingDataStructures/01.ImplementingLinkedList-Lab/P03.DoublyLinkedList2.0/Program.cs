using System;

namespace P03.DoublyLinkedList2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < 6; i++)
            {
                list.AddHead(new DoublyLinkedList<int>.Node(i));
            }

            list.ForEach(Console.WriteLine);
        }
    }
}
