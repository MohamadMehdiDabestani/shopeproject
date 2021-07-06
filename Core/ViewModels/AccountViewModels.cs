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
        
        
    }
}