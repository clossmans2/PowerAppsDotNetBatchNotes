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
        public async Task<ContentResult> GetDogs(string? content)
        {
            var options = new RestClientOptions("https://dog.ceo/api/breeds/image/random");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            var response = await client.GetAsync(request);
#pragma warning disable CS8604 // Possible null reference argument.
            JsonObject? json = JsonSerializer.Deserialize<JsonObject>(response.Content);
#pragma warning restore CS8604 // Possible null reference argument.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string img = json["message"].ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var html = $"<html><body><img src='{img}' /></body></html>";

            return new ContentResult
            {
                ContentType = "text/html",
                Content = html
            };
        }
    }
}