using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>, IComparable<Library>
    {
        public Library()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }

        public void Add(Book book)
        {
            this.Books.Add(book);
        }

        public int CompareTo(Library other)
        {
            if (this.Books.Count > other.Books.Count)
            {
                return 1;
            }
            else if (this.Books.Count < other.Books.Count)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //1st way - with custom enumerator
            //LibraryEnumerator libraryEnumerator = new LibraryEnumerator(this.Books);
            //return libraryEnumerator;

            //2nd way - yield return
            for (int currentIndex = 0; currentIndex < this.Books.Count; currentIndex++)
            {
                yield return this.Books[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    //internal class LibraryEnumerator : IEnumerator<Book>
    //{
    //    //you implement this interface because you want to have all methods
    //    //that you need, to enumerate/iterate through a collection
    //    //this interface will give you the tools to build your own enumerator

    //    private readonly List<Book> books; //това вече е колекцията с която ще работиш

    //    private int currentIndex = -1;

    //    public LibraryEnumerator(List<Book> books)
    //    {
    //        this.books = books;
    //    }

    //    public Book Current => this.books[currentIndex];

    //    object IEnumerator.Current => this.Current; //calls the above property to do the job

    //    public void Dispose()
    //    {
    //    }

    //    public bool MoveNext()
    //    {
    //        this.currentIndex++;

    //        if (this.currentIndex < this.books.Count)
    //        {
    //            return true;
    //        }

    //        return false;

    //        // or "return this.currentIndex<this.books.Count" 
    //    }

    //    public void Reset()
    //    {
    //        this.currentIndex = -1;
    //    }
    //}
}
