using System;
using System.Collections.Generic;
using System.Linq;
using NET.S._2018.Popivnenko._08.BookLib.Exceptions;
using NLog;

namespace NET.S._2018.Popivnenko._08.BookLib
{
    /// <summary>
    /// Provides basic service to work with <see cref="Book"/> class.
    /// </summary>
    public class BookListService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private List<Book> books;

        public BookListService()
        {
            this.books = new List<Book>();
            logger.Info("BookListService created by default constructor");
        }

        public BookListService(List<Book> books)
        {
            this.books = books;
            logger.Info("BookListService created by constructor with parameters");
        }

        /// <summary>
        /// Adds <see cref="Book"/> to the collection.
        /// throws <see cref="ArgumentNullException"/> in case parameter is null.
        /// throws <see cref="BookExistsException"/> case that Book already is in collection.
        /// </summary>
        /// <param name="book"><see cref="Book"/> to be added.</param>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                ArgumentNullException exception = new ArgumentNullException(nameof(book));
                logger.Error(exception, "exception at AddBook");
                throw exception;                
            }

            if (ContainsBook(book))
            {
                BookExistsException exception = new BookExistsException("book already exists");
                logger.Error(exception, "exception at AddBook");
                throw exception;
            }

            books.Add(book);
        }

        /// <summary>
        /// Removes <see cref="Book"/> from the collection.
        /// throws <see cref="ArgumentNullException"/> if <see cref="Book"/> is null.
        /// throws <see cref="BookDoesNotExistException"/> if such object does not exist.
        /// </summary>
        /// <param name="book">Book to be removed.</param>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                ArgumentNullException exception = new ArgumentNullException(nameof(book));
                logger.Error(exception, "exception at RemoveBook");
                throw exception;
            }

            if (!ContainsBook(book))
            {
                BookDoesNotExistException exception = new BookDoesNotExistException("book does already exist");
                logger.Error(exception, "exception at RemoveBook");
                throw exception;
            }

            books.Remove(book);
        }

        /// <summary>
        /// Provides possibility to search for a <see cref="Book"/> of a certain tag in collection.
        /// throws <see cref="ArgumentException"/> case <paramref name="searchingCriteria"/> is null or empty.
        /// </summary>
        /// <param name="tag">Tag to be searched for.</param>
        /// <param name="searchingCriteria">Actual value to be searched for.</param>
        /// <returns>List of Books that fall in corresponding criteria.</returns>
        public List<Book> SearchByTag(Tags tag, string searchingCriteria)
        {
            logger.Info("SearchByTag is called");
            if ((searchingCriteria == null) || (searchingCriteria == string.Empty))
            {
                ArgumentException exception = new ArgumentException(nameof(searchingCriteria));
                logger.Error(exception, "searchingCriteria in SearchByTag is incorrect");
                throw exception;
            }

            List<Book> result = new List<Book>();
            switch (tag)
            {
                case Tags.author:

                    logger.Info("Tag = author");
                    foreach (var elem in books)
                    {
                        if (elem.author.Equals(searchingCriteria))
                        {
                            result.Add(elem);
                        }
                    }

                        break;
                case Tags.publisher:

                    logger.Info("Tag = publisher");
                    foreach (var elem in books)
                    {
                        if (elem.publisher.Equals(searchingCriteria))
                        {
                            result.Add(elem);
                        }
                    }

                    break;

                case Tags.title:

                    logger.Info("Tag = title");
                    foreach (var elem in books)
                    {
                        if (elem.title.Equals(searchingCriteria))
                        {
                            result.Add(elem);
                        }
                    }

                    break;

                case Tags.year:

                    logger.Info("Tag = year");
                    foreach (var elem in books)
                    {
                        if (elem.year.Equals(searchingCriteria))
                        {
                            result.Add(elem);
                        }
                    }

                    break;
            }

            return result;
        }

        /// <summary>
        /// Provides possibility to sort a list for a Books of a certain tag in collection.
        /// </summary>
        /// <param name="tag">Tag to be sorted by</param>
        /// <returns>List of sorted Books.</returns>
        public List<Book> SortByTag(Tags tag)
        {
            logger.Info("SortByTag called");
            List<Book> result = new List<Book>();
            switch (tag)
            {
                case Tags.year:
                    {
                        logger.Info("Tag = year");
                        Book[] booksArray = books.ToArray();
                        SortByYear(booksArray);
                        result = booksArray.ToList();
                        break;
                    }

                case Tags.price:
                    {
                        logger.Info("Tag = price");
                        Book[] booksArray = books.ToArray();
                        DefaultBooksSorting(booksArray);
                        result = booksArray.ToList();
                        break;
                    }
            }

            return result;
        }

        public List<Book> GetBooks()
        {
            logger.Info("GetBooks is called");
            return this.books;
        }

        private bool ContainsBook(Book book)
        {
            logger.Info("ContainsBook is called");
            foreach (var elem in books)
            {
                if (book.Equals(elem))
                {
                    logger.Info("Book found");
                    return true;
                }
            }

            logger.Info("Book is not found");
            return false;
        }

        private void SortByYear(Book[] array)
        {
            logger.Info("SortByYear is called");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].year > array[j + 1].year)
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
            logger.Info("DefaultBooksSorting is called");
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
