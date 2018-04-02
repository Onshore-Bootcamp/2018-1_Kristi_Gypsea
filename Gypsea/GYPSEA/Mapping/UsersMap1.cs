using GYPSEA.Models;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYPSEA.Mapping
{
    public static class UsersMap1
    {
        public static UsersPO UsersDOtoUsersPO(UsersDO from)
        {
            UsersPO to = new UsersPO();
            to.UserID = from.UserID;
            to.UserName = from.UserName;
            to.Password = from.Password;
            to.LastName = from.LastName;
            to.FirstName = from.FirstName;
            to.Email = from.Email;
            to.Address = from.Address;
            to.City = from.City;
            to.StateProvidence = from.StateProvidence;
            to.PostalCode = from.PostalCode;
            to.Country = from.Country;
            to.RoleID = from.RoleID;
            to.RoleName = from.RoleName;
            return to;
        }
        public static UsersDO UsersPOtoDO(UsersPO from)
        {
            UsersDO to = new UsersDO();
            to.UserID = from.UserID;
            to.UserName = from.UserName;
            to.Password = from.Password;
            to.LastName = from.LastName;
            to.FirstName = from.FirstName;
            to.Email = from.Email;
            to.Address = from.Address;
            to.City = from.City;
            to.StateProvidence = from.StateProvidence;
            to.PostalCode = from.PostalCode;
            to.Country = from.Country;
            to.RoleID = from.RoleID;
            to.RoleName = from.RoleName;
            return to;
        }
    }
}