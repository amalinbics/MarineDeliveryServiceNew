using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MarineDeliveryDetails
    {
        public int SessionID { get; set; }
        public int SysTrxLine { get; set; }
        public int MasterProdID { get; set; }
        public int ShipToVesselID {get; set;}
        public int ToTankID {get; set;}
        public int UOMID { get; set; }
        public string Temperature { get; set; }
        public string SpecificGravity { get; set; }
        public string GrossQty { get; set; }
        public string NetQty { get; set; }
        public char DeliverAt {get; set;}
        public string Note { get; set; }
        public int OrderSysTrxLine { get; set; }
        public string ShipSysTrxNo { get; set; }
        public int ShipSysTrxLine {get; set;}
        public string APIRating {get; set; }
        public char Delivery {get; set;}
        public string CustomerID { get; set; }

    }
}
