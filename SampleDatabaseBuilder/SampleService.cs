namespace SampleDatabaseBuilder.Services;

public class SampleService
{
    public static IEnumerable<Sample> ConvertToSamples(IEnumerable<RowData> rowDatas) =>
        from rowData in rowDatas
        group rowData by rowData.整合編號 into grouped
        let first = grouped.First()
        select new Sample
        {
            整合編號 = grouped.Key,
            樣品名稱 = first.樣品名稱,
            俗名 = first.俗名,
            樣品英文名稱 = first.樣品英文名稱,
            內容物描述 = first.內容物描述,
            AnalysisItemCatagories =
                (from row in grouped
                 group row by row.分析項分類 into groupedItemCatagory
                 select new AnalysisItemCatagory
                 {
                     分析項分類 = groupedItemCatagory.Key,
                     AnalysisItems = groupedItemCatagory
                         .Select(c => new AnalysisItem
                         {
                             分析項 = c.分析項,
                             單位 = c.含量單位,
                             每100克含量 = c.每100克含量
                         }).ToList()
                 }).ToList()
        };
}