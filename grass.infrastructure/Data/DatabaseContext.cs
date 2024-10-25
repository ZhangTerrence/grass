using grass.core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace grass.infrastructure.Data;

public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(e => e.ToTable("ApplicationUsers"));
        builder.Entity<IdentityUserLogin<Guid>>(e => e.ToTable("IdentityUserLogins"));
        builder.Entity<IdentityUserToken<Guid>>(e => e.ToTable("IdentityUserTokens"));
        builder.Entity<IdentityRole<Guid>>(e => e.ToTable("IdentityRoles"));
        builder.Entity<IdentityUserRole<Guid>>(e => e.ToTable("IdentityUserRoles"));
        builder.Entity<IdentityUserClaim<Guid>>(e => e.ToTable("IdentityUserClaims"));
        builder.Entity<IdentityRoleClaim<Guid>>(e => e.ToTable("IdentityRoleClaims"));

        builder.Entity<IdentityRole<Guid>>().HasData(
            new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole<Guid>
            {
                Id = Guid.NewGuid(),
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}