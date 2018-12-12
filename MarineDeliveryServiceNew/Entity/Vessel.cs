using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Vessel
    {
        public int ShipToVesselID { get; set; }
        public string VesselCode { get; set; }
        public string VesselDescr { get; set; }
        public int? VesselTypeID { get; set; }
        public int? OwnershipStdAcctID { get; set; }
        public decimal? GrossTonnage { get; set; }
        public decimal? ActualCapacity { get; set; }
        public int? UOMID { get; set; }
        public string CompanyID { get; set; }
        public int ClientID { get; set; }
        public string IMONo { get; set; }
        public string Instruction { get; set; }
    }

}
