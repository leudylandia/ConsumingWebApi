using ConsumingWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Controllers
{
    public class CountriesController : Controller
    {
        ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            var countries = _countryRepository.GetCountries();

            if (countries == null)
            {
                ViewBag.Message = "There was a problem or not country exists";
            }

            return View(countries);
        }

        public IActionResult GetCountryById(int countryId)
        {
            var country = _countryRepository.GetCountryById(countryId);

            if (country == null)
            {
                ModelState.AddModelError("", "Error getting a country");
                ViewBag.Message = $"there was a problem retrieving couuntry with id {countryId} from the database or no country with that id exists";
            }

            return View(country);
        }
    }
}
