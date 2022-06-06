using System.Text.Json.Serialization;

namespace ThreadDemo.Models;

public class WeatherForecastDTO
{
    public DateTime Date { get; set; }

    [JsonPropertyName("temperature_c")]
    public int TemperatureC { get; set; }

    [JsonPropertyName("temperature_f")]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
