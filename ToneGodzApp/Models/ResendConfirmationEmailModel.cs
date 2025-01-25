using System.ComponentModel.DataAnnotations;

namespace ToneGodzApp.Models
{
    public class ResendConfirmationEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}