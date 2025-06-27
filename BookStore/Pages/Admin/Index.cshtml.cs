using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> products { get; set; }
        private readonly BookStoreContext _context;
        public IndexModel(BookStoreContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            products = _context.products.Include(i => i.item);
        }
        public void OnPost()
        {
        }
    }
}
