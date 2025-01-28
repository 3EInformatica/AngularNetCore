using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
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
        [HttpGet]
        [Route("GetWeatherForecast2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("Somma")]
        public Response<int> Somma(int a, int b)
        {
            var r= new Response<int>();
            r.Result = a + b;   
            r.Success = true;   
            r.Message = "Operazione eseguita correttamente";    
            return r;
        }

        [HttpPost]
        [Route("Prodotto")]
        public Response<int> Prodotto([FromForm] int a, [FromForm] int b)
        {
            var r = new Response<int>();
            r.Result = a * b;
            r.Success = true;
            r.Message = "Operazione eseguita correttamente";
            return r;
        }


        [HttpPost]
        [Route("Prodotto2")]
        public Response<int> Prodotto2([FromBody] RequestProdotto requestProdotto)
        {
            var r = new Response<int>();
            r.Result = requestProdotto.a * requestProdotto.b;
            r.Success = true;
            r.Message = "Operazione eseguita correttamente";
            return r;
        }
    }
}
