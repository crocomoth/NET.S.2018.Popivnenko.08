using System;

namespace NET.S._2018.Popivnenko._08.BookLib.Exceptions
{
    public class BookExistsException : Exception
    {       
        public BookExistsException(string message) : base(message)
        {            
        }
    }
}
