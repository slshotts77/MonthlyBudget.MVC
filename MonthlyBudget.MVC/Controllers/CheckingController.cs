﻿using Microsoft.AspNet.Identity;
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
            var service = new CheckingService(userId);
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

        //    var service = CreateNoteService();

        //    if (service.CreateNote(model))
        //    {
        //        TempData["SaveResult"] = "Your note was created.";
        //        return RedirectToAction("Index");
        //    };

        //    ModelState.AddModelError("", "Note could not be created.");

        //    return View(model);
        //}

        //public ActionResult Details(int id)
        //{
        //    var svc = CreateNoteService();
        //    var model = svc.GetNoteById(id);

        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = CreateNoteService();
        //    var detail = service.GetNoteById(id);
        //    var model =
        //        new NoteEdit
        //        {
        //            NoteId = detail.NoteId,
        //            Title = detail.Title,
        //            Content = detail.Content
        //        };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, NoteEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.NoteId != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }

        //    var service = CreateNoteService();

        //    if (service.UpdateNote(model))
        //    {
        //        TempData["SaveResult"] = "Your note was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your note could not be updated.");
        //    return View(model);
        //}

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateNoteService();
        //    var model = svc.GetNoteById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateNoteService();

        //    service.DeleteNote(id);

        //    TempData["SaveResult"] = "Your note was deleted";

        //    return RedirectToAction("Index");
        //}

        //private NoteService CreateNoteService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new NoteService(userId);
        //    return service;
        //}
     
        private  CheckingService CreateCheckingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CheckingService(userId);
            
            return service;
        }

    }
}