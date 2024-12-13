namespace NutritionApp.Services;

public class SearchState
{
    public List<Sample> Samples { get; set; } = [];
    public string? SampleName { get; set; }
    public string? CommonName { get; set; }
    public string? Catagory { get; set; }
}
