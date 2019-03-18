using System.Collections.Generic;
using PocketChange.Data;

namespace PocketChange.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Accounts = MockDataStore.Accounts;
        }
        
        public IEnumerable<Account> Accounts { get; }
    }
}