using System;
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
    public class VerlustartsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Verlustarts
        public ActionResult Index()
        {
            var verlustarts = db.Verlustarts.Include(v => v.UserType);
            return View(verlustarts.ToList());
        }

        // GET: Verlustarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlustart verlustart = db.Verlustarts.Find(id);
            if (verlustart == null)
            {
                return HttpNotFound();
            }
            return View(verlustart);
        }

        // GET: Verlustarts/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName");
            return View();
        }

        // POST: Verlustarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VerlustartId,VerlustartName,UserTypeId,Status")] Verlustart verlustart)
        {
            if (ModelState.IsValid)
            {
                db.Verlustarts.Add(verlustart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlustart.UserTypeId);
            return View(verlustart);
        }

        // GET: Verlustarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlustart verlustart = db.Verlustarts.Find(id);
            if (verlustart == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlustart.UserTypeId);
            return View(verlustart);
        }

        // POST: Verlustarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VerlustartId,VerlustartName,UserTypeId,Status")] Verlustart verlustart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verlustart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlustart.UserTypeId);
            return View(verlustart);
        }

        // GET: Verlustarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlustart verlustart = db.Verlustarts.Find(id);
            if (verlustart == null)
            {
                return HttpNotFound();
            }
            return View(verlustart);
        }

        // POST: Verlustarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verlustart verlustart = db.Verlustarts.Find(id);
            db.Verlustarts.Remove(verlustart);
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
