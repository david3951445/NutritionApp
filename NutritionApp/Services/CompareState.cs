namespace NutritionApp.Services;

public class CompareState
{
    public SearchState SearchState { get; set; } = new();
    public Sample? Sample1 { get; set; }
    public Sample? Sample2 { get; set;}
}
