using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3.Models
{
    class Category
    {
        int id;
        string name;
        string description;


        public const string tableName = "Categories";

        public int Id { get => id; }
        public string Name { get => name; }
        public string Description { get => description; }

        public Category(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <returns>List<Category></returns>
        public static List<Category> All()
        {
            List<Category> categories = new List<Category>();
            string[] attributes = { "CategoryID", "CategoryName", "Description" };


            SqlDataReader reader = DatabaseWrapper.SelectAll(attributes, tableName);

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                categories.Add(new Category(id, name, description));
            }

            reader.Close();

            return categories;
        }

        /// <summary>
        /// Gets categories products
        /// </summary>
        /// <returns>List<Product></returns>
        public List<Product> Products()
        {
            List<Product> products = new List<Product>();
            string[] attributes = { "ProductID", "ProductName" };
            SqlParameter category = new SqlParameter("CategoryID", this.id);

            SqlDataReader reader = DatabaseWrapper.Select(attributes, Product.tableName, category);

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                products.Add(new Product(id, name));
            }

            reader.Close();

            return products;
        }
    }
}
