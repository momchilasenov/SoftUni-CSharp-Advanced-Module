using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class ComparerByPrice : IComparer<Book> //I compare books
    {
        public int Compare(Book book1, Book book2)
        {
            if (book1.Price > book2.Price)
            {
                return 1;
            }
            else if (book1.Price < book2.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
