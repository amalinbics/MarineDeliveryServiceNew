using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDocItemComp
    {
        public int SysTrxNo { get; set; }
        public int SysTrxLine { get; set; }
        public int ComponentNo { get; set; }
        public int MasterProdID { get; set; }
        public int MasterSiteID { get; set; }
        public decimal? GrossQty { get; set; }
        public decimal? NetQty { get; set; }
        public int? BOLItemID { get; set; }
        public int? FrtRateID { get; set; }
        public decimal? BlendPct { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? SpecificGravity { get; set; }
        public string OvrBOLNo { get; set; }
        public string OvrBOLDate { get; set; }
        public int? OvrCarrier { get; set; }
        public int? OvrVehicle { get; set; }
        public int? OvrDriver { get; set; }
        public char PayOn { get; set; }
        public decimal? FrtAmtKeyed { get; set; }
        public decimal? DDPCT { get; set; }
        public decimal? UnitCostKeyed { get; set; }
        public int? CSTankFuelHistoryID { get; set; }
        public int? BOLLineNo { get; set; }
        public string OvrDiversionState { get; set; }
        public char? ManualLinkToOrder { get; set; }
        public int? OvrDiversionShipToID { get; set; }
        public int? FromCSTankFuelHistoryID { get; set; }
        public decimal? OrgShipCompGrossQty { get; set; }
        public string CustomerID { get; set; }
        public int? FromCSMeterFuelHistoryID { get; set; }
        public int? ToCSTankID { get; set; }
        public int? FromCSTankID { get; set; }
        public int? FromCSMeterID { get; set; }
        public int? EBOL_ID { get; set; }
        public int? EBOLItemNumber { get; set; }
        public string ShippingNotes { get; set; }
        public int? ShipTrfSysTrxNo { get; set; }
        public int? ShipTrfSysLineNo { get; set; }
    }
}
