using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPMasteryDemo.Models;

namespace OOPMasteryDemo.Services
{
    // Event args
    public class TransactionEventArgs : EventArgs
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }

    public class TransactionManager
    {
        // Delegate + Event - publisher-subscriber model
        public event EventHandler<TransactionEventArgs> TransactionProcessed;

        public void ProcessTransaction(Account account, decimal amount, string type)
        {
            if (type == "Deposit") account.Deposit(amount);
            else if (type == "Withdraw") account.Withdraw(amount);
            else throw new ArgumentException("Unknown transaction type");

            OnTransactionProcessed(new TransactionEventArgs
            {
                AccountNumber = account.AccountNumber,
                Amount = amount,
                Type = type
            });
        }

        protected virtual void OnTransactionProcessed(TransactionEventArgs e)
        {
            TransactionProcessed?.Invoke(this, e);
        }
    }
}
