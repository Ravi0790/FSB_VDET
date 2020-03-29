using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FSBModel;
using FSBUI.Models;
using FSBUI.ViewModels;

namespace FSBUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private FSBDBContext db = new FSBDBContext();
        public ActionResult Index()
        {
            ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName");

            return View();
        }

        [HttpPost]        
        public ActionResult Index([Bind(Exclude = "UserName")] UserLineViewModel userinfo)
        {
            //if (ModelState.IsValid)
            //{
            LoginInfo objlogin = new LoginInfo();
            OrderInformation objorderinfo = new OrderInformation();

            User objuser = objlogin.GetLoginInfo(userinfo.User);//check if userid and password in correct

            if (objuser!=null)//if yes
            {
                Session["lineid"] = userinfo.LineId;
                Session["usertypeid"] = objuser.UserType.UserTypeId;
                Session["userid"] = objuser.UserId;
                Session["plantid"] = objuser.UserType.Plant.PlantId;
                FormsAuthentication.SetAuthCookie(objuser.UserName, false);

                //check if there is any order with the line selected and finalstatus=0
                IList<OrderDetail> orderdetail = objorderinfo.CheckOrderPending(userinfo.LineId);
                var usertypeid = Convert.ToString(Session["usertypeid"]);

                if (orderdetail.Count > 0) //if order is there
                {                    
                    
                  return RedirectToRoute("orderpending");                           
                }
                else //if order is not created
                {
                    if (usertypeid != "2") //if not packaging user
                    {
                        return RedirectToAction(objuser.UserType.LoginActionURL, objuser.UserType.LoginControllerURL);
                    }
                    else //if packaging user
                    {
                        return RedirectToRoute("orderpending");
                    }
                }
            }
            else //if userid or password is wrong
            {

                ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName",userinfo.LineId);
                ModelState.AddModelError("", "Ihr Benutzername oder Passwort ist Falsch");
            }
            //}




            return View(userinfo);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "login");
        }
    }
}