using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDocItemVessel
    {        
        public int SysTrxNo { get; set; }
        public int SysTrxLine { get; set; }
        public int MarineDeliverSessionID { get; set; }
        public int MasterProdID { get; set; }
        public int? ShipToVesselID { get; set; }
        public decimal? Qty { get; set; }
        public int? OrderSysTrxNo { get; set; }
        public int? OrderSysTrxLine { get; set; }
        public int? MarineLocID { get; set; }
        public int? UOMID { get; set; }
        public int? PersonID { get; set; }
        public int? CustomerID { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
