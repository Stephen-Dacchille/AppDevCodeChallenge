using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevCodeChallange1.Entities;
using AppDevCodeChallange1.Interfaces;

namespace AppDevCodeChallange1.Services
{
    public class DataService : IDataService
    {
        private readonly string _connectionString;
        private readonly IAppSettings _appSettings;

        public DataService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _connectionString = appSettings.DbConnectionString;
        }

        public async Task<IEnumerable<City>> GetCitiesFromCountryCode(string countryCode)
        {
            IEnumerable<City> cities = null;
            using (ApplicationDbContext context = new ApplicationDbContext(_connectionString))
            {
                if (string.IsNullOrEmpty(countryCode))
                {
                    cities = await Task.FromResult(context.City.Where(x => !string.IsNullOrEmpty(x.CountryCode)).OrderBy(x => x.CountryCode).ToList());
                }
                else
                {
                    string codeTL = countryCode.ToLower();
                    cities = await Task.FromResult(context.City.Where(x => !string.IsNullOrEmpty(x.CountryCode) && codeTL.Equals(x.CountryCode.ToLower())).ToList());
                }
            }
            return cities;
        }

        public async Task<IEnumerable<Country>> GetCountriesFromRegion(string region)
        {
            IEnumerable<Country> countries = null;
            using (ApplicationDbContext context = new ApplicationDbContext(_connectionString))
            {
                if (string.IsNullOrEmpty(region))
                {
                    countries = await Task.FromResult(context.Country.Where(x => !string.IsNullOrEmpty(x.Region)).OrderBy(x => x.Region).ToList());
                }
                else
                {
                    string codeTL = region.ToLower();
                    countries = await Task.FromResult(context.Country.Where(x => !string.IsNullOrEmpty(x.Region) && codeTL.Equals(x.Region.ToLower())).ToList());
                }
            }
            return countries;
        }

        public async Task<IEnumerable<Country>> GetCountriesFromCountryCode(string countryCode)
        {
            IEnumerable<Country> countries = null;
            using (ApplicationDbContext context = new ApplicationDbContext(_connectionString))
            {
                if (string.IsNullOrEmpty(countryCode))
                {
                    countries = await Task.FromResult(context.Country.Where(x => !string.IsNullOrEmpty(x.Code)).OrderBy(x => x.Code).ToList());
                }
                else
                {
                    string codeTL = countryCode.ToLower();
                    countries = await Task.FromResult(context.Country.Where(x => !string.IsNullOrEmpty(x.Code) && codeTL.Equals(x.Code.ToLower())).ToList());
                }
            }
            return countries;
        }
    }
}
