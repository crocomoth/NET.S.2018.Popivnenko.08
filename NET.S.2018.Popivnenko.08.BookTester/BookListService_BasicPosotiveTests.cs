using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.S._2018.Popivnenko._08.BookLib;
using NET.S._2018.Popivnenko._08.BookLib.Exceptions;
using NET.S._2018.Popivnenko._08.BookLib.Model_and_service;

namespace NET.S._2018.Popivnenko._08.BookTester
{
    [TestClass]
    public class BookListService_BasicPosotiveTests
    {
        [TestMethod]
        public void BasicListTest()
        {
            BookListService bookListService = new BookListService();
            Assert.IsNotNull(bookListService.GetBooks());
        }

        [TestMethod]
        public void BasicContainsTest()
        {
            BookListService bookListService = new BookListService();
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            bookListService.AddBook(book);
            List<Book> books = new List<Book>();
            books.Add(book);
            List<Book> resultList = bookListService.GetBooks();
            CollectionAssert.AreEqual(books, resultList);
        }

        [TestMethod]
        public void RemoveBookTest()
        {
            BookListService bookListService = new BookListService();
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            bookListService.AddBook(book);
            List<Book> books = new List<Book>();
            books.Add(book);
            bookListService.RemoveBook(book);
            CollectionAssert.AreNotEqual(books, bookListService.GetBooks());
        }

        [TestMethod]
        [ExpectedException(typeof(BookExistsException))]
        public void AddBookExceptionTest()
        {
            BookListService bookListService = new BookListService();
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            bookListService.AddBook(book);
            bookListService.AddBook(book);
        }

        [TestMethod]
        [ExpectedException(typeof(BookDoesNotExistException))]
        public void DeleteBookSceptionTest()
        {
            BookListService bookListService = new BookListService();
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            bookListService.RemoveBook(book);
        }

        [TestMethod]
        public void BookTest()
        {
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            Assert.IsNotNull(book.ToStringExtended(StringFormat.auth_publisher));
        }

        [TestMethod]
        public void StorageTest()
        {
            BookListService bookListService = new BookListService();
            Book book = new Book("isbn", "author", "publisher", "title", 2009, 400, 45.5);
            bookListService.AddBook(book);
            BookStorage bookStorage = new BookStorage();
            bookStorage.SaveToFile(bookListService.GetBooks());
            Assert.IsNotNull(bookStorage.LoadFromFile());
        }
    }
}
