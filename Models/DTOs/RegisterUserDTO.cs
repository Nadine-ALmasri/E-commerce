namespace E_commerce.Models.DTOs
{
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public IList<string> ? Roles { get; set; }

    }
}
