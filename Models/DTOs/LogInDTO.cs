using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models.DTOs
{
    public class LogInDTO
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
