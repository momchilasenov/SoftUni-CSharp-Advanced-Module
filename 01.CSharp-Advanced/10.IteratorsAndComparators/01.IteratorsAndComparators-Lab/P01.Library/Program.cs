using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            //Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            //Book bookThree = new Book("The Documents in the Case", 1930);

            //Library libraryOne = new Library();
            //Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            Library library = new Library();
            library.Add(new Book("Book1", 2010,13m, new List<string> { "Author 1" }));
            library.Add(new Book("Book2", 2015,13m, new List<string> { "Author 2" }));
            library.Add(new Book("Book3", 2020,13m, new List<string> { "Author 3" }));

            foreach (var book in library)
            {
                Console.WriteLine($"{string.Join(' ', book.Authors)} - {book.Title} - {book.Year}");
            }

            Library library2 = new Library();
            library2.Add(new Book("Book5", 2010, 100.3m, new List<string> { "Author 5" }));
            library2.Add(new Book("Book6", 2015, 49m, new List<string> { "Author 6" }));

            if (library.CompareTo(library2) > 0)
            {
                Console.WriteLine("Library1 is bigger");
            }

            //sort by creating custom comparer class 
            library2.Books.Sort(new ComparerByPrice());

            //sort by using Comparison and a custom function
            library2.Books.Sort(new Comparison<Book>((b1, b2) => b1.Price.CompareTo(b2.Price)));

        }
    }
}
