using Microsoft.EntityFrameworkCore;
namespace NutritionApp.Models;

public class SampleStoreContext : DbContext
{
    public SampleStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Sample> Samples { get; set; }
}