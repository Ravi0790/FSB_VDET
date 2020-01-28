using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Plant
    {
        public int Id { get; set; }
        
        public string PlantName { get; set; }
        
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public IList<Shift> Shifts { get; set; }

        public IList<Line> Lines { get; set; }

        public IList<UserType> UserTypes { get; set; }

        public bool Status { get; set; }
    }
}
