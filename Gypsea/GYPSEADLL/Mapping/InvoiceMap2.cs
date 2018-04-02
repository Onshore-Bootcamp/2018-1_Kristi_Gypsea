using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Mapping
{
    public static class InvoiceMap2
    {
        public static List<InvoiceDO> DataTableToList(DataTable source)
        {
            //get list
            List<InvoiceDO> allInvoices = new List<InvoiceDO>();
            //if source is null and source row count is greater that 0
            if (source != null && source.Rows.Count > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    allInvoices.Add(RowToItem(row));
                }
            }
            return allInvoices;
        }
        public static InvoiceDO RowToItem(DataRow isource)
        {
            //if isource is not null fills in items 
            InvoiceDO to = new InvoiceDO();
            to.InvoiceID = (Int64)isource["InvoiceID"];
            if (isource["LastName"] != DBNull.Value)
            {
                to.LastName = isource["LastName"].ToString();
            }
            if (isource["FirstName"] != DBNull.Value)
            {
                to.FirstName = isource["FirstName"].ToString();
            }
            if (isource["Address"] != DBNull.Value)
            {
                to.Address = isource["Address"].ToString();
            }
            if (isource["City"] != DBNull.Value)
            {
                to.City = isource["City"].ToString();
            }
            if (isource["StateProvidence"] != DBNull.Value)
            {
                to.StateProvidence = isource["StateProvidence"].ToString();
            }
            if (isource["Country"] != DBNull.Value)
            {
                to.Country = isource["Country"].ToString();
            }
            if (isource["PostalCode"] != DBNull.Value)
            {
                to.PostalCode = (int)isource["PostalCode"];
            }
            if (isource["DateChartered"] != DBNull.Value)
            {
                to.DateChartered = (DateTime)isource["DateChartered"];
            }
            if (isource["DateReturned"] != DBNull.Value)
            {
                to.DateReturned = (DateTime)isource["DateReturned"];
            }
            if (isource["CostperDay"] != DBNull.Value)
            {
                to.CostperDay = (decimal)isource["CostperDay"];
            }
            if (isource["AmountDue"] != DBNull.Value)
            {
                to.AmountDue = (decimal)isource["AmountDue"];
            }
            if (isource["BoatID"] != DBNull.Value)
            {
                to.BoatID = (Int64)isource["BoatID"];
            }
            if (isource["UserID"] != DBNull.Value)
            {
                to.UserID = (Int64)isource["UserID"];
            }
            return to;
        }

    }
}
