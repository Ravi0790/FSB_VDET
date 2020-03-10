using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSBModel;
using FSBUI.Models;

namespace FSBUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {


        //public ActionResult Index()
        //{
        //    return View("Pending");
        //}


        [Authorize]
        [Route("Order/Pending",Name ="orderpending")]
        public ActionResult PendingOrders()
        {
            OrderInformation objinfo = new OrderInformation();

            var bakerystatus = 0;
            objinfo = objinfo.GetPendingOrderDetails(Convert.ToInt32(Session["lineid"]));
            var usertypeid = Convert.ToInt16(Session["usertypeid"]);

            if (objinfo.OrderDetails.Count > 0) //if there are pending orders
            {
                //return View("Pending", objinfo);
                IList<OrderInfo> orderinfobakery = objinfo.OrderInfos.Where(x => x.UserType.UserTypeName.ToLower() == "bakery").ToList();

                if (usertypeid == 1) //bakery login
                {
                    foreach (var item in orderinfobakery)
                    {
                        if (item.OrderStatus == 0)
                        {
                            bakerystatus++;
                        }
                    }

                    if (bakerystatus > 0)
                    {
                        return View("Pending", objinfo);
                    }
                    else
                    {
                        return RedirectToAction("index", "bakery");
                    }
                }
                else
                {
                    return View("Pending", objinfo);
                }
            }
            else //if there are no pending orders
            {
                

                if (usertypeid == 1) //bakery login
                {
                    return RedirectToAction("index", "bakery");
                }
                else
                {
                    return View("Pending", objinfo);
                }
            }

            
        }
    }
}