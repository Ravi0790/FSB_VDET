using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
            ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName");

            return View();
        }

        [HttpPost]
        public JsonResult Index(DailyProduction objdailyproduct)
        {

            if (ModelState.IsValid)
            {
               string [] datepart= GetCalendarYearData(objdailyproduct.PDate);
                objdailyproduct.DpDay = datepart[0];
                objdailyproduct.DpMonth = datepart[1];
                objdailyproduct.DpYear = datepart[2];
                objdailyproduct.DpWeek = datepart[3];
                objdailyproduct.DpQuarter = datepart[4];
                objdailyproduct.CDate = DateTime.Now;
                
                db.DailyProductions.Add(objdailyproduct);
                db.SaveChanges();
            }

            //return Content("success");
            //return "succes";
            return Json(objdailyproduct, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Edit(DailyProduction dprod)
        {

                DateTime sdate = dprod.CDate;
                DateTime edate = dprod.CDate.AddDays(1);

                List<DailyProduction> dailyprod = db.DailyProductions
                .Where(x => x.CDate >= sdate && x.CDate <= edate)
                .OrderByDescending(x => x.CDate).ToList();
               return Json(dailyprod, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult EditEmp(DailyProduction objdaily)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] datepart = GetCalendarYearData(objdaily.PDate);
                    objdaily.DpDay = datepart[0];
                    objdaily.DpMonth = datepart[1];
                    objdaily.DpYear = datepart[2];
                    objdaily.DpWeek = datepart[3];
                    objdaily.DpQuarter = datepart[4];
                    objdaily.CDate = DateTime.Now;
                    
                    db.Entry(objdaily).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return Json(objdaily, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) { throw ex; }
            
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