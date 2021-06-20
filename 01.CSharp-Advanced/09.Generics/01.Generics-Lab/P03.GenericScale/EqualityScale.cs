using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T first;
        private T second;

        public EqualityScale(T first, T second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public T Second { get; set; }

        public bool AreEqual()
        {
            //return this.First.Equals(this.Second);
            //or
            return this.First.CompareTo(this.Second) == 0;
        }
    }
}
