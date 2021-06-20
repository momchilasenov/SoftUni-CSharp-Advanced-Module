//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;

//namespace IteratorsAndComparators2
//{
//    public class Library2 : IEnumerable<Book>
//    {
//        public Library2()
//        {
//            this.Books = new List<Book>(); 
//        }

//        public List<Book> Books { get; set; }

//        public void Add(Book book)
//        {
//            this.Books.Add(book);
//        }

//        public IEnumerator<Book> GetEnumerator()
//        {
//            return new LibraryEnumerator();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return this.GetEnumerator();
//        }
//    }
//}
