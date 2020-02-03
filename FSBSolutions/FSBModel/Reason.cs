using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Reason
    {
        public int ReasonId { get; set; }

        public string ReasonName { get; set; }

        public bool Status { get; set; }

        public int VerlustartId { get; set; }

        public virtual Verlustart Verlustart { get; set; }
    }
}
