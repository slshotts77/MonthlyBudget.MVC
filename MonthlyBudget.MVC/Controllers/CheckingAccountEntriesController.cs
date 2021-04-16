﻿using MonthlyBudget.Models;
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
              
        //GET
        public ActionResult Create()
        {
            return View();
        }




        //-------------------------->


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


        }
}