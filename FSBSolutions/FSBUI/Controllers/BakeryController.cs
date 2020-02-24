using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSBModel;
using FSBUI.Models;
using FSBUI.ViewModels;

namespace FSBUI.Controllers
{
    public class BakeryController : Controller
    {
        // GET: Bakery

        private FSBDBContext db = new FSBDBContext();

        public ActionResult Index()
        {
            ViewBag.LineId = Session["lineid"];
            ViewBag.UserTypeId = Session["usertypeid"];
            ViewBag.UserId = Session["userid"];

            //ViewBag.productid = new SelectList(db.Products.Where(x=>x.LineId==), "LineId", "LineName");


            return View();
        }
    }
}