using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PocketChange.API.Models
{
    public enum AccountType
    {
        Checking,
        Savings,
        Credit
    }

    public class Account
    {
        public Account() { }

        public Account(DataRow dr)
        {
            AccountId = dr.Field<Guid>("AccountId");
            UserId = dr.Field<Guid>("UserId");
            AccountType = dr.Field<int>("AccountType");
            AccountNumber = dr.Field<string>("AccountNumber");
        }

        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public int AccountType { get; set; }
        public string AccountNumber { get; set;  }
    }
}
