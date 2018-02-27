using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosnoleApp_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AVAILABLE CATEGORIES:");
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            // Create SQL query to ask for information about Categories
            string connectionString =
            "Server=ookj3vjulf.database.windows.net;" +
            "Database=MyCSharpDotNet;" +
            "User Id=dbuser;" +
            "Password=Databa5e;";

            string queryString =
                     "SELECT CategoryID, CategoryName, Description " +
                    "FROM Categories";

            using (SqlConnection sqlConnection =
                new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int rowIndex = 0;
                // Write to console information about Categories
                while (sqlDataReader.Read())
                {
                    Console.Write("[" + sqlDataReader[0] + "] ");
                    Console.Write(sqlDataReader[1] + " ");
                    Console.Write("(" + sqlDataReader[2] + ")");

                    rowIndex++;

                    Console.WriteLine();
                }

                sqlDataReader.Close();
            }

            // End part about category
            Console.WriteLine();
            bool idIsNotReady = true;
            string categoryID = null;

            // Choose category ID and validate it
            while (idIsNotReady)
            {
                Console.Write("To list product, enter the category ID: ");


                categoryID = Console.ReadLine();

                try
                {
                    Int32.Parse(categoryID);
                    idIsNotReady = false;
                }
                catch
                {
                    Console.WriteLine("Wrong input! ");
                }

            }


            Console.Clear();
            Console.WriteLine("LIST OF PRODUCTS:");
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            // Create SQL query to ask for information about TOP 5 products in choosen category
            queryString =
                "SELECT TOP 5 ProductID, ProductName " +
                 "FROM Products " +
                 "WHERE CategoryID = @CategoryID " +
                 "ORDER BY UnitsInStock Desc";

            using (SqlConnection sqlConnection =
                new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                SqlParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = "CategoryID";
                sqlParameter.Value = categoryID;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                int rowIndex = 0;
                //Check if there are some information about choosen Category
                if (!sqlDataReader.HasRows)
                {
                    Console.Write("Empty or wrong number of category");
                }
                else
                {
                    // Write to console information about Products
                    while (sqlDataReader.Read())
                    {
                        Console.Write("ID: " + sqlDataReader[0] + ", ");
                        Console.Write("Name: " + sqlDataReader[1]);


                        rowIndex++;

                        Console.WriteLine();
                    }
                }
                sqlDataReader.Close();

                // END part of the code 

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press enter to close the application");
                Console.Read();
            }
        }
    }
}
