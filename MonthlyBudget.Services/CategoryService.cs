using MonthlyBudget.Data;
using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyBudget.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All
        public List<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                    .Categories
                    .Select(e => new CategoryListItem
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
                    }).ToList();
            }
        }

        // Get by Id
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Categories
                    .Single(e => e.CategoryId == id);
                var category = new CategoryDetail()
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName                                       
                };

                return category;
            }
        }

        // Edit by Id
        public bool UpdateCategory(int id, CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == id);
                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete by Id
        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == id);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
