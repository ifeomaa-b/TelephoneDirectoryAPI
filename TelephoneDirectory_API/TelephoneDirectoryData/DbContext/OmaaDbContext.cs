using ContactBook_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TelephoneDirectory_API.Models.DbContext   
{
    public class OmaaDbContext : IdentityDbContext<User>
    {
        public OmaaDbContext(DbContextOptions<OmaaDbContext> options) : base(options)
        {

        }

    }
}
