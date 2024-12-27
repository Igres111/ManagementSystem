using System.ComponentModel.DataAnnotations;

namespace ManagmentSystemApi.Dtos
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(40, ErrorMessage = "The field must not exceed 40 characters.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name field is required.")]
        [StringLength(40, ErrorMessage = "The field must not exceed 40 characters.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Age field is required.")]
        [Range(1, 99, ErrorMessage = "Age must be more than 0 and less than 100.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email field is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|org|net)$",
        ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password field is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, include an uppercase letter, a lowercase letter, and a number. Special characters are not allowed.")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role field is required.")]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Role must be 'Admin' or 'User'.")]
        public string Role { get; set; } = string.Empty;

    }
}
