using Microsoft.AspNetCore.Mvc.ModelBinding;
using TelephoneDirectory_API.Models.ViewModels;

namespace TelephoneDirectoryCore.Implementation.IServices.IAuth
{
    public interface IRegister
    {
        public Task<bool> RegisterUserAsync(RegisterNewUser model, ModelStateDictionary modelState, string role);

    }
}
