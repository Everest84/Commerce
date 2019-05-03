using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PocketChange.API.Data
{
    public static class SqlConnector
    {
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=PocketChange;Integrated Security=True;";

        public static DataTable ExecuteQuery(string query)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Connection.Open();

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                    dt.Load(reader);

                cmd.Connection.Close();

                return dt;
            }
        }

        public static DataRow ExecuteRowQuery(string query)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Connection.Open();

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                    dt.Load(reader);

                cmd.Connection.Close();

                if (dt.Rows.Count >= 1)
                    return dt.Rows[0];

                return null;
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Connection.Open();

                var result = cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                return result;
            }
        }
    }
}
