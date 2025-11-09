using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OOPMasteryDemo.Models;
using OOPMasteryDemo.Notifications;
using OOPMasteryDemo.Services;
using OOPMasteryDemo.Utilities;

namespace OOPMasteryDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("OOP Mastery Demo - Start\n");

            // -----------------------------
            // Encapsulation + Inheritance + Polymorphism
            // -----------------------------
            List<Account> accounts = new List<Account>
            {
                new SavingsAccount("SAV1001", 1000m, 0.04m),
                new CurrentAccount("CUR2001", 500m, 1000m)
            };

            foreach (var acc in accounts)
            {
                acc.Deposit(500);
                acc.Withdraw(200);
                // Polymorphic call:
                Console.WriteLine($"[{acc.AccountNumber}] Balance: {acc.GetBalance():C}  (Type: {acc.GetType().Name})");
                acc.CalculateInterest();
            }

            // -----------------------------
            // Interfaces + Strategy (Notifier)
            // -----------------------------
            INotifier emailNotifier = new EmailNotifier();
            emailNotifier.Notify("Welcome to OOPMasteryDemo!");

            // -----------------------------
            // Delegates & Events
            // -----------------------------
            var txManager = new TransactionManager();
            txManager.TransactionProcessed += (sender, e) =>
            {
                Console.WriteLine($"Event: Transaction processed for {e.AccountNumber}, Amount: {e.Amount}");
            };
            txManager.ProcessTransaction(accounts[0], 250m, "Deposit");

            // -----------------------------
            // Generics + Simple Repository + LINQ
            // -----------------------------
            var repo = new GenericRepository<Account>();
            repo.AddRange(accounts);
            repo.Add(new SavingsAccount("SAV3001", 2000m, 0.03m));

            var richAccounts = repo.Items.Where(a => a.GetBalance() > 1000).ToList();
            Console.WriteLine("\nAccounts with balance > 1000:");
            foreach (var r in richAccounts) Console.WriteLine($" - {r.AccountNumber} : {r.GetBalance():C}");

            // -----------------------------
            // Async demo
            // -----------------------------
            Console.WriteLine("\nStarting async demo (simulated long running task)...");
            var report = await GenerateReportAsync(repo.Items);
            Console.WriteLine(report);

            Console.WriteLine("\nDemo complete. Press any key to exit...");
            Console.ReadKey();
        }

        static async Task<string> GenerateReportAsync(IEnumerable<Account> accounts)
        {
            // simulate IO bound operation
            await Task.Delay(1000);
            var total = accounts.Sum(a => a.GetBalance());
            return $"Report: Total balance across accounts: {total:C}";
        }
    }
}
