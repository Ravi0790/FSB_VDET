using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSBAPI.Models.FusionCharts
{
    public class dataSource
    {
        public chart chart { get; set; }
        public gtasks tasks { get; set; }
        public processes processes { get; set; }
        public categories[] categories { get; set; }

    }
}