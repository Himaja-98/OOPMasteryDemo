using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPMasteryDemo.Models
{
    public  class SavingsAccount : Account
    {
        public decimal InterestRate { get; private set; }
        public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate): base(accountNumber,initialBalance)
        {
            InterestRate = interestRate;
        }
        //Polymorphism : override base implementation 
        public override void CalculateInterest()
        {
            var interest = GetBalance() * InterestRate;
            //Using Deposit to reuse logic, demonstrating encapsulation
            Deposit(interest);
            Console.WriteLine($"SavingsAccount {AccountNumber} credited interest : {interest:C}");
        }
    }
}
