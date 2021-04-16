using MonthlyBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    public class CheckingAccountEntriesController : Controller
    {
        // GET: CheckingAccountEntries
        [Authorize]
        public ActionResult Index()
        {
            var model = new CheckingAccountEntriesListItem[0];
            return View(model);
        }
    }
}