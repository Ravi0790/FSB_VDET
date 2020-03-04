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
    public class ModulesController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Modules
        public ActionResult Index()
        {
            var modules = db.Modules.Include(m => m.Machine).Include(m => m.Machine.Location).Include(p => p.Machine.Location.Line).Include(p => p.Machine.Location.UserType).Include(u => u.Machine.Location.UserType.Plant).Include(u => u.Machine.Location.UserType.Plant.Company).Include(u => u.Machine.Location.UserType.Plant.Company.Country); 
            return View(modules.ToList());


        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,ModuleName,MachineId,Status")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "MachineName", module.MachineId);
            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Include(m => m.Machine).Include(m => m.Machine.Location).Include(p => p.Machine.Location.Line).Include(p => p.Machine.Location.UserType).Include(u => u.Machine.Location.UserType.Plant).Include(u => u.Machine.Location.UserType.Plant.Company).Include(u => u.Machine.Location.UserType.Plant.Company.Country).SingleOrDefault(x => x.ModuleId == id);
            if (module == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "MachineName", module.MachineId);
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleId,ModuleName,MachineId,Status")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "MachineName", module.MachineId);
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = db.Modules.Include(m => m.Machine).Include(m => m.Machine.Location).Include(p => p.Machine.Location.Line).Include(p => p.Machine.Location.UserType).Include(u => u.Machine.Location.UserType.Plant).Include(u => u.Machine.Location.UserType.Plant.Company).Include(u => u.Machine.Location.UserType.Plant.Company.Country).SingleOrDefault(x => x.ModuleId == id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
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
