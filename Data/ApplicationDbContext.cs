using Microsoft.EntityFrameworkCore;

namespace BaWebtool2.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Algorithm> Algorithms { get; set; }
    public virtual DbSet<DataPoint> DataPoints { get; set; }
    public virtual DbSet<AlgAttribute> Attributes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = algorithms.db"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataPoint>()
            .HasMany(dp => dp.Algorithms)
            .WithMany(a => a.DataPoints);
        
        modelBuilder.Entity<Algorithm>()
            .HasMany(a => a.Attributes)
            .WithMany(at => at.Algorithms);
        
    }

}