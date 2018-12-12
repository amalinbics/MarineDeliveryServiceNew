using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankChart
    {
        public int TankChartID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public string LMeasure { get; set; }
        public string VMeasure { get; set; }
        public char Active { get; set; }
        public int VolumeUOM { get; set; }
        public int LinearUOM { get; set; }
        public int Denominator { get; set; }
        public string LastModifiedDtTm { get; set; }
        public int ClientID { get; set; }
    }
}
