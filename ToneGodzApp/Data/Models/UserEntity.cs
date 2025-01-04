using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ToneGodzApp.Data.Models
{
    public class UserEntity : IdentityUser
    {
        public virtual ICollection<PaymentEntity> Payments { get; set; }
        [Required]
        public bool TermsOfUseAccepted { get; set; }
    }
}