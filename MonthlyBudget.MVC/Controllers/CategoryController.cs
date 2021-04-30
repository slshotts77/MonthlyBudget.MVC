using Microsoft.AspNet.Identity;
using MonthlyBudget.Data;
using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetCategories();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be created.");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new CategoryService();
            var detail = service.GetCategoryById(id);
            var category = new CategoryEdit() { CategoryName = detail.CategoryName };
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    CategoryName = detail.CategoryName
                };

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = eCategoryService();

            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new CategoryService();
            var category = service.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
            {   
            var service = new CategoryService();
    
            service.DeleteCategory(id);
    
            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
            }
        }

            //private CategoryService CreateCategoryService()
            //{
            //    var userId = Guid.Parse(User.Identity.GetUserId());
            //    var service = new CategoryService(userId);
            //    return service;
            //}

    }
}
