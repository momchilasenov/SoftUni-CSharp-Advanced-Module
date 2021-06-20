using System;

namespace Database
{
    public class Database
    {
        private int[] data;

        private int count;

        public Database(params int[] data)
        {
            this.data = new int[16];

            for (int i = 0; i < data.Length; i++) //ctor should throw exception when capacity exceeded (17 elements)
            {
                this.Add(data[i]);
            }

            this.count = data.Length; //count should return correct number of elements
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(int element)
        {
            if (this.count == 16) //is exception thrown when exceeded capacity?
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            this.data[this.count] = element; //is specific element added to the database
            this.count++; //does count increase when element is added
        }

        public void Remove()
        {
            if (this.count == 0) //is exception thrown when trying to remove from empty collection
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            this.count--; //is count decreased if remove command is valid
            this.data[this.count] = 0; //is current element set to 0 correctly
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[this.count]; //should return db copy not a reference

            for (int i = 0; i < this.count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }
    }
}
