using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaWebtool2.Data;

[EntityTypeConfiguration(typeof(DataPointConfiguration))]
public class DataPoint
{
    public Guid DataPointId { get; set; }
    public List<Algorithm> Algorithms { get; set; } // Navigation Property
    
    [Required(ErrorMessage = "The designation of the datapoint is required.")]
    public string DataPointName { get; set; }
    
    public string? DataPointDescription { get; set; }

    [Required(ErrorMessage = "Selecting whether it is an atomic attribute is required.")]
    public bool AtomicAttribute { get; set; } // atomic, multi-valued, derived (maybe if derived point to attributes)
    
    public List<string>? ValueSet { get; set; }

    [Required(ErrorMessage = "The category is required.")]
    public DataPointCategory? Category { get; set; } //enum? 

    public string? PatientType { get; set; } // mother, child 
    
    
    public enum DataPointCategory
    {
        MasterData,
        BirthData,
        VitalSigns,
        BreathingData,
        CardiovascularData,
        NutritionalData,
        DevelopmentData,
        Diagnosis,
        Treatments,
        LaboratoryData,
        ImagingData
    }

}

file sealed class DataPointConfiguration : IEntityTypeConfiguration<DataPoint>
{
    public void Configure(EntityTypeBuilder<DataPoint> builder)
    {
        builder.HasKey(datapoint => datapoint.DataPointId);
        // Optional: lege hier Default-Werte fest, falls du Sie auch auf DB‑Seite sicherstellen willst:
        builder.Property(d => d.DataPointName).HasDefaultValue(string.Empty).IsRequired();
        builder.Property(d => d.DataPointDescription).HasDefaultValue(string.Empty).IsRequired();
    }
}
public static class DataPointExtensions
{
    public static string GetDisplayName(this DataPoint.DataPointCategory category)
    {
        return category switch
        {
            DataPoint.DataPointCategory.MasterData => "Master data",
            DataPoint.DataPointCategory.BirthData => "Birth data",
            DataPoint.DataPointCategory.VitalSigns => "Vital signs",
            DataPoint.DataPointCategory.BreathingData => "Breathing data",
            DataPoint.DataPointCategory.CardiovascularData => "Data on the cardiovascular system",
            DataPoint.DataPointCategory.NutritionalData => "Nutritional data",
            DataPoint.DataPointCategory.DevelopmentData => "Data on the child's development",
            DataPoint.DataPointCategory.Diagnosis => "Diagnosis",
            DataPoint.DataPointCategory.Treatments => "Treatments",
            DataPoint.DataPointCategory.LaboratoryData => "Laboratory data",
            DataPoint.DataPointCategory.ImagingData => "Data from imaging procedures",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
    
    // Methode für Beschreibung der Kategorie
}

