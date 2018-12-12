using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class PersonPhone
    {
        public int PhoneID { get; set; }
        public int PersonID { get; set; }
        public string PhoneNo { get; set; }
        public int? Type { get; set; }
        public string Extension { get; set; }
        public int ClientID { get; set; }
    }
}
