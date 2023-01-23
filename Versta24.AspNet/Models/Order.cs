using System.ComponentModel.DataAnnotations;

namespace Versta24.AspNet.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SenderCity { get; set; }
        [Required]
        public string SenderAddres { get; set; }
        [Required]
        public string RecipientCity { get; set;}
        [Required]
        public string RecipientAddres { get; set;}
        [Required]
        public float Weight { get; set;}
        [Required]
        public DateTime DateTime { get; set;}
    }
}
