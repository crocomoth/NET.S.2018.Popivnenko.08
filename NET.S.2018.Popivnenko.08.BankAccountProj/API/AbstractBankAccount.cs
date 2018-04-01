using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BankAccountProj.API
{
    /// <summary>
    /// Abstract class for a Bank Account.
    /// </summary>
    public abstract class AbstractBankAccount
    {

        public long id;
        public string nameOfOwner;
        public string surnameOfOwner;
        public Gradient gradient;
        public int bonusPoints;

        protected AbstractBankAccount(long id, string nameOfOwner, string surnameOfOwner, Gradient gradient)
        {
            this.id = id;
            this.nameOfOwner = nameOfOwner ?? throw new ArgumentNullException(nameof(nameOfOwner));
            this.surnameOfOwner = surnameOfOwner ?? throw new ArgumentNullException(nameof(surnameOfOwner));
            this.gradient = gradient;
        }

        public abstract decimal Funds { get; protected set; }
        public abstract void AddFunds(decimal funds);
        public abstract void Withdraw(decimal funds);
    }
}
