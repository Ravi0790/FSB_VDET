using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FSBModel;
using FSBUI.Hubs;

namespace FSBUI.Controllers
{
    public class PackagingController : Controller
    {
        // GET: Package
        FSBDBContext db = new FSBDBContext();
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

                /**********Check if packagin user is added in the userinfoes*******/

                var orderstatus = db.OrderInfos.SingleOrDefault(x => x.OrderId == orderid && x.UserTypeId == 2);

                if (orderstatus == null)
                {
                    OrderInfo objorderinfo = new OrderInfo()
                    {
                        OrderId = orderid,
                        UserTypeId = 2,
                        UserId = Convert.ToInt32(Session["userid"]),
                        LoggedinTime = DateTime.Now
                    };

                    db.OrderInfos.Add(objorderinfo);
                    db.SaveChanges();
                }
                return View("index");


            }

            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("index", "login");

            }
        }


        [HttpGet]
        [Route("packaging/bakerystop/{orderid}")]
        public void BakeryStopAlert(string orderid)
        {
            //return Json(db.Customers.ToList());

            CusHub.CheckTimer(orderid);
        }
    }
}