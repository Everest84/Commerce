using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PocketChange.Models.Accounts
{
    /// <summary>
    /// CreditAccount is an account based on a credited balance, so funding is provided by the banking institution.
    /// This means that all transactions will "subtract" the remaining balance from the credit line. For instance, if
    /// your credit line is $500, and the user has made several purchases summing to $100, then the user's remaining
    /// balance will be $400. A negative balance means the user has spent over their credit line.
    /// </summary>
    public class CreditAccount : IAccount
    {
        public CreditAccount(DataRow dr)
        {
            Id = dr.Field<Guid>("Id");
            Type = dr.Field<AccountType>("Type");
        }
        
        public Guid Id { get; }
        public AccountType Type { get; }
        public string Number { get; }
        public decimal CreditLine { get; }
        public decimal Balance => History.Where(o => o.Type == TransactionType.Deposit).Sum(o => o.Amount) -  
                                  History.Where(o => o.Type == TransactionType.Withdrawal).Sum(o => o.Amount);
        public ICollection<Transaction> History { get; }
        public ICollection<Goal> Goals { get; }
        public DateTime CreatedOn { get; }
    }
}