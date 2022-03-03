using System.Collections.Generic;
using _28stoneHomeworkAPI.Methods;
using _28stoneHomeworkAPI.Models;
using Newtonsoft.Json;
using Xunit;

namespace CountriesTaskAPI.Tests;

public class CountriesServiceTests
{
    private readonly List<CountryModel> _countriesTestList = new()
    {
        new CountryModel
        {
            Name = "TestFalse",
            Area = 1,
            Population = 1,
            TopLevelDomain = new List<string> { ".be" },
            NativeName = "America",
            Independent = false
        },
        new CountryModel
        {
            Name = "Austria",
            Area = 2,
            Population = 10,
            TopLevelDomain = new List<string> { ".at" },
            NativeName = "Österreich",
            Independent = true
        },
        new CountryModel
        {
            Name = "Belgium",
            Area = 2,
            Population = 20,
            TopLevelDomain = new List<string> { ".be" },
            NativeName = "België",
            Independent = true
        },
        new CountryModel
        {
            Name = "Bulgaria",
            Area = 2,
            Population = 30,
            TopLevelDomain = new List<string> { ".bg" },
            NativeName = "България",
            Independent = true
        }
    };

    [Fact]
    public void GetCountriesByPopulation_ShouldReturnCountriesList_ByHighestPopulation()
    {
        //Arrange
        var expectedCountriesList = new List<CountryModel>
        {
            new()
            {
                Name = "Bulgaria",
                Area = 2,
                Population = 30,
                TopLevelDomain = new List<string> {".bg"},
                NativeName = "България",
                Independent = true
            },
            new()
            {
                Name = "Belgium",
                Area = 2,
                Population = 20,
                TopLevelDomain = new List<string> {".be"},
                NativeName = "België",
                Independent = true
            },
            new()
            {
                Name = "Austria",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Österreich",
                Independent = true
            }
        };


        //Act
        var result = GetCountriesServices.SortByPopulation(_countriesTestList);
        var expectedObject = JsonConvert.SerializeObject(expectedCountriesList);
        var resultObject = JsonConvert.SerializeObject(result);

        //Assert
        Assert.Equal(expectedObject, resultObject);
    }

    [Fact]
    public void GetCountriesByDensity_ShouldReturnCountriesList_ByHighestDensity()
    {
        //Arrange
        var expectedCountriesList = new List<CountryModel>
        {
            new()
            {
                Name = "Bulgaria",
                Area = 2,
                Population = 30,
                TopLevelDomain = new List<string> {".bg"},
                NativeName = "България",
                Independent = true
            },
            new()
            {
                Name = "Belgium",
                Area = 2,
                Population = 20,
                TopLevelDomain = new List<string> {".be"},
                NativeName = "België",
                Independent = true
            },
            new()
            {
                Name = "Austria",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Österreich",
                Independent = true
            }
        };

        //Act
        var result = GetCountriesServices.SortByDensity(_countriesTestList);
        var expectedObject = JsonConvert.SerializeObject(expectedCountriesList);
        var resultObject = JsonConvert.SerializeObject(result);

        //Assert
        Assert.Equal(expectedObject, resultObject);
    }

    [Fact]
    public void MakeNewObjectOfSearchedCountry_ShouldReturnObjectWithout_NameAndIndependent()
    {
        //Arrange
        var europeUnionCountries = new List<CountryModel>
        {
            new()
            {
                Name = "Austria", Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Österreich",
                Independent = true
            }
        };
        var expectedCountryList = new List<SingleCountryModel>
        {
            new()
            {
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Österreich"
            }
        };

        //Act
        var result = GetCountriesServices.MakeSearchedCountryObject(europeUnionCountries);
        var expectedObject = JsonConvert.SerializeObject(expectedCountryList);
        var resultObject = JsonConvert.SerializeObject(result);

        //Assert
        Assert.Equal(expectedObject, resultObject);
    }

    [Fact]
    public void CheckIfCountryIsInEU_Latvia_ShouldReturnTrue()
    {
        //Arrange
        var europeUnionCountries = new List<CountryModel>
        {
            new()
            {
                Name = "Latvia",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Latvija"
            }
        };
        var countryByName = new SingleCountryModel()
        {
            Area = 2,
            Population = 10,
            TopLevelDomain = new List<string> { ".at" },
            NativeName = "Latvija"
        };

        //Act
        var result = GetCountriesServices.IsValidEuCountry(europeUnionCountries, countryByName);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void CheckIfCountryIsInEU_America_ShouldReturnFalse()
    {
        //Arrange
        var europeUnionCountries = new List<CountryModel>
        {
            new()
            {
                Name = "Latvia",
                Area = 2,
                Population = 10,
                TopLevelDomain = new List<string> {".at"},
                NativeName = "Latvija"
            }
        };
        var countryByName = new SingleCountryModel()
        {
            Area = 2,
            Population = 10,
            TopLevelDomain = new List<string> { ".at" },
            NativeName = "America"
        };

        //Act
        var result = GetCountriesServices.IsValidEuCountry(europeUnionCountries, countryByName);

        //Assert
        Assert.False(result);
    }
}