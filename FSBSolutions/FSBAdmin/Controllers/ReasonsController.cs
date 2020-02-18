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
    public class ReasonsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Reasons
        public ActionResult Index()
        {
            var reasons = db.Reasons.Include(r => r.Verlustart);
            return View(reasons.ToList());
        }

        // GET: Reasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = db.Reasons.Find(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            return View(reason);
        }

        // GET: Reasons/Create
        public ActionResult Create()
        {
            ViewBag.VerlustartId = new SelectList(db.Verlustarts, "VerlustartId", "VerlustartName");
            return View();
        }

        // POST: Reasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReasonId,ReasonName,VerlustartId,Status")] Reason reason)
        {
            if (ModelState.IsValid)
            {
                db.Reasons.Add(reason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VerlustartId = new SelectList(db.Verlustarts, "VerlustartId", "VerlustartName", reason.VerlustartId);
            return View(reason);
        }

        // GET: Reasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = db.Reasons.Find(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            ViewBag.VerlustartId = new SelectList(db.Verlustarts, "VerlustartId", "VerlustartName", reason.VerlustartId);
            return View(reason);
        }

        // POST: Reasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReasonId,ReasonName,VerlustartId,Status")] Reason reason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VerlustartId = new SelectList(db.Verlustarts, "VerlustartId", "VerlustartName", reason.VerlustartId);
            return View(reason);
        }

        // GET: Reasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = db.Reasons.Find(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            return View(reason);
        }

        // POST: Reasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reason reason = db.Reasons.Find(id);
            db.Reasons.Remove(reason);
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
