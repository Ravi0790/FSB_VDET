using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }        

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public IList<Plant> Plants { get; set; }

        public bool Status { get; set; }


    }
}
