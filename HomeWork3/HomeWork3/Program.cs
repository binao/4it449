using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork3.Models;
using System.Data.SqlClient;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Get categories
                List<Category> categories = Category.All();

                //Print categories
                PrintCategories(categories);

                //Get category from user
                Category selectedCategory = SelectCategory(categories);

                //Print category products
                PrintProducts(selectedCategory);


                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Asks for category id
        /// </summary>
        /// <param name="question"></param>
        /// <returns>Integer</returns>
        private static int AskCategoryId(string question)
        {
            Console.Write(question);

            //Try parse users input to integer
            bool result = Int32.TryParse(Console.ReadLine(), out int categoryId);
            //Return result if integer else ask recursively again
            return result ? categoryId : AskCategoryId(question);
        }

        /// <summary>
        /// Selects category by user given id
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>Category</returns>
        private static Category SelectCategory(List<Category> categories)
        {
            int categoryId = AskCategoryId("Enter category ID: ");

            //Get category with given id
            Category selectedCategory = categories.FirstOrDefault(category => category.Id == categoryId);

            if (selectedCategory == null)
            {
                Console.WriteLine("Category with id: {0} does not exists", categoryId);
                return SelectCategory(categories);
            }

            return selectedCategory;
        }

        /// <summary>
        /// Prints products
        /// </summary>
        /// <param name="products"></param>
        private static void PrintProducts(Category category)
        {
            Console.Clear();
            Console.WriteLine("---{0} Products---", category.Name);
            List<Product> products = category.Products();
            if (products.Any())
            {
                //Iterate over products and write to console
                products.ForEach(product => Console.WriteLine("{0} {1}", product.Id, product.Name));
            }
            else Console.WriteLine("No products available");
        }

        /// <summary>
        /// Prints categories
        /// </summary>
        /// <param name="categories"></param>
        private static void PrintCategories(List<Category> categories)
        {
            Console.Clear();
            Console.WriteLine("---CATEGORIES---");
            if (categories.Any())
            {
                //Iterate over products and write to console
                categories.ForEach(category => 
                    Console.WriteLine("{0} {1} - {2}", category.Id, category.Name, category.Description));
            }
            else Console.WriteLine("No categories available");
        }
    }
}
