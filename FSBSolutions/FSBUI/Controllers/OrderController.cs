using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSBModel;
using FSBUI.Models;

namespace FSBUI.Controllers
{
    public class OrderController : Controller
    {

        
        //public ActionResult Index()
        //{
        //    return View("Pending");
        //}


        
        [Route("Order/Pending",Name ="orderpending")]
        public ActionResult PendingOrders()
        {
            OrderInformation objinfo = new OrderInformation();

            objinfo = objinfo.GetPendingOrderDetails(Convert.ToInt32(Session["lineid"]));

            return View("Pending", objinfo);
        }
    }
}