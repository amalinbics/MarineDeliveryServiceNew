using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class Drivers
    {
        public int DriverID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string DriverNo { get; set; }
        public string EmployeeNo { get; set; }
        public string DriverType { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public int ClientID { get; set; }
        public string LastModifiedDtTm { get; set; }
        public string OriginateCompanyID { get; set; }

    }
}
