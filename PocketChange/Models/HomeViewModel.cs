using System.Collections.Generic;

namespace PocketChange.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(IEnumerable<Account> accounts)
        {
            Accounts = accounts;
        }
        
        public IEnumerable<Account> Accounts { get; }
    }
}