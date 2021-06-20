using System;
using System.Collections.Generic;
using OpenClosed.Contracts;
using OpenClosed.Strategies;

namespace OpenClosed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string strategyType = Console.ReadLine().ToLower();

            ISortingStrategy sortingStrategy = null;

            if (strategyType == "selection")
            {
                sortingStrategy = new SelectionSort();
            }
            else if (strategyType == "bubble")
            {
                sortingStrategy = new BubbleSort();
            }
            else if (strategyType == "quick")
            {
                sortingStrategy = new QuickSort();
            }

            Sorter sorter = new Sorter(sortingStrategy);
            sorter.Sort(new List<int>());

        }
    }
}
