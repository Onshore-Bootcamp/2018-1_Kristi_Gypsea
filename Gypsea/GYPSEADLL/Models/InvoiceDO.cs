using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Models
{
    public class InvoiceDO
    {
        public Int64 InvoiceID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string StateProvidence { get; set; }

        public string Country { get; set; }

        public int PostalCode { get; set; }

        public DateTime DateChartered { get; set; }

        public DateTime DateReturned { get; set; }

        public decimal CostperDay { get; set; }

        public decimal AmountDue { get; set; }

        public Int64 BoatID { get; set; }

        public Int64 UserID { get; set; }

        
    }
}
