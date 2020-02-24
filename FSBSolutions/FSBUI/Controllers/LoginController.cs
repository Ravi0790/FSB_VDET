﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            User objuser = objlogin.GetLoginInfo(userinfo.User);

            if (objuser!=null)
            {
                Session["lineid"] = userinfo.LineId;
                Session["usertypeid"] = objuser.UserType.UserTypeId;
                Session["userid"] = objuser.UserId;


                return RedirectToAction(objuser.UserType.LoginActionURL, objuser.UserType.LoginControllerURL);
            }
            else
            {

                ViewBag.LineId = new SelectList(db.Lines, "LineId", "LineName",userinfo.LineId);
                ModelState.AddModelError("", "Ihr Benutzername oder Passwort ist Falsch");
            }
            //}




            return View(userinfo);
        }


        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}