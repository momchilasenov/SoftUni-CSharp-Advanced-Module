using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            int titleComparer = first.Title.CompareTo(second.Title);

            if (titleComparer == 0)
            {
                return second.Year.CompareTo(first.Year);
            }

            return titleComparer;
        }
    }
}
