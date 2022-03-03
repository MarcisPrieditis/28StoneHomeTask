namespace _28stoneHomeworkAPI.Models;

public class SingleCountryModel
{
    public double Area { get; set; }
    public int Population { get; set; }
    public List<string>? TopLevelDomain { get; set; }
    public string? NativeName { get; set; }
}