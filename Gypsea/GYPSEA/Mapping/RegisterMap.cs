using GYPSEA.Models;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYPSEA.Mapping
{
    public static class RegisterMap
    {
        public static RegisterPO UsersDOtoRegisterPO(UsersDO from)
        {
            RegisterPO to = new RegisterPO();
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
            return to;
        }
        public static UsersDO RegisterPOtoUsersDO(RegisterPO from)
        {
            UsersDO to = new UsersDO();
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
            return to;
        }
    }
}