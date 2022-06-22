using CloudFishing.Models;
using System;
using System.Linq;

namespace CloudFishing.Data
{

    public static class DbInitializer
    {
        public static void CreateDbIfNotExists(IHost host) {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try{
                    var context = services.GetRequiredService<CloudFishingContext>();
                    DbInitializer.Initialize(context);
                }
                catch(Exception ex) 
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        public static void Initialize (CloudFishingContext context) {
            context.Database.EnsureCreated();

            // Look for any fish.  If there are some, we are already stocked.
            if ((context.Fish != null) && context.Fish.Any()) {
                return; // we don't need to stock the database.
            }

            var flies = new Fly[]
            {
                new Fly{FlyId=1,Name="Parachute Adams",Size=20},
                new Fly{FlyId=2,Name="BWO Sparkle Dun",Size=16},
                new Fly{FlyId=3,Name="Elk Caddis",Size=12},
                new Fly{FlyId=4,Name="Chernobyl Ant",Size=8}
            };
            foreach(Fly f in flies) {
                if (context.Flies != null) context.Flies.Add(f);
            }
            context.SaveChanges();

            var fish = new Fish[] 
            {
                new Fish{FishId=1,Name="Rainbow Trout",Size="Medium",MinTemperature=40,MaxTemperature=60,FlyId=2},
                new Fish{FishId=2,Name="Brook Trout",Size="Small",MinTemperature=40,MaxTemperature=60,FlyId=1},
                new Fish{FishId=3,Name="Golden Trout",Size="Small",MinTemperature=45,MaxTemperature=65,FlyId=1},
                new Fish{FishId=4,Name="Brown Trout",Size="Large",MinTemperature=35,MaxTemperature=65,FlyId=3},
                new Fish{FishId=5,Name="Lake Trout",Size="Large",MinTemperature=40,MaxTemperature=60,FlyId=3},
                new Fish{FishId=6,Name="Arctic Char",Size="Medium",MinTemperature=40,MaxTemperature=60,FlyId=4}
            };
            foreach (Fish f in fish) {
                if (context.Fish != null) context.Fish.Add(f);
            }
            context.SaveChanges();

            var summaries = new string[] { "clear", "blustery", "cloudy", "rainy", "stormy" };
            var weather = new Weather[] {
                new Weather{TemperatureC=10,Summary="Clear"},
                new Weather{TemperatureC=12,Summary="Blustery"},
                new Weather{TemperatureC=16,Summary="Cloudy"},
                new Weather{TemperatureC=2,Summary="Rainy"},
                new Weather{TemperatureC=38,Summary="Stormy"}
            };
            foreach(Weather w in weather) {
                if (context.Weather != null) context.Weather.Add(w);
            }
            context.SaveChanges();

        }
    }
}