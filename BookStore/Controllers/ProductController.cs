using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class ProductController : Controller
    {
        BookStoreContext _Context;
        public ProductController(BookStoreContext Context)
        {
            _Context = Context;
        }

        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["Name"] = name;
            var Product = _Context.categoryToProducts.Where(CP => CP.CategoryId == id).Include(p => p.Product).Select(p => p.Product).ToList();
            return View(Product);
        }
    }
}
