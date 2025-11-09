using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPMasteryDemo.Models
{
    //Abstract base class Abstraction
    public abstract class Account
    {
        //Encapsulation: private field and public property
        private decimal balance;
        public string AccountNumber {  get; set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            balance = initialBalance;
        }

        //Encapsulation - exposing behaviour, not direct field
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            balance += amount;
        }
        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive");
            if (amount > balance) throw new InvalidOperationException("Insufficient funds");
            balance -= amount;
        }
        public  decimal GetBalance() => balance;

        //Abstract method for derived classses to implement
        public abstract void CalculateInterest();
    }
}
