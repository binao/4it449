using Autorepair.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;



namespace Autorepair.DataObjects
{
    public class ProductDO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }


        // Get product async depend on Categories - this method is for partial tables
        public static async Task<List<ProductDO>> GetProductsAsync(
            List<CategoryDO> categories)
        {
            List<int> CategoriesID = new List<int>();
        
            foreach (CategoryDO category in categories) {
                CategoriesID.Add(category.CategoryID);
            }

            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return await context.Products
                    .Where(x => CategoriesID.Contains(x.CategoryID))
                    .Select(x => new ProductDO()
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName
                    })
                    .ToListAsync();
            }
        }

        // Get product  depend on Categories
        public static List<ProductDO> GetProducts(
           List<CategoryDO> categories)
        {
            List<int> CategoriesID = new List<int>();

            foreach (CategoryDO category in categories)
            {
                CategoriesID.Add(category.CategoryID);
            }

            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return context.Products
                    .Where(x => CategoriesID.Contains(x.CategoryID))
                    .Select(x => new ProductDO()
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName
                    })
                    .ToList();
            }
        }

    }
}