using Microsoft.AspNetCore.Mvc;

namespace DataApp.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            string result = string.Empty;

            //using (var streamReader = new StreamReader("/result/Resources/TextFile.txt"))
            //{
            //    result = streamReader.ReadToEnd();
            //}

            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5001/Text");
                result = result + await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}