using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class UOM
    {
        public int UOMID { get; set; }
        public string Code { get; set; }
        public string LongDescr { get; set; }
        public char? Base { get; set; }
        public char? Volume { get; set; }
        public decimal? ConversionFactor { get; set; }
        public int? ConversionUOMID { get; set; }
        public decimal? BaseUOMFactor { get; set; }
        public int? BaseUOMID { get; set; }
        public int? ClientID { get; set; }
        public string LastModifiedDtTm { get; set; }
        public char? UOMType { get; set; }
        public char? IsPackaged { get; set; }
    }
}
