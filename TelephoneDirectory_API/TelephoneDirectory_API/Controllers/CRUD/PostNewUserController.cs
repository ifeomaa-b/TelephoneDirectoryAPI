using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers.CRUD

{
    [ApiController]
    [Route("api/[controller]")]
    public class PostNewUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public PostNewUserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("add-new")]
        public async Task<IActionResult> AddNewUser([FromBody] PostNewUser model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

                return BadRequest(ModelState);
            }
            return Ok(new { Message = "User created Successfully" });
        }
    }
}
