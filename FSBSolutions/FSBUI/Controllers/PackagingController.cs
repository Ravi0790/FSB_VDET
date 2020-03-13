using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FSBUI.Controllers
{
    public class PackagingController : Controller
    {
        // GET: Package
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