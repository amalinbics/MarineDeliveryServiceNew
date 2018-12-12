using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class VehicleCompartments
    {
        public int CompartmentID { get; set; }
        public int VehicleID { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
        public float? Load_Rate { get; set; }
        public float? Unload_Rate { get; set; }
        public string ClientID { get; set; }
        public int? TankChartID { get; set; }

    }
}
