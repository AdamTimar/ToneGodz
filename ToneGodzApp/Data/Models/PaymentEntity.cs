using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToneGodzApp.Data.Models
{
    public class PaymentEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(UserEntity))]
        [Required]
        public string UserId { get; set; }

        public UserEntity User { get; set; }

        [Required]
        public string PaymentIntentId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string SessionId { get; set; }
    }
}