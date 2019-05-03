using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PocketChange.API.Models
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }

    public class Transaction
    {
        public Transaction() { }

        public Transaction(DataRow dr)
        {
            TransactionId = dr.Field<Guid>("TransactionId");
            AccountId = dr.Field<Guid>("AccountId");
            TransactionType = dr.Field<int>("TransactionType");
            Amount = dr.Field<decimal>("Amount");
            Description = dr.Field<string>("Description");
            ProcessingDate = dr.Field<DateTime>("ProcessingDate");
        }

        public Guid TransactionId { get; set; }
        public Guid AccountId { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ProcessingDate { get; set; }
    }
}
