using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
   public class PersonPhoneDeletedTrx
    {
        public int PhoneID { get; set; }
        public int PersonID { get; set; }
        public string TableName { get; set; }
    }
}
