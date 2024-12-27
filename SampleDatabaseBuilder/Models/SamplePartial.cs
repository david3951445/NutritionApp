public partial class Sample
{
    public Dictionary<string, AnalysisItem[]> AnalysisItemsByCatagory => AnalysisItems
        .GroupBy(x => x.AnalysisItemInfo.AnalysisItemCatagoryInfo.Name)
        .OrderBy(g => g.First().AnalysisItemInfo.AnalysisItemCatagoryInfo.DisplayOrder)
        .ToDictionary(g => g.Key, g => g
        .OrderBy(ai => ai.AnalysisItemInfo.DisplayOrder)
        .ToArray());
}
