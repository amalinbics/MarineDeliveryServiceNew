using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class INSiteTankProductAPI
    {
        public int ProductAPIID { get; set; }
        public int InSiteTankID { get; set; }
        public int ProdContID { get; set; }
        public decimal API_Rating { get; set; }
        public string Notes { get; set; }
        public string EffDtTm { get; set; }
        public string CreatedDtTm { get; set; }
        public string CreatedByUser { get; set; }
        public int ClientID { get; set; }

    }
}
