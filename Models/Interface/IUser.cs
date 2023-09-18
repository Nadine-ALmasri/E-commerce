using E_commerce.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_commerce.Models.Interface
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);
        public Cart LoadShoppingCartForUser(UserDTO user);
        public Task<UserDTO> GetUser(string username);
        public Task Logout();
    }
}
