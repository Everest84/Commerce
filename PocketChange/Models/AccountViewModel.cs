using System;
using System.Collections.Generic;
using PocketChange.Data;

namespace PocketChange.Models
{
    public class AccountViewModel
    {
        public AccountViewModel(Guid accountId)
        {
            Account = DatabaseOperations.GetAccountById(accountId);
            Transactions = DatabaseOperations.GetTransactionsByAccountId(accountId);
        }
        
        public Account Account { get; }
        public IEnumerable<Transaction> Transactions { get; }
    }
}