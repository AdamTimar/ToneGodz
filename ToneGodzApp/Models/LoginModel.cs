using System.ComponentModel.DataAnnotations;

namespace ToneGodzApp.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password length should be at least 8 digits.")]
        [RegularExpression(@"^(?=.*\d).*$", ErrorMessage = "Password must contain at least one digit.")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}