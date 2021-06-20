using System;
using OpenClosed.Contracts;
using System.Collections.Generic;
using System.Text;

namespace OpenClosed.Strategies
{
    public class BubbleSort : ISortingStrategy
    {
        public List<int> Sort(List<int> list)
        {
            Console.WriteLine("BubbleSort algorithm");

            return list;
        }
    }
}
