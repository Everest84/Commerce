using System;
using System.Data;

namespace PocketChange.Models
{
    public class Transaction
    {
        public Transaction(DataRow dr)
        {
            TransactionId = dr.Field<Guid>("TransactionId");
            AccountId = dr.Field<Guid>("AccountId");
            ProcessingDate = dr.Field<DateTime>("ProcessingDate");
            TransactionType = dr.Field<char>("TransactionType");
            Amount = dr.Field<float>("Amount");
            Description = dr.Field<string>("Description1");
        }
        
        public Guid TransactionId { get; }
        public Guid AccountId { get; }
        public DateTime ProcessingDate { get; }
        public char TransactionType { get; }
        public float Amount { get; }
        public string Description { get; }
    }
}