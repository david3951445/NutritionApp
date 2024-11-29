using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class AnalysisItemInfo
{
    public int Id { get; set; }
    /// <summary>
    /// 分析項
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 含量單位
    /// </summary>
    [Display(Name = "單位")]
    public Unit Unit { get; set; }
    // public string? Description { get; set;}

    // public int AnalysisItemId { get; set; }
    // public AnalysisItem AnalysisItem { get; set; }
    public int AnalysisItemCatagoryInfoId { get; set; }
    public AnalysisItemCatagoryInfo AnalysisItemCatagoryInfo { get; set; }
}

public class AnalysisItemCatagoryInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    // public string? Description { get; set;}

    public ICollection<AnalysisItemInfo> AnalysisItemInfos { get; set; }
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