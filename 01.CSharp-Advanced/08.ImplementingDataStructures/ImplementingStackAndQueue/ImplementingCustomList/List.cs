using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class List
    {
        private int[] items; 

        private const int InitialCapacity = 2;

        public List()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; } 

        public int[] Items { get; private set; } 

        public int this[int index] 
        {
            get
            {
                ValidateIndex(index);

                return this.items[index];
            }
            set
            {
                ValidateIndex(index);

                this.items[index] = value;
            }
        }



        public void Add(int element)
        {
            Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }

            //OR Array.Copy(this.items, 0, tempArray, 0, this.items.Length);
            int[] tempArray = new int[2 * this.items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                tempArray[i] = items[i];
            }

            this.items = tempArray;
        }

        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }
            else
            {
                var tempArray = new int[this.items.Length / 2];

                for (int i = 0; i < this.Count; i++)
                {
                    tempArray[i] = this.items[i];
                }

                this.items = tempArray;
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private int RemoveAt(int index)
        {
            ValidateIndex(index);

            var removedElement = this.items[index];
            this.ShiftLeft(index);
            this.Count--;
            this.Shrink();

            return removedElement;
        }

        private void InsertAt(int index, int element)
        {
            ValidateIndex(index);
            this.Count++;
            Resize();
            ShiftRight(index);
            this.items[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;

        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                var temp = this.items[i];
                this.items[i] = this.items[this.Count - i - 1];
                this.items[this.Count - i - 1] = temp;
            }

            //or Swap(i, this.Count-i-1);
        }


        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i < this.Count; i++)
            {
                sb.Append(this.items[i] + ", ");
            }

            return sb.ToString().TrimEnd(',', ' ');
        }

    }
}
