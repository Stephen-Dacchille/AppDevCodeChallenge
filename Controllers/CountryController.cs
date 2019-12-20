using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Tuple<string, int, float>>> Get(string region)
        {
            IEnumerable<Country> countries = await _dataService.GetCountriesFromRegion(region);
            return countries.Select(x => new Tuple<string, int, float>(x.Name, x.Population, x.LifeExpectancy ?? 0));
        }

    }
}