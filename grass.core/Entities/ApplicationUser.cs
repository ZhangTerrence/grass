using Microsoft.AspNetCore.Identity;

namespace grass.core.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public required string Description { get; set; }
}