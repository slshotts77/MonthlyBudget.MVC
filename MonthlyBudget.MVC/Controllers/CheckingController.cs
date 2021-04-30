using Microsoft.AspNet.Identity;
using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MonthlyBudget.MVC.Controllers
{
    public class CheckingController : Controller
    {
        // GET: Checking
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetEntries();

            return View(model);
        }

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCheckingService();

            if (service.CreateChecking(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);

            //service.CreateChecking(model);

            //return RedirectToAction("Index");
        }

        var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
    };


    ModelState.AddModelError("", "Note could not be created.");

            return View(model);
}
