using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserByIdController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public GetUserByIdController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);    
            if (user == null)
            {
                return NotFound(new {Message = "User not found"});

            }
            return Ok($"Great news! User '{user.UserName}' was found.");
        }
    }
}
