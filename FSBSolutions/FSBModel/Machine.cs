using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Machine
    {
        public int MachineId { get; set; }

        public string MachineName { get; set; }

        public bool Status { get; set; }

        public IList<Module> Modules { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

    }
}
