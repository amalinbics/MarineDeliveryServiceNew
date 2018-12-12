using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDoc
    {
        public int SysTrxNo { get; set; }
        public int SO { get; set; }
        public string CompanyID { get; set; }
        public DateTime? DtTm { get; set; }
        public DateTime? PrintDtTm { get; set; }
        public DateTime? ShipDtTm { get; set; }
        public char DocType { get; set; }
        public string DocNo { get; set; }
        public int? CarrierID { get; set; }
        public int? VehicleID { get; set; }
        //public int? DriverID { get; set; }
        public string UserID { get; set; }
        public string BOLNo { get; set; }
        public char Status { get; set; }
        public int? FrtInID { get; set; }
        public int? OrderStatusID { get; set; }
        public string SessionNo { get; set; }
        public char ManualLinkCreate { get; set; }
        public string DiversionState { get; set; }
        public int? DiversionShipToID { get; set; }
        public string CustomerID { get; set; }
        public string SignatureImage { get; set; }
        public DateTime? SignatureDateTime { get; set; }
        public char? SignatureStatus { get; set; }
        public string BOLImage { get; set; }
        public string DeliveryImage { get; set; }
        public string LoadNo { get; set; }
    }
}
