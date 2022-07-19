using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHome")]
        public async Task<string> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://data-app.default.svc.cluster.local:8080/weatherforecast");
                return "Text from client: " + await response.Content.ReadAsStringAsync();
            }
        }
    }
}