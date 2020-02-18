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
    public class LinesController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Lines
        public ActionResult Index()
        {
            var lines = db.Lines.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country); ;
            return View(lines.ToList());
        }

        // GET: Lines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // GET: Lines/Create
        public ActionResult Create()
        {
            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Lines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineId,LineName,PlantId,Status")] Line line)
        {
            if (ModelState.IsValid)
            {
                db.Lines.Add(line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", line.PlantId);
            return View(line);
        }

        // GET: Lines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country).SingleOrDefault(x=>x.LineId==id); 
            if (line == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", line.PlantId);
            return View(line);
        }

        // POST: Lines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineId,LineName,PlantId,Status")] Line line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", line.PlantId);
            return View(line);
        }

        // GET: Lines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country).SingleOrDefault(x => x.LineId == id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // POST: Lines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line line = db.Lines.Find(id);
            db.Lines.Remove(line);
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
