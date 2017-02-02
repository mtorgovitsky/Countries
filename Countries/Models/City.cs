using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Countries.Models
{
    public class City
    {
        public int CityID { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryID { get; set; }
    }
}