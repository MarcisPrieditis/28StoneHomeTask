using _28stoneHomeworkAPI.Abstraction;
using _28stoneHomeworkAPI.Methods;
using Microsoft.AspNetCore.Mvc;

namespace _28stoneHomeworkAPI.Controllers
{
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesApi _countries;

        public CountriesController(ICountriesApi countries)
        {
            _countries = countries;
        }

        [HttpGet]
        [Route("/Countries/TopTenByPopulation")]
        public async Task<IActionResult> GetTopTenCountriesByPopulation()
        {
            var getAllEuCountries = await _countries.GetCountries();

            return Ok(GetCountriesServices.SortByPopulation(getAllEuCountries).Take(10));
        }

        [HttpGet]
        [Route("/Countries/TopTenByDensity")]
        public async Task<IActionResult> GetTopTenCountriesByDensity()
        {
            var getAllEuCountries = await _countries.GetCountries();

            return Ok(GetCountriesServices.SortByDensity(getAllEuCountries).Take(10));
        }

        [HttpGet]
        [Route("countries/{name}")]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            var getAllEuCountries = await _countries.GetCountries();
            var countryByName = await _countries.GetCountryByName(name);
            var countryWithNewProperties = GetCountriesServices.MakeSearchedCountryObject(countryByName).FirstOrDefault();

            if (GetCountriesServices.IsValidEuCountry(getAllEuCountries, countryWithNewProperties!))
            {
                return Ok(countryWithNewProperties);
            }

            return BadRequest("This country does not exist in the Europe Union");
        }
    }
}
