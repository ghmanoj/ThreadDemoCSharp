using Microsoft.AspNetCore.Mvc;

using ThreadDemo.Services;
using ThreadDemo.Models;

namespace ThreadDemo.Controllers;

[Route("/")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private static string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecastDTO> Get()
    {

        return Enumerable.Range(1, 5).Select(index => new WeatherForecastDTO
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
