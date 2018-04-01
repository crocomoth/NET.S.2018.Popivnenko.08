using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NET.S._2018.Popivnenko._08.BookLib.model_and_service
{
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

        public void SetPath(string dest)
        {
            this.path = dest;
        }

        public void SaveToFile(List<Book> books)
        {
            FileStream fileStream = new FileStream(this.path, FileMode.OpenOrCreate);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            foreach (var elem in books)
            {
                binaryWriter.Write(SerializeToBytes(elem));
            }
            fileStream.Dispose();
            binaryWriter.Dispose();
        }

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

        public static byte[] SerializeToBytes<Book>(Book item)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, item);
                stream.Seek(0, SeekOrigin.Begin);
                return stream.ToArray();
            }
        }

        public static object DeserializeFromBytes(byte[] bytes)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}
