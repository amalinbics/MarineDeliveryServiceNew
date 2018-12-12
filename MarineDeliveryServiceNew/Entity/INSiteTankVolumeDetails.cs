using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteTankVolumeDetails
    {
        public int DtlID { get; set; }
        public int INSiteTankVolumeID { get; set; }
        public int INSiteTankID { get; set; }
        public int? CompartmentID { get; set; }
        public int? PortFeet { get; set; }
        public int? PortFuelDepth { get; set; }
        public int? PortFuelDepthNumerator { get; set; }
        public int? MiddleFeet { get; set; }
        public int? MiddleFuelDepth { get; set; }
        public int? MiddleFuelDepthNumerator { get; set; }
        public int? SBoardFeet { get; set; }
        public int? SBoardFuelDepth { get; set; }
        public int? SBoardFuelDepthNumerator { get; set; }
        public int? Denominator { get; set; }
        public int? MeterReading { get; set; }
        public int ClientID { get; set; }        
    }
}
