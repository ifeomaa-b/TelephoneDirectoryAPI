using System.ComponentModel.DataAnnotations;

namespace TelephoneDirectoryModel.ModelView
{
    public class LoginUser
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
