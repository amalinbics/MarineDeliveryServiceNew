using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MeterTicket
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public string FileName { get; set; }
        public int SysTrxNo { get; set; }
        public int SysTrxLineNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeviceTime { get; set; }
        public string MeterImage { get; set; }
        public string CustomerID { get; set; }
        public int NeedUpdate { get; set; }
        public string File { get; set; }
        public string CompanyID { get; set; }
        public double? Quantity { get; set; }
        public double? StartMeter { get; set; }
        public double? EndMeter { get; set; }
        public string Vessel { get; set; }

    }

    public class GetMeterTicket
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public string FileName { get; set; }
        public int SysTrxNo { get; set; }
        public int SysTrxLineNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeviceTime { get; set; }
        public byte[] MeterImage { get; set; }
        public string CustomerID { get; set; }
        public int NeedUpdate { get; set; }
        public string File { get; set; }
        public string CompanyID { get; set; }
        public double? Quantity { get; set; }
        public double? StartMeter { get; set; }
        public double? EndMeter { get; set; }
        public string Vessel { get; set; }

    }
}