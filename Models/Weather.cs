namespace cloud_fishing.Models;
using Microsoft.EntityFrameworkCore;

public class Weather
{
    public int WeatherId { get; set; }
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

