using System.Collections.Generic;
using PocketChange.Data;

namespace PocketChange.Models
{
    public class SidebarViewModel
    {
        public SidebarViewModel()
        {
            Accounts = DatabaseOperations.GetAccounts();
        }
        
        public IEnumerable<Account> Accounts { get; }
    }
}