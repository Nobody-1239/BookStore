using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="لطفا نام را وارد کنید")]
        [MaxLength(10)]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage ="لطفا نام خانوادگی را وارد کنید")]
        [MaxLength(20)]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="لطفا ایمیل را وارد کنید")]
        [MaxLength(100)]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage ="لطفا رمز عبور را وارد کنید")]
        [MaxLength(100)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage ="لطفا تکرار رمز عبور را وارد کنید")]
        [MaxLength(100)]
        [Compare("Password")]
        [Display(Name = "تکرار رمز عبور")]
        public string RePassword { get; set; }
    }
}
