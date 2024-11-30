using Microsoft.AspNetCore.Identity;

namespace Academy.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public required string FullName { get; set; }


    }
}
