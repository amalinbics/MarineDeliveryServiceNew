using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
  public  class OrderNote
    {
        public int SysTrxNo { get; set; }
        public int NoteNo { get; set; }
        public int NoteTypeID { get; set; }
        public string Note { get; set; }
        public string PrintOn { get; set; }
        public int ClientID { get; set; }
        public int? NoteID { get; set; }
        public int? IsAppNote { get; set; }
        public string LastModifiedUserID {get;set;}
        public string LastModifiedDateTime { get; set; }  
        
    }
}
