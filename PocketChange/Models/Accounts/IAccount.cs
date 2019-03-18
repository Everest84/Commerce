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
        IEnumerable<Transaction> History { get; }
        IEnumerable<Goal> Goals { get; }
        DateTime CreatedOn { get; }
    }

    public enum AccountType
    {
        Savings,
        Checking,
        Credit
    }
}