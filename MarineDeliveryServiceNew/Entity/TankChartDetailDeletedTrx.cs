using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankChartDetailDeletedTrx
    {
        public int TankChartID { get; set; }
        public decimal Depth { get; set; }
        public int DepthFraction { get; set; }
        public int DepthFeet { get; set; }
        public string TableName { get; set; }
       
    }
}
