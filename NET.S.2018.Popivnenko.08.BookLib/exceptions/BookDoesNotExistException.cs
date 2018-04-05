using System;

namespace NET.S._2018.Popivnenko._08.BookLib.Exceptions
{
    public class BookDoesNotExistException : Exception
    {
        public BookDoesNotExistException(string message) : base(message)
        {
        }
    }
}
