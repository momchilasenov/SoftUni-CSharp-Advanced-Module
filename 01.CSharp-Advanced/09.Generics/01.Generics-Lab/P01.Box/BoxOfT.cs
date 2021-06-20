using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        private List<T> list;

        public BoxOfT()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            this.list.Insert(0, element);
        }

        public T Remove()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Attempt to configure an empty box");
            }

            var element = this.list[0];
            this.list.RemoveAt(0);
            return element;
        }

        public int Count => this.list.Count; // == get{return this.list.Count;}
    }
}
