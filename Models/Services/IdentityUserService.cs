using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using E_commerce.Data; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace E_commerce.Models.Services


{
    public class IdentityUserService : IUser
    {
       private readonly E_commerceDbContext _context;
        private  SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        public IdentityUserService(SignInManager<ApplicationUser> signInManager  , UserManager<ApplicationUser> userManager, E_commerceDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        /// <summary>
        /// this method is to allow the user to log in his account 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>UserDTO</returns>
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
        /// <summary>
        /// this method is to get the user by the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>UserDTO</returns>
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
        /// <summary>
        /// this method is to register new user 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="modelState"></param>
        /// <returns>"UserDTO"</returns>
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
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
      
            public Cart LoadShoppingCartForUser(UserDTO user)
            {
                var userId = user.Id;

                var Cart = _context.Cart
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .FirstOrDefault(c => c.UserId == userId);

                if (Cart == null)
                {
                    // If the user doesn't have a Cart in the database, create a new Cart.
                    Cart = new Cart
                    {
                        UserId = userId,
                        Total = 0,
                        CartProducts = new List<CartProducts>()
                    };

                    _context.Cart.Add(Cart);
                    _context.SaveChanges();
                }

                return Cart; // Return either the existing Cart or a new empty Cart.
            }



        }
    }
