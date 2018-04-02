using GYPSEABLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEABLL
{
    public static class InvoiceBLO
    {
        
        public static List<KeyValuePair<Int64, int>> TopBoatsByInvoiceCount(List<InvoiceBO> allInvoices)
        {
            //definines new dictionary invoice count
            Dictionary<Int64, int> boatIDWithInvoiceCount = new Dictionary<long, int>();

            foreach (InvoiceBO currentInvoice in allInvoices)
            {
                //if the boatID occurs in the invoice count add them
                if (boatIDWithInvoiceCount.ContainsKey(currentInvoice.BoatID))
                {
                    boatIDWithInvoiceCount[currentInvoice.BoatID]++;
                }
                else
                {
                    //the boat is just 1
                    boatIDWithInvoiceCount.Add(currentInvoice.BoatID, 1);
                }
            }
            //return the top 3 boats from that list
            return boatIDWithInvoiceCount.OrderByDescending(boat => boat.Value).Take(3).ToList();
        }

    }
}
