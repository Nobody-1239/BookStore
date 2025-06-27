using AspNetCoreGeneratedDocument;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private BookStoreContext _Context;

        public AccountController(BookStoreContext context)
        {
            _Context = context;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
                return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            Users User = new Users
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };
            _Context.Users.Add(User);
            _Context.SaveChanges();
            return View("/Views/Account/RegisterMessage.cshtml",user);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = _Context.Users.FirstOrDefault(u => u.Email == viewModel.Email && u.Password == viewModel.Password);
            if(user == null)
            {
                ModelState.AddModelError("Email", "ایمیل یا رمز عبور اشتباه است");
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = viewModel.RememberMe
            };

            await HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Account/Login");
        }
        #endregion
    }
}
