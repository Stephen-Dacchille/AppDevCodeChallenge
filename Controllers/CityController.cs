using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDevCodeChallange1.Entities;
using Microsoft.Extensions.Logging;

namespace AppDevCodeChallange1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;

        public CityController(ILogger<CityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<string> cityList = null;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.City.OrderBy(x => x.CountryCode).ToList();
            }
            return cityList;
        }
    }
}