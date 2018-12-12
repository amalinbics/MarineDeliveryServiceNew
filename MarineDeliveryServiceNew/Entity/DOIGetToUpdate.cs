using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class DOIGetToUpdate
    {
        public int? ID { get; set; }
        public string OrderNO { get; set; }
        public int? OrderItemID { get; set; }
        public string DOIImage { get; set; }
        public string UserID { get; set; }
        public char? DOIType { get; set; }
        public string FileName  { get; set; }
        public string File { get; set; }
        public int NeedUpdate { get; set; }
        public string CompanyID { get; set; }
    }

    public class DOIGet
    {
        public int? ID { get; set; }
        public string OrderNO { get; set; }
        public int? OrderItemID { get; set; }
        public byte[] DOIImage { get; set; }
        public string UserID { get; set; }
        public char? DOIType { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public int NeedUpdate { get; set; }
        public string CompanyID { get; set; }
    }
}
