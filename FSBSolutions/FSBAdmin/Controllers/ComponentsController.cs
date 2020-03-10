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
    public class ComponentsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Components
        public ActionResult Index()
        {
            var components = db.Components.Include(c => c.Module).Include(m => m.Module.Machine).Include(m => m.Module.Machine.Location).Include(p => p.Module.Machine.Location.Line).Include(p => p.Module.Machine.Location.UserType).Include(u => u.Module.Machine.Location.UserType.Plant).Include(u => u.Module.Machine.Location.UserType.Plant.Company).Include(u => u.Module.Machine.Location.UserType.Plant.Company.Country);
            return View(components.ToList());
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // GET: Components/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "ComponentId,ComponentName,ModuleId,Status")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Components.Add(component);
                db.SaveChanges();
                //return RedirectToAction("Index");
                
            }

            //ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", component.ModuleId);
            //return View(component);

            return Json("true", JsonRequestBehavior.AllowGet);
        }

        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Include(c => c.Module).Include(m => m.Module.Machine).Include(m => m.Module.Machine.Location).Include(p => p.Module.Machine.Location.Line).Include(p => p.Module.Machine.Location.UserType).Include(u => u.Module.Machine.Location.UserType.Plant).Include(u => u.Module.Machine.Location.UserType.Plant.Company).Include(u => u.Module.Machine.Location.UserType.Plant.Company.Country).SingleOrDefault(x => x.ComponentId == id);
            if (component == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", component.ModuleId);
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComponentId,ComponentName,ModuleId,Status")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ModuleId = new SelectList(db.Modules, "ModuleId", "ModuleName", component.ModuleId);
            return View(component);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Include(c => c.Module).Include(m => m.Module.Machine).Include(m => m.Module.Machine.Location).Include(p => p.Module.Machine.Location.Line).Include(p => p.Module.Machine.Location.UserType).Include(u => u.Module.Machine.Location.UserType.Plant).Include(u => u.Module.Machine.Location.UserType.Plant.Company).Include(u => u.Module.Machine.Location.UserType.Plant.Company.Country).SingleOrDefault(x => x.ComponentId == id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Components.Find(id);
            db.Components.Remove(component);
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
