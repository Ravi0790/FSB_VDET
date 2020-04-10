using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSBModel;

namespace FSBUI.Controllers
{
    public class ContainerWasteController : Controller
    {
        // GET: ContainerWaste
        private FSBDBContext db = new FSBDBContext();
        public ActionResult Index()
        {
            ViewBag.WasteDetail = new SelectList(db.WasteTypes, "WasteTypeName", "WasteTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContainerWaste objcontainerwaste)
        {
            if (ModelState.IsValid)
            {
                string[] datepart = GetCalendarYearData(objcontainerwaste.Datum);
                objcontainerwaste.PDay = datepart[0];
                objcontainerwaste.PMonth = datepart[1];
                objcontainerwaste.PYear = datepart[2];
                objcontainerwaste.Week = datepart[3];
                objcontainerwaste.PQuarter = datepart[4];
                objcontainerwaste.CrtdDate = DateTime.Now;
                db.ContainerWastes.Add(objcontainerwaste);
                db.SaveChanges();
            }
            return Json(objcontainerwaste, JsonRequestBehavior.AllowGet);
        }
        public string[] GetCalendarYearData(DateTime cdate)
        {
            string[] calenderdata = new string[5];

            calenderdata[0] = cdate.ToString("ddd");
            calenderdata[1] = cdate.ToString("yyyy MM");
            calenderdata[2] = "CY " + cdate.ToString("yyyy");
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;

            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            calenderdata[3] = "W " + Convert.ToString(myCal.GetWeekOfYear(cdate, myCWR, myFirstDOW)) + " " + cdate.ToString("yyyy");


            //calenderdata[4] = "Q" + GetQuarter(cdate) + " " + cdate.ToString("yyyy");
            calenderdata[4] = "Q2335";
            return calenderdata;
        }
    }
}