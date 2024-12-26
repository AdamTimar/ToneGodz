using System.ComponentModel.DataAnnotations;

namespace ToneGodzApp.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password length should be at least 8 digits.")]
        [RegularExpression(@"^(?=.*\d).*$", ErrorMessage = "Password must contain at least one digit.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Code { get; set; }
    }
}