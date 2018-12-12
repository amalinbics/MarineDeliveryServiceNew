using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class VehicleSubCompartments
    {
        public int SubCompartmentID { get; set; }
        public int CompartmentID { get; set; }
        public char ReadingSide { get; set; }
        public int? TankChartID { get; set; }
        public int ClientID { get; set; }
    }
}
