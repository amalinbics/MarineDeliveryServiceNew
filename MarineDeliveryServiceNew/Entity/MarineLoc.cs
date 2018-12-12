using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MarineLoc
    {
        public int MarineLocID { get; set; }
        public string CompanyID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public int? LocTypeID { get; set; }
        public char DisplayFlag { get; set; }
        public int? RegionID { get; set; }
        public int? FrtZoneID { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? TaxProfileID { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? CountyID { get; set; }
        public int? CityID { get; set; }
        public string LastModifiedDtTm { get; set; }
        public int ClientID { get; set; }
        public string DefLocDescr { get; set; }
         

    }
}
