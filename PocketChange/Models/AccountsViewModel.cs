using System.Collections.Generic;

namespace PocketChange.Models
{
    public class AccountsViewModel
    {
        public AccountsViewModel(IEnumerable<Account> accounts)
        {
            Accounts = accounts;
        }
        
        public IEnumerable<Account> Accounts { get; }
    }
}