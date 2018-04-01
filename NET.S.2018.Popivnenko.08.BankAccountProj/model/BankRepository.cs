using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using NET.S._2018.Popivnenko._08.BankAccountProj.API;

namespace NET.S._2018.Popivnenko._08.BankAccountProj.model
{
    /// <summary>
    /// Provides functinality to store bank accounts in a binary file.
    /// </summary>
    public class BankRepository
    {
        private string path;

        public BankRepository()
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory + "storage.txt";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">File where info will be saved.</param>
        public BankRepository(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// Saves List of BankAccounts to a file specified by <see cref="path"/>.
        /// throws <see cref="SerializationException"/> case objects can't be serialized.
        /// </summary>
        /// <param name="accounts">List of accounts to be stored.</param>
        public void SaveToFile(List<AbstractBankAccount> accounts)
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, accounts);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                fileStream.Dispose();
            }
        }

        /// <summary>
        /// Loads list of BankAccounts from the file specified by <see cref="path"/>.
        /// throws <see cref="SerializationException"/> if objects can't be deserialized.
        /// </summary>
        /// <returns>List of loaded objects.</returns>
        public List<AbstractBankAccount> LoadFromFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            List<AbstractBankAccount> accounts = null;
            try
            {
                accounts = (List<AbstractBankAccount>)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                fileStream.Dispose();
            }

            return accounts;
        }
    }
}
