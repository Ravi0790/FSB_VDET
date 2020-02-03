using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class MasterDataInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string Plant { get; set; }
        public string Shift { get; set; }
        public string Line { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductSize { get; set; }
        public string ProductCountry { get; set; }
        public string CutPerMinute { get; set; }
        public float BakingTime { get; set; }
        public float DoughWeight { get; set; }
        public float BunWeight { get; set; }
        public float BunsPerTray { get; set; }
        public float BunPerDough { get; set; }
        public float Pockets { get; set; }
        public float Flour { get; set; }
        public float Oil { get; set; }
        public float Sugar { get; set; }
        public float Salt { get; set; }
        public float Yeast { get; set; }
        public string ProductType { get; set; }
        public string PackagingUnit { get; set; }
        public string PackagingUnitColor { get; set; }
        public string MasterPackUnit { get; set; }
        public string TrayName { get; set; }
        public float BunPerDolly { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftStopTime { get; set; }
        public int ShiftDuration { get; set; }
        public DateTime OrderStartTime { get; set; }
        public DateTime OrderStopTime { get; set; }
        public int OrderDuration { get; set; }
        public int PlannedQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int WasteId { get; set; }
        public DateTime MachineStartTime { get; set; }
        public DateTime MachineStopTime { get; set; }
        public int MachineDuration { get; set; }
        public DateTime CleaningStartTime { get; set; }
        public DateTime CleaningStopTime { get; set; }
        public int CleaningDuration { get; set; }
        public DateTime RepairStartTime { get; set; }
        public DateTime RepairEndTime { get; set; }
        public int RepairDuration { get; set; }
        public int WasteKg { get; set; }
        public string Efficiency { get; set; }
        public string WasteType { get; set; }
        public string WasteCategory { get; set; }
        public string Location { get; set; }
        public string Machine { get; set; }
        public string Module { get; set; }
        public string Component { get; set; }
        public string Parts { get; set; }
        public string Reason { get; set; }
        public string Comments { get; set; }
        public DateTime WasteDate { get; set; }
        public DateTime EnteredDate { get; set; }
        public string ProductionType { get; set; }
        public string PermanentEmp { get; set; }
        public string TemporaryEmp { get; set; }
        public string ExternalEmp { get; set; }
        public string ProductionStatus { get; set; }
        public string PDay { get; set; }
        public string PYear { get; set; }
        public string PQuarter { get; set; }
        public string PMonth { get; set; }
        public string PWeek { get; set; }
        public int WastePcs { get; set; }
        public int TimeLossPcs { get; set; }
        public DateTime TTStart { get; set; }
        public DateTime TTEnd { get; set; }
        public int TTDuration { get; set; }
        public float PlannedKg { get; set; }
        public float ProducedKg { get; set; }
        
        public int LeerIndexMinutes { get; set; }
        public int LeerIndexPieces { get; set; }
        public bool IsLogin { get; set; }
        public string Tray  { get; set; }

    }
}
