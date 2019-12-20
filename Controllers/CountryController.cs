using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppDevCodeChallange1.Entities;
using AppDevCodeChallange1.Interfaces;

namespace AppDevCodeChallange1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IEnumerable<Tuple<string, int>>> Get(string countryCode)
        {
            IEnumerable<Country> countries = await _dataService.GetCountriesFromCountryCode(countryCode);
            return countries.Select(x => new Tuple<string, int>(x.Name, x.Population));
        }

    }
}
