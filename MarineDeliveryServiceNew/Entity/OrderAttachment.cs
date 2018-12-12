using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class OrderAttachment
    {
        public string env { get; set; }
        public string OrderNo { get; set; }
        public string attachementData { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class CloudOrderAttachment
    {
        public int SysTrxNo { get; set; }
        public string OrderNo { get; set; }
        public string attachementData { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int AttachmentID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string LastModifiedUser { get; set; }

        public string FileExt { get; set; }

        public string FileDescr { get; set; }

        public byte[] DataFile { get; set; }
    }
}
