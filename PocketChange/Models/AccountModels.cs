using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketChange.Models
{
    public enum AccountType
    {
        Checking,
        Savings,
        CreditCard
    }

    public class Account
    {
        public Account(AccountType type, string number, IEnumerable<Transaction> transactions)
        {
            Type = type;
            Number = number;
            Transactions = transactions;
        }

        public AccountType Type { get; }
        public string Number { get; }
        public IEnumerable<Transaction> Transactions { get; }

        public decimal GetBalance()
        {
            var totalBalance = 0.00m;
            foreach (var transaction in Transactions)
            {
                if (transaction.Type == TransactionType.Deposit)
                    totalBalance += transaction.Amount;
                else
                    totalBalance -= transaction.Amount;
            }

            return totalBalance;
        }
    }
}