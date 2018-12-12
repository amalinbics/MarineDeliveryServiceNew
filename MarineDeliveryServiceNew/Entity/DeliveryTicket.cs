using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class GetDeliveryTicket
    {
        public int? ID { get; set; }
        public string OrderNo { get; set; }
        public DateTime DeviceTime { get; set; }
        public Byte[] DeliveryImage { get; set; }        
        public DateTime CreatedDate { get; set; }
        public int NeedUpdate { get; set; }
        public string FileName { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
    }

    public class DeliveryTicket
    {
        public int? ID { get; set; }
        public string OrderNo { get; set; }
        public DateTime DeviceTime { get; set; }
        public string DeliveryImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NeedUpdate { get; set; }
        public string FileName { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
    }
}
