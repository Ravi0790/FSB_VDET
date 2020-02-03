using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    /***************This is Efficiency************/
    public class Verlust
    {
        public int VerlustId { get; set; }

        public string VerlustName { get; set; }

        public bool Status { get; set; }

        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }
    }
}
