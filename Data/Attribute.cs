using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaWebtool2.Data;

public class Attribute
{
    public Guid AttributeId { get; set; }
    
    public string? AttributeName { get; set; }
    
    public string? AttributeType { get; set; }
    
    public string? AttributeDescription { get; set; }
    
    public string? DataType { get; set; }
    
    public List<string>? ValueSet { get; set; }
    
    public List<Algorithm>? Algorithms { get; set; } // Navigation Property
    
    
    public class AttributConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasKey(a => a.AttributeId);
            builder.Property(a => a.AttributeName).IsRequired();
        }
    }

}