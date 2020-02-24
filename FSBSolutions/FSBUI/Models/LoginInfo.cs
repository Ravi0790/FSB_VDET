using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSBModel;
using System.Data.Entity;


namespace FSBUI.Models
{
    public class LoginInfo
    {
        private FSBDBContext db = new FSBDBContext();

        public User GetLoginInfo(User userinfo)
        {
            User objuser=db.Users.Include(ut=>ut.UserType).SingleOrDefault(x => x.UserLoginId == userinfo.UserLoginId && x.UserPassword == userinfo.UserPassword && x.Status == true);

            return objuser;

        }
    }
}