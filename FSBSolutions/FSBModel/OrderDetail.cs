using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public string SAPReferenceNumber { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime OrderStartTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public int? OrderDurationMin { get; set; }

        public int PlannedQuantity { get; set; }
        public int? ProducedQuantity { get; set; }
        public int PremanentEmp { get; set; }
        public int TemporaryEmp { get; set; }
        public int ExternalEmp { get; set; }
        public DateTime? TeigteileruhrStartTime { get; set; }
        public DateTime? TeigteileruhrEndTime { get; set; }
        public int? TeigteileruhrDurationMin { get; set; }
        public float? PlannedKg { get; set; }
        public float? ProducedKg { get; set; }
        public int? BakeryTotalWaste { get; set; }
        public int? PackageTotalWaste { get; set; }
        public int? TotalDowntime { get; set; }
        public int? StillStandMin { get; set; }
        public int? StillStandPieces { get; set; }
        public int? TotalWasteKg { get; set; }
        public int? TotalWastePieces { get; set; }
        public int? TotalProduction { get; set; }
        public int? Sollmengen { get; set; }
        public int? LeerIndexMinute { get; set; }
        public int? LeerIndexPieces { get; set; }
        public DateTime CreatedDate { get; set; }

        public IList<WasteDetail> WasteDetails { get; set; }

    }
}
