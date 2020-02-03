using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class WasteType
    {
        public int WasteTypeId { get; set; }

        public string WasteTypeName { get; set; }

        public bool Status { get; set; }

        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }
    }
}
