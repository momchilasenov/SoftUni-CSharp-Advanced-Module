using System;

namespace LinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public void AddHead(Node node)//you receive the new Head
        {
            node.Next = Head;
            Head = node; 
        }

        public Node Pop()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;
            return oldHead;
        }

        public Node Peek()
        {
            return this.Head;
        }

        public void PrintList()
        {
            Node currentNode = Head; 

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next; 
            }
        }


    }
}
