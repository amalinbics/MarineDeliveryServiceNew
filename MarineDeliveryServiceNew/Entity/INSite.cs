using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSite
    {
        public int SiteID { get; set; }
        public string Code { get; set; }
        public string LongDescr { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedLineAddress { get; set; }
        public string CompanyID  { get; set; }
        public string ClientID  { get; set; }
        public DateTime? LastModifiedDtTm { get; set; }
        public char? EnableElectronicDOI { get; set; }
        public int EnableMarineDelivery { get; set; }
        public char? InSiteType { get; set; }
        public char? SiteType { get; set; }
        public char Inactive { get; set; }

    }
}
