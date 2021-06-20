using System;
using System.Collections.Generic;
using System.Text;

namespace P03.GenericSwapMethodString
{
    public class Box<T>
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
