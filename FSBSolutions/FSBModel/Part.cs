using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Part
    {
        public int PartId { get; set; }

        public string PartName { get; set; }

        public bool Status { get; set; }

        public int ComponentId { get; set; }

        public virtual Component Component { get; set; }
    }
}
