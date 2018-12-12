using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{

    public class INSiteProdCont
    {
        public int SiteID { get; set; }
        public int ProdContID { get; set; }
        public char? ActiveToSell { get; set; }
        public char? ActiveToPurch { get; set; }
        public string ActiveDt { get; set; }
        public decimal? MaxOnhand { get; set; }
        public decimal? MinOnhand { get; set; }
        public decimal? OnHand { get; set; }
        public int? OnHandUOMID { get; set; }
        public int? ConversionUOMID { get; set; }
        public decimal? ConversionFactor { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? WAC { get; set; }
        public decimal? InTransit { get; set; }
        public int ClientID { get; set; }
        public string lastmodifieddttm { get; set; }
        public int? CountUOMID  { get; set; }
        public char ActiveMarneDelvApp { get; set; }
    }
}
