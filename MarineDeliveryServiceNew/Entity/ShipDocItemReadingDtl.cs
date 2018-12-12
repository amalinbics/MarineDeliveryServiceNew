using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDocItemReadingDtl
    {
        public int DtlID { get; set; }
        public int ReadingID { get; set; }
        public int? InSiteTankID { get; set; }
        public int? CompartmentID { get; set; }
        public int? PortFuelDepth_B { get; set; }
        public int? PortFuelDepthNumerator_B { get; set; }
        public int? MiddleFuelDepth_B { get; set; }
        public int? MiddleFuelDepthNumerator_B { get; set; }
        public int? SBoardFuelDepth_B { get; set; }
        public int? SBoardFuelDepthNumerator_B { get; set; }
        public int? PortFuelDepth_A { get; set; }
        public int? PortFuelDepthNumerator_A { get; set; }
        public int? MiddleFuelDepth_A { get; set; }
        public int? MiddleFuelDepthNumerator_A { get; set; }
        public int? SBoardFuelDepth_a { get; set; }
        public int? SBoardFuelDepthNumerator_A { get; set; }
        public int? Denominator { get; set; }
        public decimal? MeterReading_B { get; set; }
        public decimal? MeterReading_A { get; set; }
        public string CustomerID { get; set; }
        public int? PortFeet_B { get; set; }
        public int? MiddleFeet_B { get; set; }
        public int? SBoardFeet_B { get; set; }
        public int? PortFeet_A { get; set; }
        public int? MiddleFeet_A { get; set; }
        public int? SBoardFeet_A { get; set; }
    }
}
