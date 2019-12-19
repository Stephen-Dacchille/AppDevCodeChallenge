using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDevCodeChallange1.Entities;
using Microsoft.Extensions.Logging;
using AppDevCodeChallange1.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AppDevCodeChallange1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private DbContextOptions<ApplicationDbContext> _contextOptions;

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger, DbContextOptions<ApplicationDbContext> contextOptions)
        {
            _logger = logger;
            _contextOptions = contextOptions;
        }

        [HttpGet]
        public IEnumerable<string> Get(string countryCode)
        {
            
            IEnumerable<string> cityList = null;
            using (ApplicationDbContext context = new ApplicationDbContext(_contextOptions))
            {
                IQueryable<City> cityQueryable = null;
                if (string.IsNullOrEmpty(countryCode))
                {
                    cityQueryable = context.City.OrderBy(x => x.CountryCode);
                }
                else
                {
                    string cc = countryCode.ToLower();
                    cityQueryable = context.City.Where(x => cc.Equals(x.CountryCode));
                }
                cityList = cityQueryable.Select(x => x.Name).ToList();
            }
            return cityList;
        }
    }
}