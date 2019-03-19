using System;
using System.Collections.Generic;
using PocketChange.Data;

namespace PocketChange.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            var userA = Guid.Parse("7aaac3da-7841-4773-8090-a4b509b0132d");
            var userB = Guid.Parse("94c5edfe-1824-4fbb-b0e2-e09bd304bd7b");
            
            Accounts = DatabaseOperations.GetAccountsByUserId(userA);
        }
        
        public IEnumerable<Account> Accounts { get; }
    }
}