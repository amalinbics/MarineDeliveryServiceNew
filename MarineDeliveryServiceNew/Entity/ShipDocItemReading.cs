using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class ShipDocItemReading
    {
        public int ReadingID { get; set; }
        public char SrcDst { get; set; }
        public int SysTrxNo { get; set; }
        public int SysTrxLine { get; set; }
        public int ComponentNo { get; set; }
        public int BOLLineNo { get; set; }
        public char? ReadingBy { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public decimal? BeforeDraftB { get; set; }
        public decimal? BeforeDraftS { get; set; }
        public decimal? BeforeTemp { get; set; }
        public decimal? AfterDraftB { get; set; }
        public decimal? AfterDraftS { get; set; }
        public decimal? AfterTemp { get; set; }
        public char? KeelTo { get; set; }
        public decimal? KeelDegree { get; set; }
        public decimal? QtyBefore { get; set; }
        public decimal? QtyAfter { get; set; }
        public decimal? CalcQty { get; set; }
        public string EnteredBy { get; set; }
        public string ReadBy { get; set; }
        public string CustomerID { get; set; }
        public int ClientID { get; set; }
        public int? BeforeDraftFeetB { get; set; }
        public int? BeforeDraftFeetS { get; set; }
        public int? AfterDraftFeetB { get; set; }
        public int? AfterDraftFeetS { get; set; }
        public int? InSiteTankID { get; set; }       
        public char ProcessStep { get; set; }
        public decimal? BeforeATemp { get; set; }
        public decimal? AfterATemp { get; set; }
        //public int? SessionID { get; set; }
        //public string OrderNo { get; set; }
        //public int? UniqueID { get; set; }

    }
}
