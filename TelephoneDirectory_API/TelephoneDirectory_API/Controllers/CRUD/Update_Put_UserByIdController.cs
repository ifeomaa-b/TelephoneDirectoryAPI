using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory_API.ViewModels;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class Update_Put_UserByIdController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public Update_Put_UserByIdController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("update/{id}")]

        public async Task<IActionResult> UpdateUser(string id, [FromBody] Put model)
        {
            var user = await _userManager.FindByNameAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = model.Password;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Failed to update user." });

            }

            return Ok(new { Message = "User updated successfully." });
        }

    }
}
