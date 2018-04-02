using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL.Models
{
    public class BoatDO
    {
        public Int64 BoatID { get; set; }

        public int YearofBoat { get; set; }

        public string BoatType { get; set; }

        public string Length { get; set; }

        public string Model { get; set; }

        public decimal CostperDay { get; set; }
    }
}
