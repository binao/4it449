using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    static class DatabaseWrapper
    {
        private static string ConnectionString()
        {
            return Properties.Settings.Default.ConnectionString;
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString());
        }

        //Selects all data from given table with given attributes
        public static SqlDataReader SelectAll(string[] attributes, string tableName)
        {
            SqlConnection connection = CreateConnection();
            string query = SelectAllQuery(attributes, tableName);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        //Selects data with parameter
        public static SqlDataReader Select(string[] attributes, string tableName, SqlParameter parameter)
        {
            SqlConnection connection = CreateConnection();
            string query = SelectQuery(attributes, tableName, parameter);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(parameter);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        //Build select all query
        private static string SelectAllQuery(string[] attributes, string tableName)
        {
            string queryAttributes = string.Join(",", attributes);
            return string.Format("SELECT {0} from {1}", queryAttributes, tableName);
        }

        //Build select query with parameter
        private static string SelectQuery(string[] attributes, string tableName, SqlParameter parameter)
        {
            string queryAttributes = string.Join(",", attributes);
            string queryParameter = string.Format("{0} = @{0}", parameter.ParameterName);

            return string.Format("SELECT TOP 5 {0} from {1} WHERE {2} ORDER BY UnitsInStock Desc",
                queryAttributes, tableName, queryParameter);
        }
    }
}
