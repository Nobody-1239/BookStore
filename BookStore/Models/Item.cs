using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Item
    {
        [Key]
        public int OrderId { get; set; }
        public Product product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}