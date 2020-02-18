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
    public class VerlustsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Verlusts
        public ActionResult Index()
        {
            var verlusts = db.Verlusts.Include(v => v.UserType);
            return View(verlusts.ToList());
        }

        // GET: Verlusts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlust verlust = db.Verlusts.Find(id);
            if (verlust == null)
            {
                return HttpNotFound();
            }
            return View(verlust);
        }

        // GET: Verlusts/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName");
            return View();
        }

        // POST: Verlusts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VerlustId,VerlustName,UserTypeId,Status")] Verlust verlust)
        {
            if (ModelState.IsValid)
            {
                db.Verlusts.Add(verlust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlust.UserTypeId);
            return View(verlust);
        }

        // GET: Verlusts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlust verlust = db.Verlusts.Find(id);
            if (verlust == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlust.UserTypeId);
            return View(verlust);
        }

        // POST: Verlusts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VerlustId,VerlustName,UserTypeId,Status")] Verlust verlust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verlust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", verlust.UserTypeId);
            return View(verlust);
        }

        // GET: Verlusts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verlust verlust = db.Verlusts.Find(id);
            if (verlust == null)
            {
                return HttpNotFound();
            }
            return View(verlust);
        }

        // POST: Verlusts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verlust verlust = db.Verlusts.Find(id);
            db.Verlusts.Remove(verlust);
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
