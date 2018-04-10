using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BookLib
{
    /// <summary>
    /// Provides a basic model for a book.
    /// </summary>
    [Serializable]
    public class Book : IComparable, IEquatable<Book>
    {
        public string ISBN;
        public string title;
        public string author;
        public string publisher;
        public int year;
        public int numberOfPages;
        public double price;

        /// <summary>
        /// Constructor for a class.
        /// throws ArgumentNullException in case any of parameters is null
        /// throws ArgumentOutOfRangeException in case price or number of pages is negative
        /// </summary>
        /// <param name="iSBN">ISBN code of a book.</param>
        /// <param name="author">Books's author.</param>
        /// <param name="publisher">Books's publisher.</param>
        /// <param name="name">Books's title.</param>
        /// <param name="year">Books's year of release.</param>
        /// <param name="numberOfPages">Books's number of pages.</param>
        /// <param name="price">Books's current price.</param>
        public Book(string iSBN, string author, string publisher, string name, int year, int numberOfPages, double price)
        {
            this.ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            if (year > 2019)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            this.year = year;
            this.title = name ?? throw new ArgumentNullException(nameof(name));
            if (numberOfPages <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfPages));
            }

            this.numberOfPages = numberOfPages;
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }

            this.price = price;
        }

        /// <summary>
        /// Provides mechanism to compare with other books.
        /// throws InvalidCastException if it is sompared with inapropriate object.
        /// </summary>
        /// <param name="obj">Object to be compared to.</param>
        /// <returns>-1 if Book is less, 0 if eaqual,+1 otherwise</returns>
        public int CompareTo(object obj)
        {
            Book comparedBook = obj as Book;
            if (comparedBook == null)
            {
                throw new InvalidCastException(nameof(obj));
            }

            if (this.price < comparedBook.price)
            {
                return -1;
            }

            if (this.price > comparedBook.price)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// General override to check are the Books equal.
        /// throws ArgumentNullException if compared Book is null.
        /// </summary>
        /// <param name="other">Book to be compared to.</param>
        /// <returns>True if equal, false otherwise.</returns>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (this == other)
            {
                return true;
            }

            if (!this.author.Equals(other.author))
            {
                return false;
            }

            if (!this.publisher.Equals(other.publisher))
            {
                return false;
            }

            if (!this.title.Equals(other.title))
            {
                return false;
            }

            if (!this.ISBN.Equals(other.ISBN))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// General override.
        /// </summary>
        /// <returns>String that represents object's state.</returns>
        public override string ToString()
        {
            return $"Title:{this.title} ISBN: {this.ISBN} Author: {this.author} Publisher: {this.publisher} Year:{this.year} Pages:{this.numberOfPages} Price:{this.price}";
        }
    }
}
