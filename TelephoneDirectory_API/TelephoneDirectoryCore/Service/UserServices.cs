using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelephoneDirectoryCore.Service.Implementation.IServices.IAuth;
using TelephoneDirectory_API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TelephoneDirectoryCore.Service
{
    public class UserServices :IUserServices
    {
        private readonly UserManager<User> _userManager;
       // private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new NotFoundObjectResult(new { Message = "User not found." });
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(new { Message = "Failed to delete user." });
            }

            return new OkObjectResult(new { Message = "User deleted successfully" });
        }

        public async Task<IActionResult> GetAllUsers(int page, int pageSize)
        {
            var totalUsers = await _userManager.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalUsers / (double)pageSize);
            page = Math.Max(1, Math.Min(totalPages, page));

            var users = await _userManager.Users
                .OrderBy(u => u.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var paginatedResult = new PaginatedUser
            {
                TotalUsers = totalUsers,
                CurrentPage = page,
                PageSize = pageSize,
                Users = users

            };

            return new OkObjectResult(paginatedResult);
        }

        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new NotFoundObjectResult(new { Message = "User not found." });
            }

            return new OkObjectResult($"Great news!, User '{user.UserName}' was found");
        }

        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new NotFoundObjectResult(new { Message = "User not found." });
            }

            return new OkObjectResult($"Great news!, User '{user.Id}' was found");
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

        public async Task<List<User>> SearchUsersAsync(string searchTerm)
        {
            try
            {
                var result = await _userManager.Users
                .Where(user => user.UserName.Contains(searchTerm) || user.Email.Contains(searchTerm) || user.Id.Contains(searchTerm)
                || user.PhoneNumber.Contains(searchTerm)).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

        }
        public async Task<IActionResult> UpdateUser(string id, PutViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new NotFoundObjectResult(new { Message = "User not found" });
            }

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = model.Password;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(new { Message = "Failed to update user." });
            }

            return new OkObjectResult(new { Message = "User updated successfully." });

        }


    }
}
