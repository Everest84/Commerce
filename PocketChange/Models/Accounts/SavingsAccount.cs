using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PocketChange.Data;

namespace PocketChange.Models.Accounts
{
    public class SavingsAccount : IAccount
    {
        public SavingsAccount() { }

        public SavingsAccount(DataRow dr)
        {
            Id = dr.Field<Guid>("Id");
            Type = dr.Field<AccountType>("Type");
            Number = dr.Field<string>("Number");
            CreatedOn = dr.Field<DateTime>("CreatedOn");
        }
        
        public Guid Id { get; }
        public AccountType Type { get; }
        public string Number { get; }

        public decimal AvailableBalance => History.Where(o => o.Type == TransactionType.Deposit).Sum(o => o.Amount) -
                                           History.Where(o => o.Type == TransactionType.Withdrawal).Sum(o => o.Amount);
        public ICollection<Transaction> History { get; }
        public ICollection<Goal> Goals { get; }
        public DateTime CreatedOn { get; }
    }
}