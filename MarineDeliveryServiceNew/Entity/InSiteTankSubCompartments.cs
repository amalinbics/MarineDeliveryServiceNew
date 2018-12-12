using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class InSiteTankSubCompartments
    {
        public int SubCompartmentID { get; set; }
        public int INSiteTankID { get; set; }
        public char ReadingSide { get; set; }
        public int TankChartID { get; set; }
        public int ClientID { get; set; }
        public string CompartmentCode { get; set; }
    }
}
