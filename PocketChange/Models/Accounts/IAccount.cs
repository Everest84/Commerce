using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketChange.Models.Accounts
{
    public interface IAccount
    {
        Guid Id { get; }
        AccountType Type { get; }
        string Number { get; }
        ICollection<Transaction> History { get; }
        ICollection<Goal> Goals { get; }
        DateTime CreatedOn { get; }
    }

    public enum AccountType
    {
        Savings,
        Checking,
        Credit
    }
}