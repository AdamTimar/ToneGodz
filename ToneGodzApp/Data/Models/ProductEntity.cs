using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToneGodzApp.Data.Enums;

namespace ToneGodzApp.Data.Models
{
    public class ProductEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public ProductType Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string StripePriceId { get; set; }

        public ICollection<CustomerEntity> Customers { get; set; }

        public ICollection<PaymentEntity> Payments { get; set; }
    }
}