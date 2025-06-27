using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; } = new List<CategoryToProduct>();
    }
}