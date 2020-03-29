using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSBAPI.Models.FusionCharts
{
    public class Chart
    {
        public string theme { get; set; }
        public string dateformat { get; set; }
        public int showTaskLabels { get; set; }
    }
}