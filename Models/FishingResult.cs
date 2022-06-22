namespace CloudFishing.Models;
public class FishingResult
{
    public Boolean Success { get; set; }
    public Fish? Fish { get; set; }
    public Fly? Fly { get; set; }
    public Weather? Weather { get; set; }
}