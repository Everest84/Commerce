using System;
using System.Collections.Generic;
using System.Linq;
using PocketChange.Models;

namespace PocketChange.Data
{
    public static class MockDataStore
    {
        static MockDataStore()
        {
            user1Accounts = new List<Account>
            {
                new Account(AccountType.Checking, 
                    "211111110", 
                    new List<Transaction>
                    {
                        new Transaction(TransactionType.Withdrawal, 2.00m, new DateTime(2017, 11, 2), "Starbucks"),
                        new Transaction(TransactionType.Deposit, 800.00m, new DateTime(2017,11,4), "Payroll" ),
                        new Transaction(TransactionType.Withdrawal, 8.00m, new DateTime(2017, 11, 7), "Chipotle")
                    }, new DateTime(2017, 1, 11), 239.00m),
                new Account(AccountType.Credit, "3111 3450 2930 9203", new List<Transaction>(), new DateTime(), 500.00m),
                new Account(AccountType.Savings, "3011111130", new List<Transaction>(), new DateTime(), 872.00m)
            };
            user2Accounts = new List<Account>();
        }
        
        private static IEnumerable<Account> user1Accounts { get; }
        private static IEnumerable<Account> user2Accounts { get; }

        public static IEnumerable<Account> Accounts => user1Accounts.Concat(user2Accounts);
    }
}