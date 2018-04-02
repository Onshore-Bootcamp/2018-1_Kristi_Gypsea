using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Mapping
{
    public static class BoatMap2
    {
        public static List<BoatDO> DataTableToList(DataTable source)
        {
            List<BoatDO> allSailboats = new List<BoatDO>();
            if (source != null && source.Rows.Count > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    allSailboats.Add(RowToItem(row));
                }
            }
            return allSailboats;
        }
        public static BoatDO RowToItem(DataRow isource)
        {
            BoatDO to = new BoatDO();
            to.BoatID = (Int64)isource["BoatID"];
            if (isource["YearofBoat"] != DBNull.Value)
            {
                to.YearofBoat = (int)isource["YearofBoat"];
            }
            if (isource["BoatType"] != DBNull.Value)
            {
                to.BoatType = isource["BoatType"].ToString();
            }
            if (isource["Length"] != DBNull.Value)
            {
                to.Length = isource["Length"].ToString();
            }
            if (isource["Model"] != DBNull.Value)
            {
                to.Model = isource["Model"].ToString();
            }
            if (isource["CostperDay"] != DBNull.Value)
            {
                to.CostperDay = (Decimal)isource["CostperDay"];
            }
            return to;
        }
    }
}
