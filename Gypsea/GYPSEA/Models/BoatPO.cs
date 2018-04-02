using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GYPSEA.Models
{
    public class BoatPO
    {
        public Int64 BoatID { get; set; }

        [Required]
        public int YearofBoat { get; set; }

        [Required]
        public string BoatType { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal CostperDay { get; set; }
    }
}