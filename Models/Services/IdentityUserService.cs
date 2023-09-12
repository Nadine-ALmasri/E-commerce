using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using E_commerce.Data;
namespace E_commerce.Models.Services
{
    public class IdentityUserService : IUser
    {
        private readonly E_commerceDbContext _context;
        private  SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        public IdentityUserService(SignInManager<ApplicationUser> signInManager  , UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);

                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            return null;
        }

        public async Task<UserDTO> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return  new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = await _userManager.GetRolesAsync(user)
            };
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = data.UserName,
                PhoneNumber = data.Phone,
                Email = data.Email,
              
            };

            var result = await _userManager.CreateAsync(user, data.Password );
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, data.Roles);

                UserDTO userDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(RegisterUserDTO.UserName) :
                    "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
