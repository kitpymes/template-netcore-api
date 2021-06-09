using System;
using System.Collections.Generic;
using System.Linq;
using Kitpymes.Core.Logger;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var logger = Log
               .UseSerilog(serilog => serilog.AddFile("Logs/WeatherForecast_.log"))
               .CreateLogger(nameof(WeatherForecast));

            var rng = new Random();

            var ex = new Exception("NEW CUSTOM EXCEPTION !!!!!!!!!!!!!!!!!!!!!!!!!!");

            logger.Error(ex);

            throw ex;
        }
    }
}
