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

        FSBDBContext db = new FSBDBContext();


        [Authorize]
        [Route("Order/Pending",Name ="orderpending")]
        public ActionResult PendingOrders()
        {
            OrderInformation objinfo = new OrderInformation();

            var bakerystatus = 0;
            objinfo = objinfo.GetPendingOrderDetails(Convert.ToInt32(Session["lineid"]));//get the values form order detail and order info
            var usertypeid = Convert.ToInt16(Session["usertypeid"]);

            //Setting the usertype name
            ViewBag.UserTypeName = db.UserTypes.SingleOrDefault(x => x.UserTypeId == usertypeid).UserTypeName;

            if (objinfo.OrderDetails.Count > 0) //if there are orders with finalstatus=0
            {
                
                IList<OrderInfo> orderinfobakery = objinfo.OrderInfos.Where(x => x.UserType.UserTypeName.ToLower() == "bakery").ToList();

                if (usertypeid == 1) //bakery login
                {
                    foreach (var item in orderinfobakery)
                    {
                        if (item.OrderStatus == 0) //check if there is any order with bakery orderstatus=0
                        {
                            bakerystatus++;
                        }
                    }

                    if (bakerystatus > 0) //if yes go to pending page
                    {
                        return View("Pending", objinfo);
                    }
                    else //if there is no order with bakery orderstatus=0
                    {
                        return RedirectToAction("index", "bakery"); //go to bakery page
                    }
                }
                else //if pakage user login
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