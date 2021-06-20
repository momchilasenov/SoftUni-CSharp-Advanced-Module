using System;

namespace Doubly
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            for (int i=0; i<20; i++)
            {
                linkedList.AddHead(new Node(i));
            }

            Node currentNode = linkedList.Tail;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }
    }
}
