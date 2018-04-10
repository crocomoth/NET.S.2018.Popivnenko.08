using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.S._2018.Popivnenko._08.BankAccountProj;
using NET.S._2018.Popivnenko._08.BankAccountProj.API;
using NET.S._2018.Popivnenko._08.BankAccountProj.Exception;
using NET.S._2018.Popivnenko._08.BankAccountProj.Service;

namespace NET.S._2018.Popivnenko._08.BankTester
{
    [TestClass]
    public class BankServiceTesters
    {
        private const decimal Epsilon = 0.001M;

        [TestMethod]
        public void BasicBankTestMethod()
        {
            BankService bankService = new BankService();
            Assert.IsNotNull(bankService.BankAccounts);
        }

        [TestMethod]
        public void BasicAddMoneyTest()
        {
            BankService bankService = new BankService();
            BankAccount account = new BankAccount(1, "wdwdw", "wdwdw", Gradient.Base);
            decimal sum = 10;
            bankService.AddFundsToAccount(account, sum);
            Assert.IsTrue((sum < account.Funds + Epsilon) && (sum > account.Funds - Epsilon));
        }

        [TestMethod]
        public void TestCreate()
        {
            BankService bankService = new BankService();
            BankAccount account = new BankAccount(1, "wdwdw", "wdwdw", Gradient.Base);
            List<AbstractBankAccount> bankAccounts = new List<AbstractBankAccount>();
            bankAccounts.Add(account);
            bankService.CreateAccount(1, "wdwdw", "wdwdw", Gradient.Base);
            Assert.AreNotEqual(bankAccounts[0], bankService.BankAccounts[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TestException()
        {
            BankService bankService = new BankService();
            BankAccount account = new BankAccount(1, "wdwdw", "wdwdw", Gradient.Base);
            decimal value = 1;
            bankService.WithdrawFromAccount(account, value);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            BankService bankService = new BankService();
            BankAccount account = new BankAccount(1, "wdwdw", "wdwdw", Gradient.Base);
            decimal sum = 10;
            bankService.AddFundsToAccount(account, sum);
            decimal withdraw = 5;
            bankService.WithdrawFromAccount(account, withdraw);
            Assert.IsTrue((sum - withdraw < account.Funds + Epsilon) && (sum - withdraw > account.Funds - Epsilon));
        }
    }
}
