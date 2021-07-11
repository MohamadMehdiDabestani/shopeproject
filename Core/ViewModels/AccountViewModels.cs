using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.ViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter an Email Valid")]
        [EmailAddress(ErrorMessage = "Please Enter an Email Valid")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(256)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "رمز عبور")]
        [MaxLength(256)]
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [EmailAddress(ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(256)]
        public string Password { get; set; }

        public bool RemmeberMe { get; set; }

        public string Redirect { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [EmailAddress(ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
    public class EnterNewPasswordViewModel
    {
        [Required]
        public int UserId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "رمز عبور")]
        [MaxLength(256)]
        public string Password { get; set; }
    }
    public class AccountViewModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public int Id { get; set; }
    }
    public class EditeAccountViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [EmailAddress(ErrorMessage = "یک ایمیل معتبر وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Range(1, 11, ErrorMessage = "شماره صحیح نیست")]
        public int Phone { get; set; }

        public IFormFile Image { get; set; }
    }
    public class ResetPasswordViewModel
    {

        [Display(Name = "رمز عبور فعلی")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(256)]
        public string CurrectPassword { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(256)]
        public string NewPassword { get; set; }
    }
    public class GetCartViewModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string ImageName { get; set; }

        public int Id { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        public string AltImage { get; set; }

        public int Quentity { get; set; }
    }
    public class GetWishListViewModel
    {
        public string Title { get; set; }

        public int GroupId { get; set; }

        public string AltImage { get; set; }

        public int Id { get; set; }

        public string GroupTitle { get; set; }

        public int Price { get; set; }

        public string ImageName { get; set; }

        public int ProductId { get; set; }

        public bool InCart { get; set; }
        
        
    }
    public class UpdateCartViewModel
    {
        public int Count { get; set; }
        public int Id { get; set; }
    }
    public class CheckoutViewModel {

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره ی همراه")]
        [MaxLength(200)]
        [Range(1, 11, ErrorMessage = "{0} معتبر نیست")]
        public int Phone { get; set; }
        
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "آدرس")]
        [MaxLength(600)]
        public string Addres { get; set; }
        
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "پستال کد")]
        [MaxLength(10)]
        [Range(1, 10, ErrorMessage = "{0} معتبر نیست")]
        public int PostalCode { get; set; }
    }
}