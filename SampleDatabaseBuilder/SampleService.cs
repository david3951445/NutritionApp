namespace SampleDatabaseBuilder.Services;

public class SampleService
{
    public static IEnumerable<Sample> ConvertToSamples(IEnumerable<RowData> rowDatas) =>
        from rowData in rowDatas
        group rowData by rowData.整合編號 into grouped
        let first = grouped.First()
        select new Sample
        {
            SampleId = grouped.Key,
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

}