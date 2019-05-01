using System;
using System.Collections.Generic;
using System.Linq;
using PocketChange.Models;

namespace PocketChange.Data
{
    public static class DatabaseOperations
    {
        public static IEnumerable<Account> GetAccounts()
        {
            return MockAccounts;
        }

        public static Account GetAccountByNumber(string accountNumber)
        {
            return MockAccounts.Single(o => o.Number == accountNumber);
        }
        
        private static IEnumerable<Account> MockAccounts { get; } = new List<Account>
        {
            new Account(AccountType.Checking, "1111", new List<Transaction>
            {
                new Transaction(TransactionType.Deposit, 25.00m, "Account Open", DateTime.Now),
                new Transaction(TransactionType.Withdrawal, 12.31m, "Starbucks", DateTime.Now),
                new Transaction(TransactionType.Deposit, 4273.31m, "ACH Direct Deposit", DateTime.Now),
                new Transaction(TransactionType.Withdrawal, 120.40m, "GAP", DateTime.Now),
                new Transaction(TransactionType.Withdrawal, 3268.98m, "Apple", DateTime.Now),
                new Transaction(TransactionType.Deposit, 4273.31m, "ACH Direct Deposit", DateTime.Now)
            }),
            new Account(AccountType.Savings, "2222", new List<Transaction>
            {
                new Transaction(TransactionType.Deposit, 25.00m, "Account Open", DateTime.Now),
                new Transaction(TransactionType.Deposit, 5000.00m, "Cash Deposit", DateTime.Now)
            }),
            new Account(AccountType.CreditCard, "3333", new List<Transaction>
            {
                new Transaction(TransactionType.Withdrawal, 32.45m, "Macy's", DateTime.Now),
                new Transaction(TransactionType.Withdrawal, 67.12m, "Dillard's", DateTime.Now)
            })
            
        };
    }
}