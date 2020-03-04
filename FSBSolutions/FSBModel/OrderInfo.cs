using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class OrderInfo
    {
        public int OrderInfoId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderDetail OrderDetail { get; set; }

        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int OrderStatus { get; set; }

        public DateTime LoggedinTime { get; set; }

        

    }


    
}
