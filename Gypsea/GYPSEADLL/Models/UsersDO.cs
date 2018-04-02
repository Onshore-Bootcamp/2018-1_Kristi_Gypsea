using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Models
{
    public class UsersDO
    {
        public Int64 UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string StateProvidence { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }
        
    }
}
