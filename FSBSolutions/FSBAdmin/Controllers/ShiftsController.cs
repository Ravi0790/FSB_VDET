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
    public class ShiftsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Shifts
        public ActionResult Index()
        {
            var shifts = db.Shifts.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country);
            return View(shifts.ToList());
        }

        // GET: Shifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // GET: Shifts/Create
        public ActionResult Create()
        {
            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftId,ShiftName,ShiftStartTime,ShiftEndTime,PlantId,Status")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Shifts.Add(shift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", shift.PlantId);
            return View(shift);
        }

        // GET: Shifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country).SingleOrDefault(x => x.ShiftId == id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", shift.PlantId);
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftId,ShiftName,ShiftStartTime,ShiftEndTime,PlantId,Status")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", shift.PlantId);
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Include(s => s.Plant).Include(p => p.Plant.Company).Include(c => c.Plant.Company.Country).SingleOrDefault(x=>x.ShiftId==id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shift shift = db.Shifts.Find(id);
            db.Shifts.Remove(shift);
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
