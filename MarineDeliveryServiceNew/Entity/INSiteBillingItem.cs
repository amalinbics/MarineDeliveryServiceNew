using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteBillingItem
    {
        public int SiteID { get; set; }
        public int BillingItemID { get; set; }
        public char? Active { get; set; }
        public int? BillingItemGLCodeID { get; set; }
        public int? ProdTermsGroupID { get; set; }
        public int ClientID { get; set; }
        public char ActiveMarneDelvApp { get; set; }
    }
}
