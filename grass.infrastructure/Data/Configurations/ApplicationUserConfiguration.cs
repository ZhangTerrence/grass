using grass.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grass.infrastructure.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.Id).HasColumnName("UserId");
        builder.Property(e => e.UserName).IsRequired().HasMaxLength(31);
        builder.Property(e => e.Description).HasDefaultValue("").HasMaxLength(255);
    }
}