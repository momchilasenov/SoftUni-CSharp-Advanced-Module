using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < this.elements.Count; currentIndex++)
            {
                yield return this.elements[currentIndex];
            }

            //OR
            //foreach (var element in this.elements)
            //{
            //    yield return element;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
