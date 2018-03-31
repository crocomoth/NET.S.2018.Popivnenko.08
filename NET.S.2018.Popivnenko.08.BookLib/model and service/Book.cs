using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BookLib
{
    public class Book : IComparable, IEquatable<Book>
    {
        public string ISBN;
        public string title;
        public string author;
        public string publisher;
        public string year;
        public int numberOfPages;
        public double price;

        public Book(string iSBN, string author, string publisher,string name, string year, int numberOfPages, double price)
        {
            this.ISBN = iSBN ?? throw new ArgumentNullException(nameof(iSBN));
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            this.year = year ?? throw new ArgumentNullException(nameof(year));
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

        public override string ToString()
        {
            return $"Title:{this.title} ISBN: {this.ISBN} Author: {this.author} Publisher: {this.publisher} Year:{this.year} Pages:{this.numberOfPages} Price:{this.price}";
        }
    }
}
