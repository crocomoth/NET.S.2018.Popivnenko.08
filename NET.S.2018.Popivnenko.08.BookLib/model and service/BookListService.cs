using NET.S._2018.Popivnenko._08.BookLib.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BookLib
{
    public class BookListService
    {
        private List<Book> books;

        public BookListService()
        {
            this.books = new List<Book>();
        }

        public BookListService(List<Book> books)
        {
            this.books = books;
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (ContainsBook(book))
            {
                throw new BookExistsException("book already exists");
            }
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (ContainsBook(book))
            {
                throw new BookDoesNotExistException("book does already exists");
            }
        }

        private bool ContainsBook(Book book)
        {
            foreach (var elem in books)
            {
                if (book.Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Book> SearchByTag(Tags tag,string searchingCriteria)
        {
            if ((searchingCriteria == null) || (searchingCriteria == String.Empty))
            {
                throw new ArgumentException(nameof(searchingCriteria));
            }
            List<Book> result = new List<Book>();
            switch (tag)
            {
                case Tags.author:
                    
                        foreach (var elem in books)
                        {
                            if (elem.author.Equals(searchingCriteria))
                            {
                                result.Add(elem); ;
                            }
                        }
                        break;
                case Tags.publisher:

                    foreach (var elem in books)
                    {
                        if (elem.publisher.Equals(searchingCriteria))
                        {
                            result.Add(elem); ;
                        }
                    }
                    break;

                case Tags.title:

                    foreach (var elem in books)
                    {
                        if (elem.title.Equals(searchingCriteria))
                        {
                            result.Add(elem); ;
                        }
                    }
                    break;

                case Tags.year:

                    foreach (var elem in books)
                    {
                        if (elem.year.Equals(searchingCriteria))
                        {
                            result.Add(elem); ;
                        }
                    }
                    break;

            }


            return result;
        }

        public List<Book> SortByTag(Tags tag)
        {
            List<Book> result = new List<Book>();
            switch (tag)
            {
                case Tags.year:
                    {
                        Book[] booksArray = books.ToArray();
                        SortByYear(booksArray);
                        result = booksArray.ToList();
                        break;
                    }
                case Tags.price:
                    {
                        Book[] booksArray = books.ToArray();
                        DefaultBooksSorting(booksArray);
                        result = booksArray.ToList();
                        break;
                    }
            }
            return result;

        }

        private void SortByYear(Book[] array)
        {
            for (int i=0;i<array.Length;i++)
            {
                for (int j = 0;j < array.Length - i -1; j++)
                {
                    if (array[j].year > array[j+1].year)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }

        private void DefaultBooksSorting(Book[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 1)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
