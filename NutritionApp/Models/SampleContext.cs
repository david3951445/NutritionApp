using Microsoft.EntityFrameworkCore;
using NutritionApp.Services;

namespace NutritionApp.Models;

public class SampleContext : DbContext
{
    public DbSet<Sample> Samples { get; set; }
    public string DbPath { get; }

    public SampleContext()
    {
        string folderPath = Path.Join(SampleService.SolutionPath, "FdaNutritionData");
        DbPath = Path.Join(folderPath, "blogging.db");
    }
    
    // The following configures EF to create a Sqlite database file.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}