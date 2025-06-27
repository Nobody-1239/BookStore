using System.Collections.Generic; // اضافه شد
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public int ItemId { get; set; }
        public Item item { get; set; }

        public virtual ICollection<CategoryToProduct> CategoryToProducts { get; set; } = new List<CategoryToProduct>();

        //public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}