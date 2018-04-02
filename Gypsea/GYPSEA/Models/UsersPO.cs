using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GYPSEA.Models
{
    public class UsersPO
    {
        public Int64 UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateProvidence { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}