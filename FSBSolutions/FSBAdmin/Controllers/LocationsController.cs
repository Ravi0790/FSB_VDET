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
    public class LocationsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = db.Locations.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country);
            return View(locations.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocationName,Status,LineId,UserTypeId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", location.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", location.UserTypeId);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x => x.LocationId == id); 
            if (location == null)
            {
                return HttpNotFound();
            }
            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", location.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", location.UserTypeId);
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocationName,Status,LineId,UserTypeId")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", location.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", location.UserTypeId);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x => x.LocationId == id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
