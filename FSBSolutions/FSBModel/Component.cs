using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Component
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public bool Status { get; set; }
        public IList<Part> Parts { get; set; }
        public int ModuleId { get; set; }
        public virtual Machine Module { get; set; }
    }
}
