using System.ComponentModel.DataAnnotations;


namespace BookStore.Models
{
    public class CartItem
    {
        [Key] 
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Required]
        public Item Item { get; set; }

        public decimal GetQuantityPrice()
        {
            return Item.Price * Quantity;
        }
    }
}