using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public bool Status { get; set; }

        public IList<Component> Components { get; set; }

        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; }
    }
}
