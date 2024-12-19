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
