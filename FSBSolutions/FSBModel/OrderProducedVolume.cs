using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class OrderProducedVolume
    {
        [Key]
        public int ProducedVolumeId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderDetail OrderDetail { get; set; }

        public string TimeSlot { get; set; }

        public int Dollies { get; set; }

        public int Korbe { get; set; }

        public int Pieces { get; set; }

        public int GeplanteMenge { get; set; }

        public int Efficiency { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
