using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Attachment
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public int SysTrxNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeviceTime { get; set; }
        public string AttachmentFile { get; set; }
        public string CustomerID { get; set; }
        public string AttachmentName { get; set; }
        public int NeedUpdate { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public string Status { get; set; }
        public string CompanyID { get; set; }
    }

    public class GetAttachment
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public int SysTrxNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeviceTime { get; set; }
        public byte[] AttachmentFile { get; set; }
        public string CustomerID { get; set; }
        public string AttachmentName { get; set; }
        public int NeedUpdate { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public string Status { get; set; }
        public string CompanyID { get; set; }
    }
}