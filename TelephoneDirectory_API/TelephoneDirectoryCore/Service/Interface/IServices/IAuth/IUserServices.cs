using TelephoneDirectoryModel.Entity;
using Microsoft.AspNetCore.Mvc;
using TelephoneDirectoryModel.ModelView;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TelephoneDirectory_API.Models.ViewModels;

namespace TelephoneDirectoryCore.Service.Implementation.IServices.IAuth
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
        public Task<bool> RegisterUserAsync(RegisterNewUser model, ModelStateDictionary modelState, string role);

    }
}


