﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSBModel;

namespace FSBAdmin.Controllers
{
    public class PartsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Parts
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.Component)
                .Include(c => c.Component.Module)
                .Include(m => m.Component.Module.Machine)
                .Include(m => m.Component.Module.Machine.Location)
                .Include(p => p.Component.Module.Machine.Location.Line)
                .Include(p => p.Component.Module.Machine.Location.UserType)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company.Country);
            return View(parts.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "PartId,PartName,ComponentId,Status")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "ComponentName", part.ComponentId);
            //return View(part);

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Include(p => p.Component)
                .Include(c => c.Component.Module)
                .Include(m => m.Component.Module.Machine)
                .Include(m => m.Component.Module.Machine.Location)
                .Include(p => p.Component.Module.Machine.Location.Line)
                .Include(p => p.Component.Module.Machine.Location.UserType)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company.Country)
                .SingleOrDefault(x => x.PartId == id);
            if (part == null)
            {
                return HttpNotFound();
            }
           // ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "ComponentName", part.ComponentId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,PartName,ComponentId,Status")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ComponentId = new SelectList(db.Components, "ComponentId", "ComponentName", part.ComponentId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Include(p => p.Component)
                .Include(c => c.Component.Module)
                .Include(m => m.Component.Module.Machine)
                .Include(m => m.Component.Module.Machine.Location)
                .Include(p => p.Component.Module.Machine.Location.Line)
                .Include(p => p.Component.Module.Machine.Location.UserType)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company)
                .Include(u => u.Component.Module.Machine.Location.UserType.Plant.Company.Country)
                .SingleOrDefault(x => x.PartId == id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
