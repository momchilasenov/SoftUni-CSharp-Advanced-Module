using System;
using System.Collections.Generic;
using System.Text;
using OpenClosed.Contracts;

namespace OpenClosed.Strategies
{
    public class QuickSort : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            Console.WriteLine("QuickSort algorithm");

            return list;
        }
    }
}
