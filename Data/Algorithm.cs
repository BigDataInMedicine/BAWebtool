using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaWebtool2.Data;

[EntityTypeConfiguration(typeof(AlgorithmConfiguration))]
public class Algorithm
{
    public Guid AlgorithmId { get; set; }
    
    public AlgorithmCategory Category { get; set; }

    [Required (ErrorMessage = "The designation of the algorithm is required.")]
    public string AlgorithmName { get; set; } = default!;
    
    public string? AlgorithmDescription { get; set; }

    [Required (ErrorMessage = "The author is required.")]
    public string Author { get; set; } = default!;
    
    [Required (ErrorMessage = "The year is required.")] 
    public int Year { get; set; } //Year of publication 
    
    [Required (ErrorMessage = "The displayed description is required.")] 
    public string  DisplayDescription { get; set; }
    
    public string MethodApproach { get; set; } //(data-driven or knowledge-based)
    
    public string LearningType { get; set; } //(if it's data-driven - supervised or unsupervised)
    
    public string? ModelUrl { get; set; } 
    
    public ICollection<string> Constraints { get; set; } = new List<string>();
    
    public ICollection<string> Derivations { get; set; } = new List<string>();

    public List<DataPoint> DataPoints { get; set; } = []; // Navigation Property
    
    public List<AlgAttribute> Attributes { get; set; } = new List<AlgAttribute>(); // Navigation Property
    
    
    
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
    public static string GetCategoryDescription(this Algorithm.AlgorithmCategory category)
    {
        return category switch
        {
            Algorithm.AlgorithmCategory.Head => "Algorithms supporting the diagnosis and analysis of neurological conditions and cranial malformations, including brain-related diseases.",
            Algorithm.AlgorithmCategory.Lungs => "Algorithms designed to assist in the detection, monitoring, and treatment planning of lung diseases and respiratory disorders.",
            Algorithm.AlgorithmCategory.Eyes => "Algorithms focused on identifying, classifying, and monitoring various eye diseases and vision-related impairments.",
            Algorithm.AlgorithmCategory.Metabolism => "Algorithms targeting disorders related to nutrition, hormonal balance, and metabolic function, including diabetes and obesity.",
            Algorithm.AlgorithmCategory.Sepsis => "Algorithms for early detection, risk evaluation, and outcome prediction in patients with suspected or confirmed sepsis.",
            Algorithm.AlgorithmCategory.Medication => "Algorithms that provide decision support for medication management, dosage recommendations, and drug interaction alerts.",
            Algorithm.AlgorithmCategory.Mortality => "Algorithms analyzing patient data to predict mortality risk, hospitalization likelihood, and disease severity progression.",
            Algorithm.AlgorithmCategory.Other => "A collection of algorithms that do not fit into the predefined categories but address specific or rare clinical scenarios.",
            Algorithm.AlgorithmCategory.AllCategories => "Access to the full range of medical algorithms across all supported clinical areas and diagnostic domains.",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
}