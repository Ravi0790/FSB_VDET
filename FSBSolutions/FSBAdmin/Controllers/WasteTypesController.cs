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
    public class WasteTypesController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: WasteTypes
        public ActionResult Index()
        {
            var wasteTypes = db.WasteTypes.Include(w => w.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country) ; ;
            return View(wasteTypes.ToList());
        }

        // GET: WasteTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteType wasteType = db.WasteTypes.Find(id);
            if (wasteType == null)
            {
                return HttpNotFound();
            }
            return View(wasteType);
        }

        // GET: WasteTypes/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: WasteTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WasteTypeId,WasteTypeName,UserTypeId,Status")] WasteType wasteType)
        {
            if (ModelState.IsValid)
            {
                db.WasteTypes.Add(wasteType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", wasteType.UserTypeId);
            return View(wasteType);
        }

        // GET: WasteTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteType wasteType = db.WasteTypes.Include(u => u.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x => x.WasteTypeId == id);
            if (wasteType == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", wasteType.UserTypeId);
            return View(wasteType);
        }

        // POST: WasteTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WasteTypeId,WasteTypeName,UserTypeId,Status")] WasteType wasteType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wasteType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", wasteType.UserTypeId);
            return View(wasteType);
        }

        // GET: WasteTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WasteType wasteType = db.WasteTypes.Include(u => u.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x => x.WasteTypeId == id);
            if (wasteType == null)
            {
                return HttpNotFound();
            }
            return View(wasteType);
        }

        // POST: WasteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WasteType wasteType = db.WasteTypes.Find(id);
            db.WasteTypes.Remove(wasteType);
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
