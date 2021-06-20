using System;
using System.Collections.Generic;
using System.Text;

namespace _02.DoublyLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public override string ToString()
        {
            return $"Value:{this.Value}//Next:{this.Next}";
        }


    }
}
