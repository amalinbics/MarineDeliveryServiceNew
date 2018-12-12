using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarineDeliveryWinServiceNew.Entity
{
    public class LoginUser
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Active { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string MarineAppAccess { get; set; }
        public int ClientID { get; set; }
    }
}
