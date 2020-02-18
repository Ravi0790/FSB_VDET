using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FSBModel;

namespace FSBAPI.Controllers
{
    public class UserTypesController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: UserTypes
        public ActionResult Index()
        {
            var userTypes = db.UserTypes.Include(u => u.Plant);
            return View(userTypes.ToList());
        }


        [Route("api/UserTypes/Plant/{id}")]
        public IQueryable<UserType> GetUserTypesByPlant(int id)
        {
            return db.UserTypes.Where(p => p.PlantId == id);
        }

        // GET: UserTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // GET: UserTypes/Create
        public ActionResult Create()
        {
            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode");
            return View();
        }

        // POST: UserTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTypeId,UserTypeName,PlantId,Status")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.UserTypes.Add(userType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", userType.PlantId);
            return View(userType);
        }

        // GET: UserTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", userType.PlantId);
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTypeId,UserTypeName,PlantId,Status")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantId = new SelectList(db.Plants, "PlantId", "PlantCode", userType.PlantId);
            return View(userType);
        }

        // GET: UserTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType userType = db.UserTypes.Find(id);
            db.UserTypes.Remove(userType);
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
