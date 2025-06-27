using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class OrderDetial
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
