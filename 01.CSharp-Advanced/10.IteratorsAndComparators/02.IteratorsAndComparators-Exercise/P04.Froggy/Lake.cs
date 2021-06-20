using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> rocks;

        public Lake(params T[] rocks)
        {
            this.rocks = new List<T>(rocks);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.rocks.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.rocks[i];
                }
            }
            for (int i=this.rocks.Count-1; i>=0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.rocks[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
