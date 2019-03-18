using System;

namespace PocketChange.Models
{
    public class Transaction
    {
        public Transaction(TransactionType type, decimal amount, DateTime processingDate, string description)
        {
            Type = type;
            Amount = amount;
            ProcessingDate = processingDate;
            Description = description;
        }
        
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public DateTime ProcessingDate { get; }
        public string Description { get; }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}