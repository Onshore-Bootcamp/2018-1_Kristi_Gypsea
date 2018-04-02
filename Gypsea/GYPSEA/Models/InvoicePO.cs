using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GYPSEA.Models
{
    public class InvoicePO
    {
        public Int64 InvoiceID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateProvidence { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateChartered { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateReturned { get; set; }

        public decimal CostperDay { get; set; }

        public decimal AmountDue { get; set; }

        public Int64 BoatID { get; set; }

        public Int64 UserID { get; set; }

        
    }
}