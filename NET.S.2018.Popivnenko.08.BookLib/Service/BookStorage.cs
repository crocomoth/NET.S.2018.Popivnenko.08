using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;

namespace NET.S._2018.Popivnenko._08.BookLib.Model_and_service
{
    /// <summary>
    /// Provides basic functionality to store Books in binary files.
    /// </summary>
    public class BookStorage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string path;

        public BookStorage()
        {
            logger.Info("basic BookStorage constructor is called");
            this.path = AppDomain.CurrentDomain.BaseDirectory + "storage.txt";
        }

        public BookStorage(string path)
        {
            logger.Info("Bookstorage constructor with parameter is called");
            this.path = path;
        }

        /// <summary>
        /// Sets the <see cref="path"/> where Books will be saved or looked upon.
        /// </summary>
        /// <param name="dest">Path to the file which can also not exist.</param>
        public void SetPath(string dest)
        {
            logger.Info("Path is set to" + dest);
            this.path = dest;
        }

        /// <summary>
        /// Saves List of Books to file specified by <see cref="path"/>.
        /// throws <see cref="ArgumentNullException"/> if parameter is null.
        /// </summary>
        /// <param name="books">List to be saved.</param>
        public void SaveToFile(List<Book> books)
        {
            logger.Info("SaveToFile is called");
            if (books == null)
            {
                ArgumentNullException exception = new ArgumentNullException(nameof(books));
                logger.Error(exception, "error at SaveToFile");
                throw exception;
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
        /// Loads list of <see cref="Book"/> from a file specified by <see cref="path"/>.
        /// </summary>
        /// <returns>List of loaded Books.</returns>
        public List<Book> LoadFromFile()
        {
            logger.Info("LoadFromFile is called");
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(this.path, FileMode.OpenOrCreate);
            }
            catch (Exception e)
            {
                logger.Error(e, "error at LoadFromFile");
                throw e;
            }

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
            logger.Info("SerializeToBytes is called");
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
            logger.Info("DeserializeFromBytes is called");
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}
