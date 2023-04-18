using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Services;
using System.Data.SQLite;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestauranteSustentavel_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        
        private readonly BebidaService bebidaService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, BebidaService bebidaService)
        { 
            _logger = logger;
            this.bebidaService = bebidaService;
        }

        [HttpGet("teste")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        

        [HttpGet("Bebida/GetAll")]
        public IEnumerable<Bebida> GetAll()
        {
            return bebidaService.GetAll();
        }

        [HttpPost("Bebida/Insert")]
        public Bebida Insert(Bebida bebida)
        {
            
            return bebidaService.Insert(bebida); 
        }

        [HttpPut("Bebida/Update")]
        public Bebida Update(Bebida bebida)
        {
            return bebidaService.Update(bebida);
        }

        [HttpDelete("Bebida/Delete")]
        public int Delete(int i)
        {
            return bebidaService.Delete(i);
        }
        

    }
}