using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, decimal price, List<string> authors)
        {
            this.Title = title;
            this.Year = year;
            this.Price = price;
            this.Authors = authors;
        }

        public string Title { get; private set; }

        public decimal Price { get; set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            if (this.Year < other.Year)
            {
                return 1;
            }
            else if (other.Year < this.Year)
            {
                return -1;
            }
            else
            {
                if (this.Title.CompareTo(other.Title) > 0) //Title is string so it has it's own CompareTo
                {
                    return 1;
                }
                else if (this.Title.CompareTo(other.Title) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

                //OR simply: this.Title.CompareTo(other.Title);
            }

        }
    }
}
