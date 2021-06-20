using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public string[] Authors { get; private set; }

        public int CompareTo(Book other)
        {
            int yearComparison = this.Year.CompareTo(other.Year);
            if (yearComparison == 0)
            {
                yearComparison = this.Title.CompareTo(other.Title);
            }

            return yearComparison;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
