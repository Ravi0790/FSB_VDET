using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public bool Status { get; set; }

        public IList<Machine> Machines { get; set; }
        public int LineId { get; set; }

        public virtual Line Line { get; set; }

        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
