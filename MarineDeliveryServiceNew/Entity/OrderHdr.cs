using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class OrderHdr
    {
        public int SysTrxNo { get; set; }
        public string CompanyID { get; set; }
        public string OrderNo { get; set; }
        public string PONo { get; set; }
        public int? DefCarrierID { get; set; }
        public DateTime  OrderDtTm { get; set; }
        public DateTime DefRequestedDtTm { get; set; }
        public DateTime DefPromisedDtTm { get; set; }
        public DateTime DtTm { get; set; }
        public string UserID { get; set; }
        public char Status { get; set; }
        public int? ToSiteID { get; set; }
        public char OrderType { get; set; }
        public string LoadNo { get; set; }
        public DateTime LastStatusDate { get; set; }
        public char InternalTransferOrder { get; set; }
        public string CustomerID { get; set; }
        public int? ShipToVesselID { get; set; }
        public int? AuxiliaryVesselID { get; set; }
        public int? AuxiliaryVesselCount { get; set; }
        public int? MarineLocID { get; set; }
        public string MarineLocDescr { get; set; }
        public char FreightIN { get; set; }
        public char FreightOUT { get; set; }
        public int? MarineSessionID { get; set; }
        //public int? DefDriverID { get; set; }
        public int? DefVehicleID { get; set; }
        public string ClientID { get; set; }
        public string ReceivingContact { get; set; }
        public int? ReceivingContactID { get; set; }
        public string LastModifiedUser { get; set; }
        public int OrderStatusID { get; set; }
    }
}
