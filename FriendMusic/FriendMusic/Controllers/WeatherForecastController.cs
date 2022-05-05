using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FriendMusic.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("Dogs")]
        public async Task<ContentResult> GetDogs()
        {
            var options = new RestClientOptions("https://dog.ceo/api/breeds/image/random");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            var response = await client.GetAsync(request);
            var content = response.Content;
            var json = JsonSerializer.Deserialize<JsonObject>(content);

            string img = json["message"].ToString();
            var html = $"<html><body><img src='{img}' /></body></html>";

            return new ContentResult
            {
                ContentType = "text/html",
                Content = html
            };
        }
    }
}