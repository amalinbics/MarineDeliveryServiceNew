using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDocItem
    {
        public int SysTrxNo { get; set; }
        public int SysTrxLine { get; set; }
        public int MasterProdID { get; set; }
        public int MasterSiteID { get; set; }
        public int? OrderSysTrxNo { get; set; }
        public int? OrderSysTrxLine { get; set; }
        public int? InvoiceSysTrxNo { get; set; }
        public int? InvoiceSysTrxLine { get; set; }

        public DateTime? DtTm { get; set; }
        public string UserID { get; set; }
        public decimal? ShipQty { get; set; }
        public DateTime? DelivDtTm { get; set; }
        public decimal? DelivQty { get; set; }
        public string DiscDt { get; set; }
        public string DueDt1 { get; set; }
        public string DueDt2 { get; set; }
        public string DueDt3 { get; set; }
        public int? TermsID { get; set; }
        public char? Invoice { get; set; }
        public char? Invoiced { get; set; }
        public char Status { get; set; }
        public int? ProdAggrGrpID { get; set; }
        public decimal? OrderQty { get; set; }
        public char? SellAt { get; set; }
        public decimal? ShipNetQty { get; set; }
        public string CustomerID { get; set; }
        public string BOLQtyVarianceReason { get; set; }
        public string DeliveryQtyVarianceReason { get; set; }
        public char? IsNotShipped { get; set; }
        public string IsNotShippedReason { get; set; }
        public char? IsNotDelivered { get; set; }
        public string IsNotDeliveredReason { get; set; }
        public int? ARShipToTankID { get; set; }
        public string DeliveryNotes { get; set; }
        public int? DeliverTrfSysTrxNo { get; set; }
        public int? DeliverTrfSysLineNo { get; set; }
        public int? MarineSessionID { get; set; }
        public int? VesselID { get; set; }
        public string OrderItemNotes { get; set; }
    }
}
