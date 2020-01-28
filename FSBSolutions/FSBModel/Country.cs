using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Country
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }        

        public IList<Company> Companies { get; set; }

        public bool Status { get; set; }
    }
}
