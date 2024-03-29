﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AppDevCodeChallange1.Entities;
using AppDevCodeChallange1.Helpers;
using AppDevCodeChallange1.Interfaces;

namespace AppDevCodeChallange1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IDataService _dataService;

        private readonly ILogger<CityController> _logger;

        public CityController(IDataService dataService, ILogger<CityController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get(string countryCode)
        {
            IEnumerable<City> cities = await _dataService.GetCitiesFromCountryCode(countryCode);
            return cities.Select(x => x.Name);
        }
    }
}