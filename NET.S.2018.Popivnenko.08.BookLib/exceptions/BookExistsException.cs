using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BookLib.exceptions
{
    public class BookExistsException : Exception
    {
        
        public BookExistsException(string message) : base(message)
        {
            
        }
    }
}
