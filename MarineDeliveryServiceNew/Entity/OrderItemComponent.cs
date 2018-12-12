using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class OrderItemComponent
    {
        public int SysTrxNo { get; set; }
        public int SysTrxLine { get; set; }
        public int ComponentNo { get; set; }
        public int MasterProdID { get; set; }
        public int? MasterSiteID { get; set; }
        public decimal Qty { get; set; }
        public decimal? UnitCost { get; set; }
        public string CustomerID { get; set; }
        public decimal? RackPrice { get; set; }
        public decimal? RackPriceKeyed { get; set; }
        public int? FromCsTankFuelHistoryID { get; set; }
        public int? ToCsTankFuelHistoryID { get; set; }
        public string ClientID { get; set; }
    }
}
