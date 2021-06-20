using OpenClosed.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosed.Strategies
{
    public class SelectionSort : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            Console.WriteLine("Selection sort algorithm");

            return list;
        }
    }
}
