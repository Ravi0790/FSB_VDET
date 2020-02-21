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
    public class ProductsController : Controller
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName");
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductDesc,ProductCountry,ProductPocket,ProductSize,CutPerMinute,BakingTime,DoughWeight,BunWeight,BunPerDough,BunPerTray,BunPerDolly,Flour,Oil,Sugar,Salt,Yeast,ProductColor,ProductType,PackagingUnit,PackagingUnitColor,MasterPackUnit,TrayName,Misc1,Misc2,Misc3,Misc4,Misc5,Status,LineId,UserTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", product.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", product.UserTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x => x.ProductId == id); ;
            if (product == null)
            {
                return HttpNotFound();
            }
            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", product.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", product.UserTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductDesc,ProductCountry,ProductPocket,ProductSize,CutPerMinute,BakingTime,DoughWeight,BunWeight,BunPerDough,BunPerTray,BunPerDolly,Flour,Oil,Sugar,Salt,Yeast,ProductColor,ProductType,PackagingUnit,PackagingUnitColor,MasterPackUnit,TrayName,Misc1,Misc2,Misc3,Misc4,Misc5,Status,LineId,UserTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName", product.LineId);
            //ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "UserTypeName", product.UserTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.Line).Include(p => p.UserType).Include(u => u.UserType.Plant).Include(u => u.UserType.Plant.Company).Include(u => u.UserType.Plant.Company.Country).SingleOrDefault(x=>x.ProductId==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
