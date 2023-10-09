using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectoryModel.ModelView;

namespace TelephoneDirectoryCore.Implementation.IServices
{
    public interface IUserServices
    {
        Task<IActionResult> DeleteUser(string id);

        Task<IActionResult> GetAllUsers(int page, int pageSize);

        Task<IActionResult> GetUserByEmail(string email);

        Task<IActionResult> GetUserById(string Id);

        //Task<IActionResult> AddNewUser(PostNewUser model);

        Task<IActionResult> UpdateUser(string id, PutViewModel model);

        public Task<List<User>> SearchUsersAsync(string searchTerm);

    }
}


