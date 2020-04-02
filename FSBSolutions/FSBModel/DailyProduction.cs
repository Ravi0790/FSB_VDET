using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    class DailyProduction
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public string Line { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductCountry { get; set; }
        
    }
}
