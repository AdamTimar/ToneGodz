using System.ComponentModel.DataAnnotations;

namespace ToneGodzApp.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}