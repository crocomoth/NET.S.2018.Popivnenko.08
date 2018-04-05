namespace NET.S._2018.Popivnenko._08.BankAccountProj
{
    using System;
    using NET.S._2018.Popivnenko._08.BankAccountProj.API;
    using NET.S._2018.Popivnenko._08.BankAccountProj.Exception;
    
    /// <summary>
    /// Provides basic model and functionality of an a bank account.
    /// </summary>
    [Serializable]
    public class BankAccount : AbstractBankAccount
    {
        public BankAccount(long id, string nameOfOwner, string surnameOfOwner, Gradient gradient) : base(id, nameOfOwner, surnameOfOwner, gradient)
        {
            this.Funds = 0;
            this.BonusPoints = 0;
        }

        /// <summary>
        /// Funds kept on account.
        /// </summary>
        public override decimal Funds { get; protected set; }

        /// <summary>
        /// Adds funds to the account.
        /// </summary>
        /// <param name="funds">Actual amount to be added.</param>
        public override void AddFunds(decimal funds)
        {
            this.Funds += funds;
        }

        /// <summary>
        /// Withdraws money from acount.
        /// throws <see cref="InsufficientFundsException"/> if withdrawing amount is higher then current funds.
        /// </summary>
        /// <param name="funds">Actual amount to be withdrawen.</param>
        public override void Withdraw(decimal funds)
        {
            if (funds > this.Funds)
            {
                throw new InsufficientFundsException("insuficcient funds");
            }

            this.Funds -= funds;
        }
    }
}
