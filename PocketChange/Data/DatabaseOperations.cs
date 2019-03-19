using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PocketChange.Models;

namespace PocketChange.Data
{
    public static class DatabaseOperations
    {
        private const string _connectionString =
            "Server=127.0.0.1,1401;Database=PocketChange;User=sa;Password=Agon1641!";
        
        private static DataTable ExecuteQuery(string commandText)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        private static DataRow ExecuteRowQuery(string commandText)
            => ExecuteQuery(commandText).Rows[0];

        private static T ExecuteScalar<T>(string commandText)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                return (T)cmd.ExecuteScalar();
            }
        }
        
        public static IEnumerable<Account> GetAccountsByUserId(Guid userId)
            => ExecuteQuery(
                    $@"SELECT [AccountId]
                    ,[AccountNumber]
                    ,[UserId]
                    ,[TypeId]
                    ,[ReadOnly]
                    ,[CreatedOn]
              FROM [dbo].[Account]
              WHERE [UserId] = '{userId}'")
                .AsEnumerable()
                .Select(o => new Account(o))
                .AsEnumerable();
        
        public static Account GetAccountById(Guid accountId)
            => new Account(ExecuteRowQuery(
                $@"
              SELECT [AccountId]
                    ,[AccountNumber]
                    ,[UserId]
                    ,[TypeId]
                    ,[ReadOnly]
                    ,[CreatedOn]
              FROM [dbo].[Account]
              WHERE [AccountId] = '{accountId}'"));

        private static string _getTransactionsByAccountId(Guid accountId)
            => $@"
              SELECT [TransactionId]
                    ,[AccountId]
                    ,[ProcessingDate]
                    ,[TransactionType]
                    ,[Amount]
                    ,[Description1]
              FROM [dbo].[Transaction]
              WHERE [AccountId] = '{accountId}'";
        public static IEnumerable<Transaction> GetTransactionsByAccountId(Guid accountId)
            => ExecuteQuery(
                _getTransactionsByAccountId(accountId))
                .AsEnumerable()
                .Select(o => new Transaction(o))
                .AsEnumerable();
    }
}