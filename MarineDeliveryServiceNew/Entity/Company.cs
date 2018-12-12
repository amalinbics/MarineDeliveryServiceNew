using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Company
    {
        public string Company_ID { get; set; }
        public string Company_Name { get; set; }
        public string Federal_Id_No { get; set; }
        public string Fiscal_Year_End { get; set; }
        public string Last_Maintained_By { get; set; }
        public string ClientID { get; set; }
        public string Email { get; set; }
        
        public int? TimeZoneID { get; set; }
        public int? DdBrokerNo { get; set; }
        
        public string EnableMarineOperations { get; set; }
        public string FormattedAddress { get; set; }
        public string FormattedLineAddress { get; set; }
        public string FormattedMailAddress { get; set; }
        public string FormattedMailLineAddress { get; set; }

        public DateTime? Date_Created { get; set; }
        public DateTime? Date_Last_Modified { get; set; }

        public string  Central_Phone_Number { get; set; }

    }
}
