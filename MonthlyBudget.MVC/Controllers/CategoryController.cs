using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Authorize]
        public ActionResult Index()
        {
            var model = new CategoryListItem[0];
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
    }
}