using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // برای [ForeignKey]

namespace BookStore.Models
{
    public class CategoryToProduct
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        //Navigation Property
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}