using System;

namespace HighSkill.API;

public class WeatherForecast
{
    public DateTime Date { get; set; }  // Заменили DateOnly на DateTime
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }  // Добавили ? для nullable
}