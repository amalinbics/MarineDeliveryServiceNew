using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MarineLocType
    {
        public int LocTypeID { get; set; }
        public string LocType { get; set; }
        public string Descr { get; set; }
        public int ClientID { get; set; }
    }
}
