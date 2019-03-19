using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PocketChange.Controllers;
using PocketChange.Data;

namespace PocketChange.Models
{
    public class Account
    {
        public Account(DataRow dr)
        {
            AccountId = dr.Field<Guid>("AccountId");
            AccountNumber = dr.Field<string>("AccountNumber");
            UserId = dr.Field<Guid>("UserId");
            Type = dr.Field<AccountType>("TypeId");
            ReadOnly = dr.Field<bool>("ReadOnly");
        }
        
        public Guid AccountId { get; }
        public string AccountNumber { get; }
        public Guid UserId { get; }
        public AccountType Type { get; }
        public bool ReadOnly { get; }
        public DateTime CreatedOn { get; }
    }
}