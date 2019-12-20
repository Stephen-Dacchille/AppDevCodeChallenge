using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDevCodeChallange1.Entities;

namespace AppDevCodeChallange1.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<City>> GetCitiesFromCountryCode(string countryCode);
        Task<IEnumerable<Country>> GetCountriesFromRegion(string region);
        Task<IEnumerable<Country>> GetCountriesFromCountryCode(string countryCode);
    }
}
