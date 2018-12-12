using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankChartDetail
    {
        public int TankChartID { get; set; }
        public decimal Depth { get; set; }
        public int DepthFraction { get; set; }
        public decimal DepthExtFraction { get; set; }
        public decimal Volume { get; set; }
        public int ClientID { get; set; }
        public int DepthFeet { get; set; }
    }


}
