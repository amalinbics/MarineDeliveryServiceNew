using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ARShipTo
    {
        public int? ShipToId { get; set; }
        public int? StandardAcctID { get; set; }
        public string StandardAcctNo { get; set; }
        public string CustomerName { get; set; }
        public string DBAName { get; set; }
        public string CreditHold { get; set; }
        public decimal? CreditLimitAmt { get; set; }
        //public string ContactName { get; set; }
        //public string ContactEmail { get; set; }
        //public string PhoneNo { get; set; }
        public string FormattedCode { get; set; }
        public string LongDescr { get; set; }
        public string LastModifiedDtTm { get; set; }
        public string ClientID { get; set; }
        public string FormattedAddress { get; set; }
        public string PrimaryPhone{ get; set; }
    }
}
