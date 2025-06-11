using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaWebtool2.Data;

[EntityTypeConfiguration(typeof(AlgAttributeConfiguration))]
public class AlgAttribute
{
    public Guid AttributeId { get; set; }
    
    [Required(ErrorMessage = "The designation of the attribute is required.")]
    public string AttributeName { get; set; }
    
    public string? AttributeType { get; set; }
    
    public string? AttributeDescription { get; set; }
    
    [Required(ErrorMessage = "The datatype of the attribute is required.")]
    public string DataType { get; set; }
    
    public List<string>? ValueSet { get; set; }
    
    public List<Algorithm> Algorithms { get; set; } // Navigation Property
    
    
    public class AlgAttributeConfiguration : IEntityTypeConfiguration<AlgAttribute>
    {
        public void Configure(EntityTypeBuilder<AlgAttribute> builder)
        {
            builder.HasKey(a => a.AttributeId);
            builder.Property(a => a.AttributeName).IsRequired();
        }
    }

}