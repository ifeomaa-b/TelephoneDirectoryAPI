using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteUserByIdController : ControllerBase 
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserByIdController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpDelete("delete/{id}")]
        public async Task  <IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new {Message = "User not found."});
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Failed to delete user." });

            }
            return Ok(new {Message = "User deleted successfully"});
        }
    }
}
