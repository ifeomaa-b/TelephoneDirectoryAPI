using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectoryCore.Service.Implementation.IServices.IAuth;

namespace TelephoneDirectory_API.Controllers.CRUD
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class EndPointController : ControllerBase
    {
        private readonly IUserServices _crud;

        public EndPointController(IUserServices crud)
        {
            _crud = crud;
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return await _crud.DeleteUser(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
        {
            return await _crud.GetAllUsers(page, pageSize);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            return await _crud.GetUserByEmail(email);
        }

       // [Authorize(Roles = "Admin")]
        [HttpGet("search-term")]
        public async Task<IActionResult> SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term is required.");
            }

            var users = await _crud.SearchUsersAsync(searchTerm);

            return Ok(users);
        }

        [HttpGet("Get user by Id")]

        public async Task<IActionResult> GetuserById(string id)
        {
            return await _crud.GetUserById(id);
        }

        
        //[Authorize(Roles ="Regular")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] PutViewModel model)
        {
            return await _crud.UpdateUser(id, model);
        }


    }

}
