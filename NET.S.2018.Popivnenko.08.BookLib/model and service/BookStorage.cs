using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.S._2018.Popivnenko._08.BookLib.model_and_service
{
    /// <summary>
    /// Provides basic functionality to store Books in binary files.
    /// </summary>
    public class BookStorage
    {
        private string path;

        public BookStorage()
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory + "storage.txt";
        }

        public BookStorage(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Sets the path where Books will be saved or looked upon.
        /// </summary>
        /// <param name="dest">Path to the file which can also not exist.</param>
        public void SetPath(string dest)
        {
            this.path = dest;
        }

        /// <summary>
        /// Saves List of Books to file specified by path.
        /// throws ArgumentNullException if parameter is null.
        /// </summary>
        /// <param name="books">List to be saved.</param>
        public void SaveToFile(List<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }
            FileStream fileStream = new FileStream(this.path, FileMode.OpenOrCreate);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            foreach (var elem in books)
            {
                binaryWriter.Write(SerializeToBytes(elem));
            }
            fileStream.Dispose();
            binaryWriter.Dispose();
        }

        /// <summary>
        /// Loads list of Book from a file specified by path.
        /// </summary>
        /// <returns>List of loaded Books.</returns>
        public List<Book> LoadFromFile()
        {
            FileStream fileStream = new FileStream(this.path, FileMode.OpenOrCreate);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            List<Book> result = new List<Book>();
            BinaryFormatter formatter = new BinaryFormatter();
            while (fileStream.Position < fileStream.Length)
            {
                Book obj = (Book)formatter.Deserialize(fileStream);
                result.Add(obj);
            }
            return result;
        }

        private static byte[] SerializeToBytes<Book>(Book item)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, item);
                stream.Seek(0, SeekOrigin.Begin);
                return stream.ToArray();
            }
        }

        private static object DeserializeFromBytes(byte[] bytes)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}
