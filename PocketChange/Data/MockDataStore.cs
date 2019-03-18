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
                    239.00m, 
                    new List<Transaction>
                    {
                        new Transaction(TransactionType.Withdrawal, 2.00m, new DateTime(2017, 2, 11), "Starbucks"),
                        new Transaction(TransactionType.Deposit, 800.00m, new DateTime(2017,4,11), "Payroll" )
                    }, new DateTime(2017, 1, 11)),
                new Account(AccountType.Credit, "3111 3450 2930 9203", 500.00m, new List<Transaction>(), new DateTime()),
                new Account(AccountType.Savings, "3011111130", 872.00m, new List<Transaction>(), new DateTime())
            };
            user2Accounts = new List<Account>();
        }
        
        private static IEnumerable<Account> user1Accounts { get; }
        private static IEnumerable<Account> user2Accounts { get; }

        public static IEnumerable<Account> Accounts => user1Accounts.Concat(user2Accounts);
    }
}