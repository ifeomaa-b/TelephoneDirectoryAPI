/*using TelephoneDirectoryCore.Service.Implementation;
using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TelephoneDirectory_API.Models.ViewModels;

namespace TelephoneDirectoryCore.Service.Auth
{
    public class Register 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public Register(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> RegisterUserAsync(RegisterNewUser model, ModelStateDictionary modelState, string role)
        {
            if (!modelState.IsValid)
            {
                return false;
            }
            else
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                };
                if (await _roleManager.RoleExistsAsync(role))
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            modelState.AddModelError(string.Empty, error.Description);
                        }
                        return false;
                    }
                    await _userManager.AddToRoleAsync(user, role);
                    return true;

                }
                return false;

            }

        }

    }
}
*/