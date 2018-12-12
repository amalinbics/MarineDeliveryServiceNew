using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Vehicle
    {
        public int? VehicleID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public int? CarrierID { get; set; }
        public int? VehicleType { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public char? EnableSubCompartment { get; set; }
        public string LastModifiedDtTm { get; set; }
        public char? EnforceShipmentMarineApp { get; set; }
    }
}
