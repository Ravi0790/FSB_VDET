using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Line
    {
        public int LineId { get; set; }

        public string LineName { get; set; }

        public int PlantId { get; set; }

        public virtual Plant Plant { get; set; }

        public bool Status { get; set; }
    }
}
