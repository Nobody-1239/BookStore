using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly BookStoreContext _context;

        public CreateModel(BookStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
