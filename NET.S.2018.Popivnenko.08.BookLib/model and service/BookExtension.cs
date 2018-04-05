using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BookLib.model_and_service
{
    /// <summary>
    /// Extension class for <see cref="Book"/>
    /// </summary>
    public static class BookExtension
    {
        /// <summary>
        /// Extension method for ToString.
        /// </summary>
        /// <param name="book"><see cref="Book"/> object that will be used as source thus giving context.</param>
        /// <param name="stringFormat">Describes a way for data to be represented.</param>
        /// <returns>String to represent a <see cref="Book"/> object.</returns>
        public static String ToString(this Book book,StringFormat stringFormat)
        {
            switch (stringFormat)
            {
                case StringFormat.auth_date:
                    return $"author: {book.author} , date: {book.year} ";
                case StringFormat.auth_only:
                    return $"author: {book.author}";
                case StringFormat.auth_publisher:
                    return $"author: {book.author} , publisher {book.publisher}";
                case StringFormat.full_info:
                    return book.ToString();
                default:
                    return book.ToString();
            }
        }
    }
}
