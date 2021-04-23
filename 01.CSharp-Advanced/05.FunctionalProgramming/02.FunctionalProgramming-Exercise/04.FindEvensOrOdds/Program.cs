using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] rangeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int[] numberArray = Enumerable.Range(rangeData[0], rangeData[1]-rangeData[0]+1).ToArray();

            //Func<int, bool> arrayFilter = null;

            //string filter = Console.ReadLine();

            //if (filter == "odd")
            //{
            //    arrayFilter = x => x % 2 != 0;
            //}
            //else if (filter == "even")
            //{
            //    arrayFilter = x => x % 2 == 0;
            //}

            //foreach (int number in numberArray)
            //{
            //    if (arrayFilter(number))
            //    {
            //        Console.Write(number + " ");
            //    }
            //}


            //Alternative solution
            int[] rangeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> numbers = Enumerable.Range(rangeData[0], rangeData[1] - rangeData[0] + 1).ToList();

            Predicate<int> evenNumbersPredicate = num => num % 2 == 0;

            Action<List<int>> printNumbers = items => Console.WriteLine(string.Join(' ', items));

            string numberType = Console.ReadLine();

            if (numberType == "even")
            {
                numbers.RemoveAll(x => !evenNumbersPredicate(x));
            }
            else if (numberType == "odd")
            {
                numbers.RemoveAll(x => evenNumbersPredicate(x));
            }

            printNumbers(numbers);

        }
    }
}
