using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteTankVolume
    {
        public int INSiteTankVolumeID { get; set; }
        public int INSiteTankID { get; set; }
        public int INSiteID { get; set; }
        public int ProdContID { get; set; }
        public string ReadingDateTime { get; set; }
        public decimal Quantity { get; set; }
        public char Status { get; set; }
        public int TankReadingTypeID { get; set; }
        public int? Depth { get; set; }
        public int? DepthNumerator { get; set; }
        public string LastModifiedUser { get; set; }
        public string LastModifiedDtTm { get; set; }
        public int Water_Volume { get; set; }
        public int? Feet { get; set; }
        public string Descr { get; set; }
        public int ReadingID { get; set; }
        public char BeforeorAfter { get; set; }
        public string TransactionNumber { get; set; }
        public string LastReadingDateTime { get; set; }
        public int CustomerID { get; set; }
        public int? DraftFeetB { get; set; }
        public int? DraftFeetS { get; set; }
        public int? DraftB { get; set; }
        public int? DraftS { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? AmbientTemperature { get; set; }
        public string  Comment { get; set; }
    }
}
