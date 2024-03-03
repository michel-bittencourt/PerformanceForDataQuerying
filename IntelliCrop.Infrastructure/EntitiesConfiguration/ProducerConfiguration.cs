using IntelliCrop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelliCrop.Infrastructure.EntitiesConfiguration;

public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.Property(p => p.FirstName).IsRequired();
        builder.Property(p => p.LastName).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.PhoneNumber).IsRequired();
        builder.Property(p => p.Address).IsRequired();
    }
}
