using System;
using System.Collections.Generic;
using System.Text;

namespace P05.GenericCountMethodString
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }

        public List<T> Values { get; set; }

        public void SwapElements(int first, int second)
        {
            IndexIsValid(first, second);

            T temp = this.Values[first];
            this.Values[first] = this.Values[second];
            this.Values[second] = temp;
        }

        public int CompareElements(T element)
        {
            int counter = 0;

            foreach (var value in this.Values)
            {
                if (value.CompareTo(element) == 1)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void IndexIsValid(int first, int second)
        {
            if (first < 0 &&
                first >= Values.Count &&
                second < 0 &&
                second >= Values.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
