using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaWebtool2.Data;

[EntityTypeConfiguration(typeof(AlgorithmConfiguration))]
public class Algorithm
{
    public Guid AlgorithmId { get; set; }
    
    public AlgorithmCategory Category { get; set; }

    [Required]
    public string AlgorithmName { get; set; } = default!;
    
    public string? AlgorithmDescription { get; set; }

    [Required]
    public string Author { get; set; } = default!;
    
    public string? ImageUrl { get; set; } 
    
    public ICollection<string> Constraints { get; set; } = new List<string>();
    
    public ICollection<string> Derivations { get; set; } = new List<string>();

    public List<DataPoint> DataPoints { get; set; } = []; // Navigation Property
    
    
    
    public enum AlgorithmCategory
    {
        Head,
        Lungs,
        Eyes,
        Metabolism,
        Sepsis,
        Medication,
        Mortality,
        Other,
        AllCategories,
    }
}

file class AlgorithmConfiguration : IEntityTypeConfiguration<Algorithm>
{
    public void Configure(EntityTypeBuilder<Algorithm> builder)
    {
        builder.HasKey(algorithm => algorithm.AlgorithmId);
        
    }
}

public static class AlgorithmExtensions
{
    public static string GetDisplayName(this Algorithm.AlgorithmCategory category)
    {
        return category switch
        {
            Algorithm.AlgorithmCategory.Head => "Diseases and malformations of the brain and skull",
            Algorithm.AlgorithmCategory.Lungs => "Diseases and treatments of the lungs",
            Algorithm.AlgorithmCategory.Eyes => "Eye diseases",
            Algorithm.AlgorithmCategory.Metabolism => "Nutrition and metabolism",
            Algorithm.AlgorithmCategory.Sepsis => "Sepsis",
            Algorithm.AlgorithmCategory.Medication => "Medication",
            Algorithm.AlgorithmCategory.Mortality => "Mortality / hospitalization / disease severity",
            Algorithm.AlgorithmCategory.Other => "Others",
            Algorithm.AlgorithmCategory.AllCategories => "All categories",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
    
    public static string GetIcon(this Algorithm.AlgorithmCategory category)
    {
        return category switch
        {
            Algorithm.AlgorithmCategory.Head => "oi oi-person",
            Algorithm.AlgorithmCategory.Lungs => "oi oi-heart",
            Algorithm.AlgorithmCategory.Eyes => "oi oi-eye",
            Algorithm.AlgorithmCategory.Metabolism => "oi oi-loop-circular",
            Algorithm.AlgorithmCategory.Sepsis => "oi oi-eyedropper",
            Algorithm.AlgorithmCategory.Medication => "oi oi-beaker",
            Algorithm.AlgorithmCategory.Mortality => "oi oi-pulse",
            Algorithm.AlgorithmCategory.Other => "oi oi-excerpt",
            Algorithm.AlgorithmCategory.AllCategories => "oi oi-check",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }

    public static string GetTitle(this Algorithm.AlgorithmCategory category)
    {
        return category switch
        {
            Algorithm.AlgorithmCategory.Head => "Algorithms for diseases and malformations of the brain and skull",
            Algorithm.AlgorithmCategory.Lungs => "Algorithms for diseases and treatments of the lungs",
            Algorithm.AlgorithmCategory.Eyes => "Algorithms for eye diseases",
            Algorithm.AlgorithmCategory.Metabolism => "Algorithms for the category nutrition and metabolism",
            Algorithm.AlgorithmCategory.Sepsis => "Algorithms for Sepsis detection and prediction",
            Algorithm.AlgorithmCategory.Medication => "Algorithms for medication",
            Algorithm.AlgorithmCategory.Mortality => "Algorithms for the category Mortality / hospitalization / disease severity",
            Algorithm.AlgorithmCategory.Other => "Other Algorithms",
            Algorithm.AlgorithmCategory.AllCategories => "All algorithms",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
    
    // Methode für Beschreibung der Kategorie
}