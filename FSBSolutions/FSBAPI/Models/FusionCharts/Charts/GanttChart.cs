using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSBAPI.Models.FusionCharts.Charts
{
    public class GanttChart
    {

        public string type { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string dataFormat { get; set; }
        public bool creditLabel { get; set; }
        public DataSource dataSource { get; set; }
        public Chart Chart { get; set; }
        public List<Task> Tasks { get; set; }


        

        public class Process
        {
            public string label { get; set; }
            public string id { get; set; }
        }

        public class Processes
        {
            public string isbold { get; set; }
            public List<Process> process { get; set; }
        }

        public class Category2
        {
            public string start { get; set; }
            public string end { get; set; }
            public string label { get; set; }
        }

        public class Category
        {
            public List<Category2> category { get; set; }
            public string bgalpha { get; set; }
        }

        public class DataSource
        {
            public Chart chart { get; set; }
            public List<Task> Tasks { get; set; }
            public Processes processes { get; set; }
            public List<Category> categories { get; set; }
        }

        
    }
}