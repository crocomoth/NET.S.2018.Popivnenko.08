using NET.S._2018.Popivnenko._08.BankAccountProj.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Popivnenko._08.BankAccountProj.service
{
    /// <summary>
    /// Provdes basic service to work with <see cref="AbstractBankAccount"/>
    /// </summary>
    public class BankService
    {
        public List<AbstractBankAccount> bankAccounts;

        public BankService()
        {
            bankAccounts = new List<AbstractBankAccount>();
        }

        private int CalculatePoints(decimal funds, Gradient gradient)
        {
            int result = Convert.ToInt32(funds / 100);
            switch (gradient)
            {
                case Gradient.Gold:
                    result = result * 3;
                    break;
                case Gradient.Platinum:
                    result = result * 5;
                    break;

            }
            return result;
        }

        /// <summary>
        /// Adds funds to the specified account and adjust amount of bonus points.
        /// </summary>
        /// <param name="account">Account to work with.</param>
        /// <param name="funds">Amount to be added.</param>
        public void AddFundsToAccount(AbstractBankAccount account, decimal funds)
        {
            account.bonusPoints += CalculatePoints(funds, account.gradient);
            account.AddFunds(funds);
        }

        public void WithdrawFromAccount(AbstractBankAccount account, decimal funds)
        {
            int bonusPoints = CalculatePoints(funds, account.gradient);
            if ((account.bonusPoints - bonusPoints) < 0)
            {
                account.bonusPoints = 0;
            }
            else
            {
                account.bonusPoints -= bonusPoints;
            }
            account.Withdraw(funds);
        }

        /// <summary>
        /// Creates new <see cref="BankAccount"/>.
        /// throws <see cref="ArgumentNullException"/> case any of parameters is null.
        /// </summary>
        /// <param name="id">Id of a new account.</param>
        /// <param name="nameOfOwner">Owner's name.</param>
        /// <param name="surnameOfOwner">Owner's last name.</param>
        /// <param name="gradient">Type of a card. <see cref="Gradient"/></param>
        public void CreateAccount(long id, string nameOfOwner, string surnameOfOwner, Gradient gradient)
        {
            BankAccount bankAccount;
            try
            {
                bankAccount = new BankAccount(id, nameOfOwner, surnameOfOwner, gradient);
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            bankAccounts.Add(bankAccount);
        }

        /// <summary>
        /// Allows to remove account.
        /// </summary>
        /// <param name="id">Id of an account to be removed.</param>
        public void RemoveAccount(long id)
        {
            AbstractBankAccount account = null;
            foreach (var elem in bankAccounts)
            {
                if (elem.id == id)
                {
                    account = elem;
                    break;
                }
            }
            if (account != null)
            {
                bankAccounts.Remove(account);
            }
            
        }
    }
}
