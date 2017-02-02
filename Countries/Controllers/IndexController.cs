using Countries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Countries.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            using (CountriesDB context = new Models.CountriesDB())
            {
                var countries = context.Countries.ToList();
                var cities = context.Cities.ToList();

                var Model = new CountriesAndCitiesModel()
                {
                    countries = countries,
                    cities = cities
                };

                return View(Model);
            }
        }

        [HttpPost]
        public ActionResult Index(CountriesAndCitiesModel myWrapper)
        {
            using (CountriesDB context = new Models.CountriesDB())
            {
                var countries = context.Countries.ToList();
                var cities = context.Cities.ToList();
                
                myWrapper.countries = countries;
                myWrapper.cities = context.Cities
                    .Where(c => c.CountryID == myWrapper.SelectionId).ToList();

                return View(myWrapper);
            }
        }
    }
}