using Microsoft.EntityFrameworkCore;

namespace BaWebtool2.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Algorithm> Algorithms { get; set; }
    public virtual DbSet<DataPoint> DataPoints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = algorithms.db"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataPoint>()
            .HasMany(dp => dp.Algorithms)
            .WithMany(a => a.DataPoints);
        
        // Seeding for Algorithms
        // modelBuilder.Entity<Algorithm>().HasData(
        //     new Algorithm()
        //     {
        //         AlgorithmId = "Gehirn01",
        //         Category = Algorithm.AlgorithmCategory.Head,
        //         AlgorithmName =
        //             "Application of Machine Learning Approaches to Predict Postnatal Growth Failure in Very Low Birth Weight Infants",
        //         AlgorithmDescription = "Description ...",
        //         Author = "Han et al.",
        //         ImageUrl =
        //             "img/Gehirn01-Application of Machine Learning Approaches to Predict Postnatal Growth Failure in Very Low Birth Weight Infants.png",
        //     },
        //     new Algorithm()
        //     {
        //         AlgorithmId = "Gehirn05",
        //         Category = Algorithm.AlgorithmCategory.Head,
        //         AlgorithmName = "Language function following preterm birth: prediction using machine learning ",
        //         AlgorithmDescription = "Description ...",
        //         Author = "Valvani et al.",
        //         ImageUrl = "img/Gehirn05-Language function following preterm birth.png"
        //     },
        //     new Algorithm()
        //     {
        //         AlgorithmId = "Lunge01",
        //         Category = Algorithm.AlgorithmCategory.Lung,
        //         AlgorithmName = "Bronchopulmonary dysplasia predicted at birth by artificial intelligence",
        //         AlgorithmDescription = "Description ...",
        //         Author = "Verder et al.",
        //         ImageUrl = "img/Lunge01-Bronchopulmonary dysplasia predicted at birth by artificial intelligence.png"
        //     },
        //     new Algorithm()
        //     {
        //         AlgorithmId = "Medikament01",
        //         Category = Algorithm.AlgorithmCategory.Medication,
        //         AlgorithmName =
        //             "An Artificial Intelligence Approach to Support Detection of Neonatal Adverse Drug Reactions Based on Severity and Probability Scores: A New Risk Score as Webtool ",
        //         AlgorithmDescription = "Description ...",
        //         Author = "Yalcin et al.",
        //         ImageUrl =
        //             "img/Medikament01-An Artificial Intelligence Approach to Support Detection of Neonatal Adverse Drug Reactions.png"
        //     }
        // );

        //Seeding for DataPoint
        // modelBuilder.Entity<DataPoint>().HasData(
        //     new DataPoint()
        //     {
        //         DataPointId = "Dp_Diagnose_Bezeichung",
        //         AlgorithmId = "Gehirn01",
        //         DataPointName = "Diagnose_Bezeichnung",
        //         DataPointDescription = "Bezeichnung der Diagnose in Form des Namens der Krankheit/der Störung/… ",
        //         AtomicAttribute = true
        //     }
        // );
        
    }
}