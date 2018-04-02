using GYPSEA.Models;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYPSEA.Mapping
{
    public static class BoatMap1
    {
        public static BoatPO BoatDOtoBoatPO(BoatDO from)
        {
            BoatPO to = new BoatPO();
            to.BoatID = from.BoatID;
            to.YearofBoat = from.YearofBoat;
            to.BoatType = from.BoatType;
            to.Length = from.Length;
            to.Model = from.Model;
            to.CostperDay = from.CostperDay;
            return to;

        }
        public static BoatDO BoatPOtoDO(BoatPO from)
        {
            BoatDO to = new BoatDO();
            to.BoatID = from.BoatID;
            to.YearofBoat = from.YearofBoat;
            to.BoatType = from.BoatType;
            to.Length = from.Length;
            to.Model = from.Model;
            to.CostperDay = from.CostperDay;
            return to;
        }
    }
}