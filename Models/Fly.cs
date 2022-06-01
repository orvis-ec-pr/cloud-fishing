using System.ComponentModel.DataAnnotations.Schema;

namespace cloud_fishing.Models;

public class Fly
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int FlyId { get; set; }
    public string? Name { get; set; }
    public int Size { get; set; }

}
