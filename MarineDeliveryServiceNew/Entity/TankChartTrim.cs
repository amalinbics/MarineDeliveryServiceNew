using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class TankChartTrim
    {
        public int TankChartTrimID { get; set; }
        public int TankChartKeelID { get; set; }
        public int TankChartID { get; set; }
        public int TrimInch { get; set; }
        public int CorrInch { get; set; }
        public int CorrFraction { get; set; }
        public decimal CorrExtFraction { get; set; }
        public char DivisionTemp { get; set; }
        public int DenominatorTemp { get; set; }
        public int ClientID { get; set; }
        public int? TrimFeet { get; set; }
        public int? CorrFeet { get; set; }
        public decimal? TrimExtFraction { get; set; }
    }
}
