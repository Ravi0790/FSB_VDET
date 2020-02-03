using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    /***********This is WasteCategory****************/
    public class Verlustart
    {
        public int VerlustartId { get; set; }

        public string VerlustartName { get; set; }

        public bool Status { get; set; }

        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }

        public IList<Reason> Reasons { get; set; }
    }
}
