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
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new City
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}