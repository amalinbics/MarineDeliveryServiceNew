using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MarineRegion
    {
        public int MarineRegionID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public int ClientID { get; set; }
    }
}
