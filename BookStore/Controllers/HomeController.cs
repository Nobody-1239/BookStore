using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using MyEshop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStoreContext _context;

        public HomeController(ILogger<HomeController> logger, BookStoreContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var product = _context.products
                .Include(p => p.item)
                .Include(p => p.CategoryToProducts)
                    .ThenInclude(cp => cp.Category)
                .SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            var vm = new DetailViewModel
            {
                product = product,
                category = product.CategoryToProducts.Select(cp => cp.Category).ToList()
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult AddToCart(int itemid)
        {
            var product = _context.products
                .Include(p => p.item)
                .SingleOrDefault(p => p.Id == itemid);

            if (product == null)
                return NotFound();

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var order = _context.Orders
                .FirstOrDefault(o => o.UserID == userId && !o.IsShipped);

            if (order == null)
            {
                order = new Order
                {
                    UserID = userId,
                    CreatData = DateTime.Now,
                    IsShipped = false
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
            }

            var orderDetail = _context.OrderDetails
                .FirstOrDefault(od => od.OrderID == order.OrderID && od.ProductId == product.Id);

            if (orderDetail != null)
            {
                orderDetail.Quantity += 1;
            }
            else
            {
                _context.OrderDetails.Add(new OrderDetial
                {
                    OrderID = order.OrderID,
                    ProductId = product.Id,
                    Price = product.item.Price,
                    Quantity = 1
                });
            }

            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        [Route("shopping-cart")]
        public IActionResult ShowCart()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var order = _context.Orders
                .Include(o => o.OrderDetials)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.item)
                .FirstOrDefault(o => o.UserID == userId && !o.IsShipped);

            if (order == null || order.OrderDetials == null)
                return View(Enumerable.Empty<object>());

            var cartItems = order.OrderDetials.Select(d => new
            {
                Name = d.Product.Name,
                Price = d.Product.item.Price,
                Quantity = d.Quantity,
                ProductId = d.ProductId,
                TotalPrice = d.Quantity * d.Product.item.Price,
                DetailId = d.DetailId
            }).ToList();

            return View(cartItems);
        }


        public IActionResult Delete(int id)
        {
            var orderDetail = _context.OrderDetails.SingleOrDefault(c => c.DetailId == id);
            if (orderDetail == null)
                return NotFound();

            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return View(new List<Product>());

            var result = _context.products
                .Where(p => p.Name.Contains(query))
                .ToList();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
