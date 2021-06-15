using System;
using System.Collections.Generic;
using System.Linq;
using Kitpymes.Core.Shared.Util;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Api.Result.Controllers
{
    public class WeatherForecastController : ApiControllerBase<WeatherForecastController>
    {
        [HttpGet]
        public IActionResult Get() => ApiResult(GetAll());

        private IResult GetAll()
        {
            var summaries = new[] 
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            }; 

            var rng = new Random();

            return Result<IEnumerable<WeatherForecast>>.Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = new Random().Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            }).ToArray()); 
        }
    }
}