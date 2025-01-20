namespace NutritionApp.Services;

public class SearchState
{
    public List<Sample> Samples { get; set; } = [];
    public string Catagory { get; set; } = "全部";
    public string? Keyword { get; set; }
}
