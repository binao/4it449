using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3.Models
{
    class Product
    {
        int id;
        string name;

        public const string tableName = "Products";

        public int Id { get => id; }
        public string Name { get => name; }

        public Product(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
