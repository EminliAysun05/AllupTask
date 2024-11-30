using Microsoft.AspNetCore.Identity;

namespace Allup.Domain.Entities;

public class AppUser : IdentityUser
{
    public required string FullName { get; set; }
}
