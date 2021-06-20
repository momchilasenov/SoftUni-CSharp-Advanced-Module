using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DoublyLinkedList2._0
{
    public class DoublyLinkedList<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }

            public Node Previous { get; set; }
        }

        public Node Head { get; set; }

        public Node Tail { get; set; }


        public void AddHead(Node newHead)
        {
            if (this.Head == null)
            {
                this.Head = newHead; 
                this.Tail = newHead;
            }
            else
            {
                newHead.Next = Head; 
                Head.Previous = newHead; 
                Head = newHead; 
            }
        }

        public void AddLast(Node newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail; 
                Tail.Next = newTail; 
                Tail = newTail; 
            }
        }

        public Node RemoveFirst() 
        {
            var head = this.Head;
            this.Head = this.Head.Next;
            this.Head.Previous = null; 
            return head;
        }

        public Node RemoveLast()
        {
            var tail = this.Tail;
            this.Tail = this.Tail.Previous;
            this.Tail.Next = null; 
            return tail;
        }

        public void ForEach(Action<Node> action)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode); 
                currentNode = currentNode.Next;
            }
        }

        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }

        public bool Remove(T value) 
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            bool isFound = false;

            ForEach(node =>
            {
                if (node.Value.Equals(value))
                {
                    isFound = true;
                }
            });

            return isFound;
        }

        public Node Peek()
        {
            return this.Head;
        }

        public void PrintList()
        {
            this.ForEach(node => Console.WriteLine(node.Value));
        }

        public void ReversePrintList()
        {
            Node currentNode = this.Tail;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }
    }
}

