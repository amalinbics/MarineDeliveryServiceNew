using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankType
    {
        public int TankTypeID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public Double? TankCapacity { get; set; }
        public Double? UsableTankCapacity { get; set; }
        public string ClientID { get; set; }

    }
}
