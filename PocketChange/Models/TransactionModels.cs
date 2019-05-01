using System;

namespace PocketChange.Models
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
    
    public class Transaction
    {
        public Transaction(TransactionType type, decimal amount, string description, DateTime processingDate)
        {
            Type = type;
            Amount = amount;
            Description = description;
            ProcessingDate = processingDate;
        }
        
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime ProcessingDate { get; }
    }
}