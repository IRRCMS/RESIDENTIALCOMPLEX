using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace IRRCMS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = " ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور وارد شده با رمز وارد شده مطابقت ندارد")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        
        [Required(ErrorMessage ="وارد نمودن شماره تلفن همراه الزمی است")]
        [Phone(ErrorMessage ="لطفا شماره همراه را به طرز صحیح وارد نمایید")]
        [Display(Name ="شماره تلفن همراه")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage ="وارد کردن شماره ملی الزامی است")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "شماره ملی باید شامل ۱۰ رقم باشد"), Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }

        [MaxLength(1), Display(Name = "جنسیت")]
        public string Gender { get; set; }

        [Display(Name = "تلفن ثابت")]
        public string PhoneNumber { get; set; }

        [Display(Name = "وضعیت تاهل"), MaxLength(10)]
        public string MartialStatus { get; set; }

        public enum MartialStatusEnum
        {
            مجرد,
            متاهل
        }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
