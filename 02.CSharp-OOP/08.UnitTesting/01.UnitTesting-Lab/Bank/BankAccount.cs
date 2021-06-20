using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        private decimal amount = 0;

        public BankAccount(decimal amount, string accName)
        {
            this.Amount = amount;
            this.AccountName = accName;
        }

        public string AccountName { get; set; }

        public decimal Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount can't be a negative number");
                }

                this.amount = value;
            }
        }

        public void Deposit(decimal amount)
        {
            this.Amount += amount;
        }
    }
}
