using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Models
{
    public class CountriesAndCitiesModel
    {
        public int SelectionId { get; set; }
        public int CitySelectionId { get; set; }
        public  List<Country> countries { get; set; }
        public List<City> cities { get; set; }
    }
}