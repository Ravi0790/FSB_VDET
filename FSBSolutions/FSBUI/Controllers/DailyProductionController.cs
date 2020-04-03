using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FSBModel;

namespace FSBUI.Controllers
{
    public class DailyProductionController : Controller
    {
        // GET: DailyProduction

        // GET: Line Name
        private FSBDBContext db = new FSBDBContext();
        public ActionResult Index()
        {
            ViewBag.Line = new SelectList(db.Lines, "LineId", "LineName");

            return View();
        }
        
    }
}