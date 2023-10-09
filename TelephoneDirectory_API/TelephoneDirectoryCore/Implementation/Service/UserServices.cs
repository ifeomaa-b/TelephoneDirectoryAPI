using TelephoneDirectoryCore.Implementation.IServices;
using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContactBookCore.Implementation.Service
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;

        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
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
