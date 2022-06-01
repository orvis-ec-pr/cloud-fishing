using Microsoft.AspNetCore.Mvc;
using cloud_fishing.Models;
using cloud_fishing.Data;

namespace cloud_fishing.Controllers;

[ApiController]
[Route("[controller]")]
public class FishingController : ControllerBase
{
    private readonly ILogger<FishingController> _logger;

    private readonly CloudFishingContext _context;

    public FishingController(ILogger<FishingController> logger, CloudFishingContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetWeather")]
    public IEnumerable<Weather> GetWeather()
    {
        if (_context.Weather == null) return new Weather[]{};
        return _context.Weather.AsEnumerable();
    }

    [HttpGet("GetFish")]
    public IEnumerable<Fish> GetFish()
    {
        if (_context.Fish == null) return new Fish[]{};
        return _context.Fish.AsEnumerable();
    }

    [HttpGet("GetFlies")]
    public IEnumerable<Fly> GetFlies()
    {
        if (_context.Flies == null) return new Fly[]{};
        return _context.Flies.AsEnumerable();
    }

    [HttpGet("/TryFishing")]
    [HttpGet("/")]
    public FishingResult GoFish()
    {
        Weather myWeather = CurrentWeather();
        Fly myFly = CurrentFly();
        Fish myFish = CurrentFish();
        FishingResult myResult = new FishingResult{Success=false,Fish=myFish,Fly=myFly,Weather=myWeather};
        
        if ((myFish.MinTemperature < myWeather.TemperatureF) && (myFish.MinTemperature < myFish.MaxTemperature))
        {
            if ((myFish.Fly != null) && myFish.Fly.Equals(myFly)) {
                myResult.Success = true;
            }
        }

        return myResult;
    }

    private Weather CurrentWeather() {
        if (_context.Weather == null) return new Weather{WeatherId=99,TemperatureC=99,Summary="Hot like Venus"};
        return _context.Weather.ToList<Weather>().ElementAt(Random.Shared.Next(1,_context.Weather.Count()) - 1);
    }

    private Fish CurrentFish() {
        if (_context.Fish == null) return new Fish{FishId=99,Name="Bonefish",Size="Very Large",MinTemperature=60,MaxTemperature=80};
        return _context.Fish.ToList<Fish>().ElementAt(Random.Shared.Next(1,_context.Fish.Count()) - 1);
    }

    private Fly CurrentFly() {
        if (_context.Flies == null) return new Fly{FlyId=99,Name="Royal Wulff",Size=18};
        return _context.Flies.ToList<Fly>().ElementAt(Random.Shared.Next(1,_context.Flies.Count()) - 1);
    }
}
