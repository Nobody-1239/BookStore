using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class LoginViewModel
    {
            [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
            [MaxLength(100)]
            [Display(Name = "ایمیل")]
            public string Email { get; set; }

            [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
            [MaxLength(100)]
            [Display(Name = "رمز عبور")]
            public string Password { get; set; }

            [Display(Name = "مرا به خاطر بسپار")]
            public bool RememberMe { get; set; }
    }
}
