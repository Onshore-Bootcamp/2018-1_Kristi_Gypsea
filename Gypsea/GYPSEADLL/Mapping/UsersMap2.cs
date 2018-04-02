using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Mapping
{
    public static class UsersMap2
    {
        public static List<UsersDO> DataTableToList(DataTable source)
        {
            List<UsersDO> allUsers = new List<UsersDO>();
            if (source != null && source.Rows.Count > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    allUsers.Add(RowToItem(row));
                }
            }
            return allUsers;
        }
        public static UsersDO RowToItem(DataRow isource)
        {
            UsersDO to = new UsersDO();
            to.UserID = (Int64)isource["UserID"];
            if (isource["UserName"] != DBNull.Value)
            {
                to.UserName = isource["UserName"].ToString();
            }
            if (isource["Password"] != DBNull.Value)
            {
                to.Password = isource["Password"].ToString();
            }
            if (isource["LastName"] != DBNull.Value)
            {
                to.LastName = isource["LastName"].ToString();
            }
            if (isource["FirstName"] != DBNull.Value)
            {
                to.FirstName = isource["FirstName"].ToString();
            }
            if (isource["Email"] != DBNull.Value)
            {
                to.Email = isource["Email"].ToString();
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
            if (isource["PostalCode"] != DBNull.Value)
            {
                to.PostalCode = (int)isource["PostalCode"];
            }
            if (isource["Country"] != DBNull.Value)
            {
                to.Country = isource["Country"].ToString();
            }
            if (isource.Table.Columns.Contains("RoleID") && isource["RoleID"] != DBNull.Value)
            {
                to.RoleID = (int)isource["RoleID"];
            }
            if (isource.Table.Columns.Contains("RoleName") && isource["RoleName"] != DBNull.Value)
            {
                to.RoleName = isource["RoleName"].ToString();
            }
            return to;
        }
    }
}
