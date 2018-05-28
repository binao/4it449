using Autorepair.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Autorepair.DataObjects
{
    public class CategoryDO
    {
        public int CategoryID { get; set; }

        public string CategoryShortCut { get; set; }
        public string CategoryName { get; set; }

        //Async load of categorz
        public static async Task<List<CategoryDO>> GetCategoriesAsync()
        {
            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return await context.Categories
                    .Select(x => new CategoryDO()
                    {
                        CategoryID = x.CategoryID,
                        CategoryShortCut = x.CategoryShortCut,
                        CategoryName = x.CategoryName
                    })
                    .ToListAsync();
            }
        }

        // Async load for category by name
        public static async Task<List<CategoryDO>> GetCategoryAsync(string nameOfCategory)
        {
            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return await context.Categories     
                    .Select(x => new CategoryDO()
                    {
                        CategoryID = x.CategoryID,
                        CategoryShortCut = x.CategoryShortCut,
                        CategoryName = x.CategoryName
                    })
                    .Where(x => x.CategoryShortCut.Equals(nameOfCategory))
                    .ToListAsync();
            }
        }

        // Load for category by name
        public static  List<CategoryDO> GetCategory(string nameOfCategory)
        {
            using (AutorepairEntities context =
                new AutorepairEntities())
            {
                return  context.Categories
                    .Select(x => new CategoryDO()
                    {
                        CategoryID = x.CategoryID,
                        CategoryShortCut = x.CategoryShortCut,
                        CategoryName = x.CategoryName
                    })
                    .Where(x => x.CategoryShortCut.Equals(nameOfCategory))
                    .ToList();
            }
        }
    }
}