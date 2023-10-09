using TelephoneDirectoryModel.Entity;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllUsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public GetAllUsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("all-users")]
        public async Task <IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
        {
            var totalUsers = await _userManager.Users.CountAsync();
            var totalPages = (int)Math.Ceiling(totalUsers / (double) pageSize);
            page = Math.Max(1,Math.Min (totalPages, page));
                     
            var users = await _userManager.Users
               .OrderBy(u => u.Id)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
            var PaginatedResult = new PaginatedUser
            {
                TotalUsers = totalUsers,
                CurrentPage = page,
                PageSize = pageSize,
                Users = users
            };
            return Ok(PaginatedResult); 

        }
    }
}
