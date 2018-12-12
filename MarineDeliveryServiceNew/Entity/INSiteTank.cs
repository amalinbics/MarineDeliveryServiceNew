using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteTank
    {
        public int INSiteTankID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int INSiteID { get; set; }
        public string CompanyID { get; set; }
        public decimal? TankCapacity { get; set; }
        public int? TankChartID { get; set; }
        public int? TankTypeID { get; set; }
        public int? DefaultDelQty { get; set; }
        public decimal? MaxFill { get; set; }
        public decimal? SafetyLevel { get; set; }
        public decimal? MinOrderQty { get; set; }
        public decimal? PumpLevel { get; set; }
        public decimal? WaterAlarm { get; set; }
        public char? TankClass { get; set; }
        public char AboveGround { get; set; }
        public char PressureSensor { get; set; }
        public char Manifold { get; set; }
        public int? ManifoldTankID { get; set; }
        public char IsPrimary { get; set; }
        public char TankReadingBasis { get; set; }
        public int ClientID { get; set; }
        public char Active { get; set; }
        public char EnableSubCompartment { get; set; }
        public char Insulated { get; set; }
        public int? TankOperatingTemp { get; set; }
        public decimal? LinearExpansionCoeff { get; set; }
    }
}
