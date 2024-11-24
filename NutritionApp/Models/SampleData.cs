namespace NutritionApp.Models
{
    public class SampleData
    {
        public string 整合編號 { get; set; }
        public string 樣品名稱 { get; set; }
        public string 俗名 { get; set; }
        public string 樣品英文名稱 { get; set; }
        public string 內容物描述 { get; set; }
        public NutritionalFact NutritionalFact { get; set; }
    }

    public record struct NutritionalFact(string 分析項分類, string 分析項, string 單位, string 每100克含量);
    //每單位重(0.0克)含量x1
}
