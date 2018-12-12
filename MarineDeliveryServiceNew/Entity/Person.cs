using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AvailableHours { get; set; }
        public char? Employee { get; set; }
        public string Title { get; set; }
        public string AltEmail { get; set; }
        public int? ContactShiptoID { get; set; }
        public int? ContactSupplierID { get; set; }
        public int? ContactSupptID { get; set; }
        public int? ContactCarrierID { get; set; }
        public int? ContactSiteID { get; set; }
        public string LastModifiedUser { get; set; }
        public string LastModifiedDtTm { get; set; }
        public int? CollectionGroupID { get; set; }
        public int? ContactVendorID { get; set; }
        public int ClientID { get; set; }
        public int? ContactShipToVesselID { get; set; }
        public char EnabledInternationalAddress { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}
