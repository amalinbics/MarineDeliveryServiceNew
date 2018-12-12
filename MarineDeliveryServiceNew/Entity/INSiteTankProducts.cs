using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteTankProducts
    {
        public int INSiteTankID { get; set; }
        public int ProdContID { get; set; }
        public string EffectiveDate { get; set; }
        public int? ProductGroupID { get; set; }
        public int ClientID { get; set; }
    }
}
