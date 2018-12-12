using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Products
    {
        public string ClientID { get; set; }
        public int? MasterProdID { get; set; }
        public int? ProdID { get; set; }
        public string CompanyID { get; set; }
        public char? MasterProdType { get; set; }
        public int? ParentID { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public int? SellByUOMID { get; set; }
        public int? DefOnHandUOMID { get; set; }
        public int? DefCountUOMID { get; set; }
        public int? DefCountFrequencyID { get; set; }
        public int? DefConversionUOMID { get; set; }
        public decimal? DefConversionFactor { get; set; }
        public int? HzrdMaterialID { get; set; }
        public string Explanation { get; set; }
        public int? BIUOMID { get; set; }
        public char? BIEnableTankReadings { get; set; }
        public decimal? SpecificGravity { get; set; }
        public char? BIActiveMarneDelvApp { get; set; }
        public int? TemperatureCorrectID { get; set; }
        public char? IsBulk { get; set; }
    }
}
