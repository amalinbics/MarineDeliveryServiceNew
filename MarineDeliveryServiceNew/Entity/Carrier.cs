using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Carrier
    {
        public int? CarrierID { get; set; }
        public int? VendorID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
    }
}
