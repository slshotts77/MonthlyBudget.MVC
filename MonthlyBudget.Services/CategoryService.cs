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
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CategoryName = model.CategoryName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx
                        .Categories
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>

                                new CategoryListItem
                                {
                                    CategoryId = e.CategoryId,
                                    CategoryName = e.CategoryName
                                }).ToList();
            }
        }

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
                })
                }
        }

        public bool UpdateCategory(int id, CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id);
                    entity.CategoryName

                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == CategoryId && e.OwnerId == _userId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
