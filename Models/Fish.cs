using System.ComponentModel.DataAnnotations.Schema;

namespace cloud_fishing.Models;

public class Fish 
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int FishId { get; set; }
    public string? Name { get; set; }
    public string? Size { get; set; }

    public int MinTemperature { get; set; }
    public int MaxTemperature { get; set; }

    public int FlyId { get; set; }
    public Fly? Fly { get; set; }

}