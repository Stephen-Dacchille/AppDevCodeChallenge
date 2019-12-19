using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDevCodeChallange1.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AppDevCodeChallange1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private DbContextOptions<ApplicationDbContext> _contextOptions;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger, DbContextOptions<ApplicationDbContext> contextOptions)
        {
            _logger = logger;
            _contextOptions = contextOptions;
        }

        [HttpGet]
        public IEnumerable<Tuple<string, int, float>> Get(string region)
        {
            IEnumerable<Tuple<string, int, float>> countryList = null;
            using (ApplicationDbContext context = new ApplicationDbContext(_contextOptions))
            {
                IQueryable<Country> countryQueryable = null;
                if (string.IsNullOrEmpty(region))
                {
                    countryQueryable = context.Country.Where(x => !string.IsNullOrEmpty(x.Region)).OrderBy(x => x.Region);
                }
                else
                {
                    string reg = region.ToLower();
                    countryQueryable = context.Country.Where(x => !string.IsNullOrEmpty(x.Region) && reg.Equals(x.Region));
                }
                countryList = countryQueryable.Select(x => new Tuple<string, int, float>(x.Name, x.Population, x.LifeExpectancy)).ToList();
            }
            return countryList;
        }
    }
}