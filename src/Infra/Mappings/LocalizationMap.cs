using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class LocalizationMap : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
             builder.Property(x => x.Latitude)
                .IsRequired()
                .HasColumnName("Latitude");

            builder.Property(x => x.Longitude)
                .IsRequired()
                .HasColumnName("Longitude");
        }
    }
}