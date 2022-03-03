using _28stoneHomeworkAPI.Models;

namespace _28stoneHomeworkAPI.Methods;

public static class GetCountriesServices
{
    public static IEnumerable<CountryModel> EuropeUnionCountry(List<CountryModel> country)
    {
        //In EU regionbloc api returns 31country.
        //Countries with independent = false is not in Europe Uninon, so this method sorts out to return only EU countries
        var euCountries = country.Where(c => c.Independent);

        return euCountries;
    }

    public static IEnumerable<CountryModel> SortByDensity(List<CountryModel> country)
    {
        var euCountries = EuropeUnionCountry(country);
        var sortByDensityFirstTen = euCountries.OrderByDescending(c => c.Population / c.Area);

        return sortByDensityFirstTen;
    }

    public static IEnumerable<CountryModel> SortByPopulation(List<CountryModel> country)
    {
        var euCountries = EuropeUnionCountry(country);
        var sortByPopulationTop10 = euCountries.OrderByDescending(c => c.Population);

        return sortByPopulationTop10;
    }

    public static IEnumerable<SingleCountryModel> MakeSearchedCountryObject(List<CountryModel> country)
    {
        return country.Select(c =>
            new SingleCountryModel
            {
                Area = c.Area,
                Population = c.Population,
                TopLevelDomain = c.TopLevelDomain!,
                NativeName = c.NativeName!
            });
    }

    public static bool IsValidEuCountry(List<CountryModel> europeUnionCountries, SingleCountryModel name)
    {
        return europeUnionCountries.Any(c => c.NativeName == name.NativeName);
    }
}