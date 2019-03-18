using System;
using System.Data;
using System.Data.SqlClient;
using PocketChange.Models.Accounts;

namespace PocketChange.Data
{
    public static class DatabaseOperations
    {
        private static DataTable ExecuteQuery(string commandText)
        {
            using (var conn = new SqlConnection())
            using (var cmd = new SqlCommand())
            using (var reader = cmd.ExecuteReader())
            {
                var dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        private static DataRow ExecuteRowQuery(string commandText)
            => ExecuteQuery(commandText).Rows[0];

        public static SavingsAccount GetSavingsAccount(Guid id)
            => new SavingsAccount(ExecuteRowQuery(""));
    }
}