using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class WasteDetail
    {
        [Key]
        public int WasteId { get; set; }
        
        public DateTime MachineStartTime { get; set; }
        public DateTime MachineEndTime { get; set; }
        public int MachinDurationMin { get; set; }
        public DateTime CleaningStartTime { get; set; }
        public DateTime CleaningEndTime { get; set; }
        public int CleaningDurationMin { get; set; }
        public DateTime RepairStartTime { get; set; }
        public DateTime RepairEndTime { get; set; }
        public int RepairDuration { get; set; }
        public int WasteTypeId { get; set; }
        public bool Produktionsstatus { get; set; }
        public int VerlustId { get; set; }
        public int VerlustartId { get; set; }
        public int LocationId { get; set; }
        public int MachineId { get; set; }
        public int ModuleId { get; set; }
        public int ComponentId { get; set; }
        public int PartId { get; set; }
        public int ReasonId { get; set; }
        public string comments { get; set; }
        public int WasteKg { get; set; }
        public int WastePieces { get; set; }
        public int TimelossPieces { get; set; }
        public int CleaningApproverId { get; set; }
        public int RepairingApporverId { get; set; }
        public DateTime CreatedDate { get; set; }
               
        
        public int OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        public OrderDetail OrderDetail { get; set; }

    }
}
