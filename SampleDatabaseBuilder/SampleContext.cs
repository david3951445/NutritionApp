using Microsoft.EntityFrameworkCore;
using UtilsLibrary;

public class SamplesContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }
    public string DbPath { get; }

    public SamplesContext()
    {
        string folderPath = Path.Join(Utils.SolutionPath, "FdaNutritionData");
        DbPath = Path.Join(folderPath, "Samples.db");
    }

    public SamplesContext(DbContextOptions<SamplesContext> options) : base(options) { }

    /// <summary>
    /// The following configures EF to create a Sqlite database file.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public record Sample
{
    public int SampleId { get; set;}
    public string 整合編號 { get; set; }
    public string 樣品名稱 { get; set; }
    public string 俗名 { get; set; }
    public string 樣品英文名稱 { get; set; }
    public string 內容物描述 { get; set; }

    public ICollection<AnalysisItemCatagory> AnalysisItemCatagories { get; init; }
}

public record AnalysisItemCatagory
{
    public int AnalysisItemCatagoryId { get; set; }
    public string 分析項分類 { get; set; }

    public int SampleId { get; set;}
    public Sample Sample { get; set; }

    public ICollection<AnalysisItem> AnalysisItems { get; set; }
}

public record AnalysisItem
{
    public int AnalysisItemId { get; set; }
    public string 分析項 { get; set; }
    public string 單位 { get; set; }
    public string 每100克含量 { get; set; }
    //每單位重(0.0克)含量x1

    public int AnalysisItemCatagoryId { get; set; }
    public AnalysisItemCatagory AnalysisItemCatagory { get; set; }
}
