using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enuns;

namespace Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasColumnType("INT")
                .HasConversion(
                    status => (int)status,
                    value => (Status)value);

            builder.Property(x => x.City)
                .HasMaxLength(180)
                .HasColumnName("city")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Informations)
                .HasMaxLength(250)
                .HasColumnName("informations")
                .HasColumnType("VARCHAR(250)");

            builder.OwnsOne(x => x.Localization, loc =>
            {
                loc.Property(l => l.Latitude)
                    .HasColumnName("Latitude");

                loc.Property(l => l.Longitude)
                    .HasColumnName("Longitude");
            });

        }
    }
}