using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserLoginId { get; set; }

        public string UserPassword { get; set; }

        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }

        public bool Status { get; set; }
    }
}
