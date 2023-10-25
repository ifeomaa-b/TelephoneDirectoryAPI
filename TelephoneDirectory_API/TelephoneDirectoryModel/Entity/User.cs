using Microsoft.AspNetCore.Identity;

namespace TelephoneDirectoryModel.Entity
{
    public class User : IdentityUser
    {
        public string? ImageUrl { get; set; }

    }
}
