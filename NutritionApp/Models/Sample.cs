namespace NutritionApp.Models;

public record Sample(
    string 整合編號,
    string 樣品名稱,
    string 俗名,
    string 樣品英文名稱,
    string 內容物描述,
    AnalysisItemCatagory[] AnalysisItemCatagories);

public record struct AnalysisItemCatagory(
    string 分析項分類,
    AnalysisItem[] AnalysisItems);

public record struct AnalysisItem(
    string 分析項,
    string 單位,
    string 每100克含量);
//每單位重(0.0克)含量x1
