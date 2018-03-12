using JC_HomeWork4.Models;
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
            List<String> ExistCategory = new List<string>()
                ;
            // Create SQL query to ask for information about Categories

            using (MyCSharpDotNetEntities context = new MyCSharpDotNetEntities())
            {
                var smallCategories = context.Categories
                        .Select(x => new {
                            CategoryID = x.CategoryID,
                            CategoryName = x.CategoryName,
                            Description = x.Description
                        }); ;


                // Write to console information about Categories
                foreach (var smallCategorie in smallCategories)
                {
                    ExistCategory.Add(smallCategorie.CategoryID.ToString());
                    Console.WriteLine(
                        "{0}, {1} ({2})",
                        smallCategorie.CategoryID,
                        smallCategorie.CategoryName,
                        smallCategorie.Description);
                }

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
            if (ExistCategory.Contains(categoryID.ToString())){ 
            // Create SQL query to ask for information about TOP 5 products in choosen category
                using (MyCSharpDotNetEntities context = new MyCSharpDotNetEntities())
                {
                    var smallProducts =
                        context.Products
                            .Where(x => x.CategoryID.ToString().Equals(categoryID))
                            .OrderByDescending(x => x.UnitsInStock)
                            .Take(5)
                            .Select(x => new {
                                ProductID = x.ProductID,
                                ProductName = x.ProductName
                            });


                        foreach (var smallProduct in smallProducts)
                        {
                            Console.WriteLine(
                                "ID: {0}, Name: {1} ",
                                smallProduct.ProductID,
                                smallProduct.ProductName);
                        }

                }
            }
            else {
                Console.WriteLine("Unknow ID");
            }

        // END part of the code 

        Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press enter to close the application");
                Console.Read();
            
        }
    }
}
