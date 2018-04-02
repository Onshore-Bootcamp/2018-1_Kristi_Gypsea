using GYPSEA.Models;
using GYPSEABLL.Models;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYPSEA.Mapping
{
    public static class HighestProfitMap
    {
        public static InvoicePO InvoiceBOtoInvoicePO(InvoiceBO from)
        {
            //maps to and fro bo to po
            InvoicePO to = new InvoicePO();
            to.InvoiceID = from.InvoiceID;
            to.LastName = from.LastName;
            to.FirstName = from.FirstName;
            to.Address = from.Address;
            to.City = from.City;
            to.StateProvidence = from.StateProvidence;
            to.Country = from.Country;
            to.PostalCode = from.PostalCode;
            to.DateChartered = from.DateChartered;
            to.DateReturned = from.DateReturned;
            to.CostperDay = from.CostperDay;
            to.AmountDue = from.AmountDue;
            to.BoatID = from.BoatID;
            to.UserID = from.UserID;
            return to;
        }
        public static InvoiceBO InvoicePOtoInvoiceBO(InvoicePO from)
        {
            // maps to and from  po to bo
            InvoiceBO to = new InvoiceBO();
            to.InvoiceID = from.InvoiceID;
            to.LastName = from.LastName;
            to.FirstName = from.FirstName;
            to.Address = from.Address;
            to.City = from.City;
            to.StateProvidence = from.StateProvidence;
            to.Country = from.Country;
            to.PostalCode = from.PostalCode;
            to.DateChartered = from.DateChartered;
            to.DateReturned = from.DateReturned;
            to.CostperDay = from.CostperDay;
            to.AmountDue = from.AmountDue;
            to.BoatID = from.BoatID;
            to.UserID = from.UserID;
            return to;
        }

        public static InvoiceBO InvoiceDOtoInvoiceBO(InvoiceDO from)
        {
            //maps to and from do to po 
            InvoiceBO to = new InvoiceBO();
            to.InvoiceID = from.InvoiceID;
            to.LastName = from.LastName;
            to.FirstName = from.FirstName;
            to.Address = from.Address;
            to.City = from.City;
            to.StateProvidence = from.StateProvidence;
            to.Country = from.Country;
            to.PostalCode = from.PostalCode;
            to.DateChartered = from.DateChartered;
            to.DateReturned = from.DateReturned;
            to.CostperDay = from.CostperDay;
            to.AmountDue = from.AmountDue;
            to.BoatID = from.BoatID;
            to.UserID = from.UserID;
            return to;
        }
    }
}