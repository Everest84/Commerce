using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketChange.API.Models
{
    public class Profile
    {
        public Profile() { }

        public Profile(User user, IEnumerable<Account> accounts, IEnumerable<Transaction> transactions)
        {
            User = user;
            Accounts = accounts;
            Transactions = transactions;
        }

        public User User { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
