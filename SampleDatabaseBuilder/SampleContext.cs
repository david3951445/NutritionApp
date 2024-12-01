using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UtilsLibrary;

public class SamplesContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }
    public DbSet<AnalysisItem> AnalysisItems { get; set; }
    public DbSet<AnalysisItemCatagoryInfo> AnalysisItemCatagoryInfos { get; set; }
    public DbSet<AnalysisItemInfo> AnalysisItemInfos { get; set; }
    public DbSet<FoodCatagory> FoodCatagories { get; set; }
    public string DbPath { get; }

    public SamplesContext() : this(new DbContextOptions<SamplesContext>()) { }

    public SamplesContext(DbContextOptions<SamplesContext> options) : base(options)
    {
        string folderPath = Path.Join(Utils.SolutionPath, "FdaNutritionData");
        DbPath = Path.Join(folderPath, "Samples.db");
        // if (!File.Exists(DbPath))
        //     throw new FileNotFoundException($"The database at {DbPath} does not exist.", DbPath);
    }

    /// <summary>
    /// The following configures EF to create a Sqlite database file.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options
        .UseSqlite($"Data Source={DbPath}")
        .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var converter = new ValueConverter<Unit, string>(
            v => v.GetDescription() ?? v.ToString(),
            v => EnumExtensions.ParseOrDefault<Unit>(v));

        modelBuilder
            .Entity<AnalysisItemInfo>()
            .Property(e => e.Unit)
            .HasConversion(converter);
    }
}

public class Sample
{
    /// <summary>
    /// 整合編號
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 樣品名稱
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 俗名
    /// </summary>
    public string CommonName { get; set; }
    /// <summary>
    /// /// 樣品英文名稱
    /// </summary>
    public string EnglishName { get; set; }
    /// <summary>
    /// 內容物描述
    /// </summary>
    public string ContentDescription { get; set; }

    public string FoodCatagoryId { get; set; }
    /// <summary>
    /// 食品分類
    /// </summary>
    public FoodCatagory FoodCatagory { get; set; }
    public ICollection<AnalysisItem> AnalysisItems { get; set; }
}

// public class AnalysisItemCatagory
// {
//     public int AnalysisItemCatagoryId { get; set; }
//     /// <summary>
//     /// 分析項分類
//     /// </summary>
//     public string Name { get; set; }

//     public ICollection<AnalysisItem> AnalysisItems { get; set; }
// }

public class AnalysisItem
{
    public int Id { get; set; }
    [Display(Name = "每100g含量")]
    public string Value { get; set; }
    // 每單位重
    // 每單位重(0.0克)含量x1

    // public int AnalysisItemInfoId { get; set; }
    public AnalysisItemInfo AnalysisItemInfo { get; set; }
    public string SampleId { get; set; }
    public Sample Sample { get; set; }
}

public class FoodCatagory
{
    public string Id { get; set; }
    public string Name { get; set; }
}
