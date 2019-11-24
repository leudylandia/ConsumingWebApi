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
    }
}
