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
        public OrderDetail OrderDetail { get; set; }

        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int OrderStatus { get; set; }

        public DateTime LoggedinTime { get; set; }

        public DateTime UpdatedLoggedinTime { get; set; }

    }


    
}
