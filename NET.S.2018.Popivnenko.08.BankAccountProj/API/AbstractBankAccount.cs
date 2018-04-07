namespace NET.S._2018.Popivnenko._08.BankAccountProj.API
{
    using System;

    /// <summary>
    /// Abstract class for a Bank Account.
    /// </summary>
    public abstract class AbstractBankAccount
    {
        private long id;
        private string nameOfOwner;
        private string surnameOfOwner;
        private Gradient gradient;
        private int bonusPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBankAccount"/> class.
        /// </summary>
        /// <param name="id">Id of account.</param>
        /// <param name="nameOfOwner">Name of owner.</param>
        /// <param name="surnameOfOwner">Surname of owner.</param>
        /// <param name="gradient">Type of a card <see cref="Gradient"/></param>
        protected AbstractBankAccount(long id, string nameOfOwner, string surnameOfOwner, Gradient gradient)
        {
            this.Id = id;
            this.NameOfOwner = nameOfOwner ?? throw new ArgumentNullException(nameof(nameOfOwner));
            this.SurnameOfOwner = surnameOfOwner ?? throw new ArgumentNullException(nameof(surnameOfOwner));
            this.Gradient = gradient;
        }

        public abstract decimal Funds { get; protected set; }

        public long Id { get => this.id; protected set => this.id = value; }

        public string NameOfOwner { get => this.nameOfOwner; set => this.nameOfOwner = value; }

        public string SurnameOfOwner { get => this.surnameOfOwner; set => this.surnameOfOwner = value; }

        public Gradient Gradient { get => this.gradient; set => this.gradient = value; }

        public int BonusPoints { get => this.bonusPoints; set => this.bonusPoints = value; }

        public abstract void AddFunds(decimal funds);

        public abstract void Withdraw(decimal funds);
    }
}
