using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> elements;

        private int currentIndex;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (currentIndex + 1 >= this.elements.Count)
            {
                return false;
            }

            currentIndex++;
            return true;
        }

        public bool HasNext()
        {
            if (currentIndex == this.elements.Count - 1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[currentIndex]);
        }


    }
}
