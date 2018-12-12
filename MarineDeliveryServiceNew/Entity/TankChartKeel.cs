using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankChartKeel
    {
        public int TankChartKeelID { get; set; }
        public int TankChartID { get; set; }
        public char KeelTo { get; set; }
        public decimal KeelDegree { get; set; }
        public int ClientID { get; set; }
    }
}
