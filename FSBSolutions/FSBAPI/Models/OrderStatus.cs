using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSBAPI.Models
{
    public class OrderStatus
    {
        public int OrderId { get; set; }

        public int LineId { get; set; }

        public int UserTypeId { get; set; }

        public int UserId { get; set; }

        public int PremanentEmp { get; set; }

        public int TemporaryEmp { get; set; }

        public int ExternalEmp { get; set; }

        public int Status { get; set; }
    }
}