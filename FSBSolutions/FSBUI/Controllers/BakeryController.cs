using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FSBModel;
using FSBUI.Hubs;
using FSBUI.Models;
using FSBUI.ViewModels;
using System.Web.Security;

namespace FSBUI.Controllers
{
    [Authorize]
    public class BakeryController : Controller
    {
        // GET: Bakery

        private FSBDBContext db = new FSBDBContext();

        public ActionResult Index()
        {
            if (Session["lineid"] != null)
            {
                ViewBag.LineId = Session["lineid"];
                ViewBag.UserTypeId = Session["usertypeid"];
                ViewBag.UserId = Session["userid"];
                ViewBag.PlantId = Session["plantid"];
                return View();
            }

            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("index", "login");
            }

            //ViewBag.productid = new SelectList(db.Products.Where(x=>x.LineId==), "LineId", "LineName");


            
        }

        [HttpGet]
        [Route("bakery/volume/{orderid}")]
        public ActionResult GetVolumeInfo(int orderid)
        {
            //return Json(db.Customers.Where(x=>x.Id==orderid).ToList(),JsonRequestBehavior.AllowGet);
            return Content("hello");
        }


        [HttpGet]
        [Route("bakery/packaging/{orderid}")]
        public void HitVolumeHub(string orderid)
        {
            //return Json(db.Customers.ToList());

            CusHub.ShowVoume(orderid);
        }


        [HttpPost]        
        [ActionName("Index")]
        public ActionResult GetOrderIdFromPending(int orderid)
        {

            if (Session["lineid"] != null)
            {
                ViewBag.OrderId = orderid;
                ViewBag.LineId = Session["lineid"];
                ViewBag.UserTypeId = Session["usertypeid"];
                ViewBag.UserId = Session["userid"];
                ViewBag.PlantId = Session["plantid"];
                return View("index");
            }

            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("index", "login");

            }
        }
    }
}