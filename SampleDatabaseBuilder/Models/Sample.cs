using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Sample
{
    /// <summary>
    /// 整合編號
    /// </summary>
    public string Id { get; set; } = null!;
    /// <summary>
    /// 樣品名稱
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 俗名
    /// </summary>
    public string? CommonName { get; set; }
    /// <summary>
    /// /// 樣品英文名稱
    /// </summary>
    public string? EnglishName { get; set; }
    /// <summary>
    /// 內容物描述
    /// </summary>
    public string? ContentDescription { get; set; }

    public string FoodCatagoryId { get; set; } = null!;
    /// <summary>
    /// 食品分類
    /// </summary>
    public FoodCatagory FoodCatagory { get; set; } = null!;
    public ICollection<AnalysisItem> AnalysisItems { get; set; } = [];
}

public class FoodCatagory
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}

public class AnalysisItem
{
    public int Id { get; set; }
    /// <summary>
    /// 每100g含量
    /// </summary>
    [Display(Name = "每100g含量")]
    public string? Value { get; set; }
    // 每單位重
    // 每單位重(0.0克)含量x1

    // public int AnalysisItemInfoId { get; set; }
    public AnalysisItemInfo AnalysisItemInfo { get; set; } = null!;
    public string SampleId { get; set; } = null!;
    public Sample Sample { get; set; } = null!;
}

public class AnalysisItemInfo
{
    public int Id { get; set; }
    /// <summary>
    /// 分析項
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 含量單位
    /// </summary>
    [Display(Name = "單位")]
    public Unit Unit { get; set; }
    // public string? Description { get; set;}

    // public int AnalysisItemId { get; set; }
    // public AnalysisItem AnalysisItem { get; set; }
    public int AnalysisItemCatagoryInfoId { get; set; }
    public AnalysisItemCatagoryInfo AnalysisItemCatagoryInfo { get; set; } = null!;
}

public class AnalysisItemCatagoryInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    // public string? Description { get; set;}

    public ICollection<AnalysisItemInfo> AnalysisItemInfos { get; set; } = [];
}

public enum Unit
{
    None,
    kcal,
    g,
    mg,
    ug,
    [Description("I.U.")]
    I_U_,
}