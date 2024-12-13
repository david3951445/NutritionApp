namespace SampleDatabaseBuilder.Services;

public static class SampleService
{
    public static IEnumerable<Sample> ConvertToSamples(IEnumerable<RowData> rowDatas) =>
        from rowData in rowDatas
        group rowData by rowData.整合編號 into grouped
        let first = grouped.First()
        select new Sample
        {
            Id = grouped.Key,
            Name = first.樣品名稱,
            CommonName = first.俗名,
            EnglishName = first.樣品英文名稱,
            ContentDescription = first.內容物描述,
            // FoodCatagory = first.食品分類,
            // AnalysisItemCatagories =
            //     (from row in grouped
            //      group row by row.分析項分類 into groupedItemCatagory
            //      select new AnalysisItemCatagory
            //      {
            //          Name = groupedItemCatagory.Key,
            //          AnalysisItems = groupedItemCatagory
            //              .Select(c => new AnalysisItem
            //              {
            //                  AnalysisItemInfo = new AnalysisItemInfo
            //                  {
            //                      Name = c.分析項,
            //                      Unit = EnumExtensions.ParseOrDefault<Unit>(c.含量單位)
            //                  },
            //                  Value = c.每100克含量
            //              }).ToList()
            //      }).ToList()
        };

    public static AnalysisItem? GetAnalysisItem(this Sample sample, string name) =>
        sample?.AnalysisItems.FirstOrDefault(ai => ai.AnalysisItemInfo.Name == name);

    public static IEnumerable<AnalysisItem> GetAnalysisItems(this Sample sample, string name) =>
        sample?.AnalysisItems?.Where(ai => ai.AnalysisItemInfo.AnalysisItemCatagoryInfo.Name == name) ?? Enumerable.Empty<AnalysisItem>();

    public static double? GetValueInMg(this AnalysisItem item)
    {
        switch (item.AnalysisItemInfo.Unit)
        {
            case Unit.g:
                return double.TryParse(item.Value, out double valueInG) ? valueInG * 1000 : null;
            case Unit.mg:
                return double.TryParse(item.Value, out double valueInMg) ? valueInMg : null;
            case Unit.ug:
                return double.TryParse(item.Value, out double valueInUg) ? valueInUg / 1000 : null;
            default:
                return null;
        }
    }
}