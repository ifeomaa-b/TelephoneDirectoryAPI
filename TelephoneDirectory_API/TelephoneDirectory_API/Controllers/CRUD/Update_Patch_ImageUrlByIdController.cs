using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    public class Update_Patch_ImageUrlByIdController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public Update_Patch_ImageUrlByIdController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

    }
}
