using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteBillingItemDeletedTrx
    {
        public int SiteID { get; set; }
        public int BillingItemID { get; set; }
        public string TableName { get; set; }
    }
}
