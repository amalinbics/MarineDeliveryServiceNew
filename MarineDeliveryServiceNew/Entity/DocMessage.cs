using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{

    public class DocMessage
    {
        public int DocMessageID { get; set; }
        public string MessageCode { get; set; }
        public string MessageType { get; set; }
        public string DocType { get; set; }
        public int? DocFormatID { get; set; }
        public int? DXExportFormatID { get; set; }
        public string Active { get; set; }
        public string CompanyID { get; set; }
        public string MessageDescr1 { get; set; }
        public string MessageDescr2 { get; set; }
        public string MessageDescr3 { get; set; }
        public string MessageDescr4 { get; set; }
        public string ClientID { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime LastModifiedDtTm { get; set; }
        public string UQDocFormatID { get; set; }
        
    }
}
