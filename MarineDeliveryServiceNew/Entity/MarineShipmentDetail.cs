using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class MarineShipmentDetail
    {
        public int SysTrxNo { get; set; }
        public int SessionID {get; set;}
        public int SysTrxLine  {get; set;}
        public int MasterProdID  {get; set;}
        public int? UOMID  {get; set;}
        public int? Temperature  {get; set;}
        public int? SpecificGravity  {get; set;}
        public decimal? GrossQty { get; set; }
        public decimal? NetQty  {get; set;}
        public string Note  {get; set;}
        public int? OrderSysTrxLine  {get; set;}
        public char? Ship  {get; set;}
        public string UOMGrossQty  {get; set;}
        public string UOMNetQty  {get; set;}
        public int? InterUOMID {get; set;}
        public int? ToUOMID {get; set;}
        public string KeyedGrossQty {get; set;}
        public string KeyedNetQty {get; set;}
        public string CustomerID { get; set; }

        public int? ShipToVesselID { get; set; }
        public int? ToTankID { get; set; }
        public int? DeliverAt { get; set; }
        public int? ShipSysTrxNo { get; set; }
        public int? ShipSysTrxLine { get; set; }
        public int? APIRating { get; set; }
        public char? Delivery { get; set; }
        public int ClientID
        {
            get
            {
                return Convert.ToInt32(CustomerID);
            }            
        }
    }
}
