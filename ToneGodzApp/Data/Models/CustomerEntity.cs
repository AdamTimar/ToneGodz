using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToneGodzApp.Data.Models
{
    public class CustomerEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey(nameof(ProductEntity))]
        public int? ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}