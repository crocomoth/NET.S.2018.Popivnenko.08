namespace NET.S._2018.Popivnenko._08.BankAccountProj.Exception
{
    using System;

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}
