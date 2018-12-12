using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class OrderStatusHistory
    {
        public int SysTrxNo { get; set; }
        public char OrderStatusID { get; set; }
        public string LoadNo { get; set; }
    }
}
