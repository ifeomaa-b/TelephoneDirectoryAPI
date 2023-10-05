using Microsoft.AspNetCore.Identity;

namespace ContactBook_API.Models
{
    public class User : IdentityUser
    {
        public string ImageUrl { get; set; }

    }
}
