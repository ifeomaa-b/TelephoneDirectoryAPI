using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserByEmailController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public GetUserByEmailController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("{email}")]
        public async Task <IActionResult> GetUserById(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new {Message = "User not found."});
            }
            return Ok($"Great news!, User '{user.UserName}' was found");
        }
    }
}
