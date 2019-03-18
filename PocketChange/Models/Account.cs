using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PocketChange.Controllers;
using PocketChange.Models.Accounts;

namespace PocketChange.Models
{
    public class Account
    {
        public Account(AccountType type, string accountNumber, List<Transaction> transactions, DateTime createdOn, decimal startingBalance = 0)
        {
            Id = Guid.NewGuid();
            Type = type;
            Number = accountNumber;
            StartingBalance = startingBalance;
            Transactions = transactions;
            Goals = new List<Goal>();
            CreatedOn = createdOn;
        }

        public Account(Guid id)
        {
            //TODO: Retrieve the account from database
        }
        
        public Guid Id { get; }
        public AccountType Type { get; }
        public string Number { get; }
        public decimal StartingBalance { get; }
        public decimal Balance
        {
            get
            {
                return StartingBalance + 
                       Transactions.Where(o => o.Type == TransactionType.Deposit).Sum(o => o.Amount) - 
                       Transactions.Where(o => o.Type == TransactionType.Withdrawal).Sum(o => o.Amount);
            }
        }
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