using System.ComponentModel.DataAnnotations;

namespace EasyGrow.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password should have at least 6 symbols", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
