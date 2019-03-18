using System;
using System.Collections.Generic;

namespace PocketChange.Models.Accounts
{
    public class CheckingAccount : IAccount
    {
        
        
        public Guid Id { get; }
        public AccountType Type { get; }
        public string Number { get; }
        public IEnumerable<Transaction> History { get; }
        public IEnumerable<Goal> Goals { get; }
        public DateTime CreatedOn { get; }
    }
}