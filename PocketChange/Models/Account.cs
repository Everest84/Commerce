using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PocketChange.Controllers;

namespace PocketChange.Models
{
    public class Account
    {
        /// <summary>
        /// Initializes a new account
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accountNumber"></param>
        /// <param name="startingBalance"></param>
        public Account(AccountType type, string accountNumber, decimal startingBalance, List<Transaction> transactions, DateTime createdOn)
        {
            Id = Guid.NewGuid();
            Type = type;
            Number = accountNumber;
            StartingBalance = startingBalance;
            Transactions = transactions;
            Goals = new List<Goal>();
            CreatedOn = createdOn;
        }

        /// <summary>
        /// Initializes an existing account by it's ID from the database
        /// </summary>
        /// <param name="id"></param>
        public Account(Guid id)
        {
            //TODO: Retrieve the account from database
        }
        
        public Guid Id { get; }
        public AccountType Type { get; }
        public string Number { get; }
        public decimal StartingBalance { get; }
        public decimal Balance => StartingBalance + Transactions.Where(o => o.Type == TransactionType.Deposit).Sum(o => o.Amount)
                                  - Transactions.Where(o => o.Type == TransactionType.Withdrawal).Sum(o => o.Amount);
        public List<Transaction> Transactions { get; }
        public List<Goal> Goals { get; }
        public DateTime CreatedOn { get; }
    }

    public enum AccountType
    {
        Checking,
        Savings,
        Credit
    }
}