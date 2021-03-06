﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Countries.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}