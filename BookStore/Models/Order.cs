using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public DateTime CreatData { get; set; }
        public bool IsShipped { get; set; }

        public Users User { get; set; }
        public List<OrderDetial> OrderDetials { get; set; }
    }
}
