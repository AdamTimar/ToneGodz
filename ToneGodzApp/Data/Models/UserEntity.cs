using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ToneGodzApp.Data.Models
{
    public class UserEntity : IdentityUser
    {
        public bool TermsOfUseAccepted { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}