using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] items { get; set; }

        private int count { get; set; }

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }

        public int Count 
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public void Push(int element)
        {
            EnsureCapacity();
            this.items[this.count] = element;
            this.count++;
        }

        public int Pop()
        {
            StackHasElements();
            var topItem = this.items[this.Count - 1];
            this.items[this.Count] = default;
            this.Count--;
            return topItem;
        }

        public int Peek()
        {
            StackHasElements();
            return this.items[this.Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void EnsureCapacity()
        {
            if (this.Count < this.items.Length)
            {
                return;
            }

            var tempArray = new int[this.Count * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private void StackHasElements()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }






    }
}
