using System.ComponentModel.DataAnnotations;

namespace ManagmentSystemApi.Dtos
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email field is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|org|net)$",
        ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
