using NUnit.Framework;
using System;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private decimal amount;
        private string name;
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
            //SetUp method is where Arrange happens
            this.amount = 5;
            this.name = "Pesho";
            this.account = new BankAccount(this.amount, this.name);
        }

        [Test]
        public void WhenAccountInitializedWithPositiveNumber_AmountShouldChange()
        {
            Assert.That(this.account.Amount, Is.EqualTo(amount));

            Assert.AreEqual(account.Amount, amount);
        }

        [Test]
        public void ShouldChangeAmount_WhenDepositIsMade()
        {
            this.account.Deposit(amount);

            Assert.That(this.account.Amount, Is.EqualTo(amount * 2));

        }
    }
}
