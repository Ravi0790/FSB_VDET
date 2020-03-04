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
        
        public DateTime? MachineStartTime { get; set; }
        public DateTime? MachineEndTime { get; set; }
        public int MachinDurationMin { get; set; }
        public DateTime? CleaningStartTime { get; set; }
        public DateTime? CleaningEndTime { get; set; }
        public int CleaningDurationMin { get; set; }
        public DateTime? RepairStartTime { get; set; }
        public DateTime? RepairEndTime { get; set; }
        public int RepairDuration { get; set; }        
        public int Produktionsstatus { get; set; }

        [StringLength(200)]
        public string WasteType { get; set; }

        [StringLength(200)]
        public string Verlust { get; set; }

        [StringLength(200)]
        public string Verlustart { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(200)]
        public string Machine { get; set; }

        [StringLength(200)]
        public string Module { get; set; }

        [StringLength(200)]
        public string Component { get; set; }

        [StringLength(200)]
        public string Part { get; set; }

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(200)]
        public string CleanerApproverName { get; set; }

        [StringLength(200)]
        public string RepairApproverName { get; set; }

        public string comments { get; set; }
        public int WasteKg { get; set; }
        public int WastePieces { get; set; }
        public int TimelossPieces { get; set; }
        


        public DateTime CreatedDate { get; set; }              
        
        public int OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        public OrderDetail OrderDetail { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public string ProblemReason { get; set; }
        public string ActionTaken { get; set; }
        public string PreventiveAction { get; set; }

    }
}
