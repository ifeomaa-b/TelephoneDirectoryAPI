using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory_API.Models.ViewModels;
using TelephoneDirectoryCore.Implementation.IServices.IAuth;

namespace ContactBookApi.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IRegister _register;

        public RegisterController(UserManager<User> userManager, IRegister register)
        {
            _userManager = userManager;
            _register = register;
        }

        [HttpPost("register")]
        #region
        //public async Task<IActionResult> Register([FromBody] RegisterNewUser model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    else
        //    {
        //        var user = new User { UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (!result.Succeeded)
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);

        //            }
        //            return BadRequest(ModelState);
        //        }
        //        else
        //        {
        //            return Ok(new {Message = "User registration successful"});
        //        }
        //    }
        //}
        #endregion

        public async Task<IActionResult> Register([FromBody] RegisterNewUser model, string role)
        {

            var registerResult = await _register.RegisterUserAsync(model, ModelState, role);

            if (!registerResult)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(new
                {
                    Message = "user registration successful"
                });
            }


        }
    }
}
