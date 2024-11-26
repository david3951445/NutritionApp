using NutritionApp.Services;
namespace NutritionApp.Models;

public record Sample(
    string 整合編號,
    string 樣品名稱,
    string 俗名,
    string 樣品英文名稱,
    string 內容物描述,
    AnalysisItemCatagory[] AnalysisItemCatagories)
{
    public static IEnumerable<Sample> ConvertToSamples(IEnumerable<RowData> rowDatas) =>
        from rowData in rowDatas
        group rowData by rowData.整合編號 into grouped
        let first = grouped.First()
        select new Sample(
            整合編號: grouped.Key,
            樣品名稱: first.樣品名稱,
            俗名: first.俗名,
            樣品英文名稱: first.樣品英文名稱,
            內容物描述: first.內容物描述,
            AnalysisItemCatagories: grouped
                .Select(row => new AnalysisItemCatagory(
                     row.分析項分類,
                     new AnalysisItem(row.分析項, row.含量單位, row.每100克含量)
                 ))
                 .ToArray()
        );
}

public record struct AnalysisItemCatagory(string 分析項分類, AnalysisItem AnalysisItem);
public record struct AnalysisItem(string 分析項, string 單位, string 每100克含量);
//每單位重(0.0克)含量x1
