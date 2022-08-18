using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Web.Identity;

namespace BlogSystem.Web.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [Display(Name = "Email")]
        [CustomEmailValidator(ErrorMessage = "Email không đúng định dạng vd: abc@xyz.com")]
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

        [Display(Name = "Ghi nhớ trình duyệt?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [Display(Name = "Email")]
        [CustomEmailValidator(ErrorMessage = "Email không đúng định dạng vd: abc@xyz.com")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Lưu thông tin đăng nhập?")]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [CustomEmailValidator(ErrorMessage = "Email không đúng định dạng vd: abc@xyz.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "{0} phải có ít nhất {2} kí tự.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string UserName { get; set; }

        public string AccountName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "{0} phải có ít nhất {2} kí tự.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [CustomEmailValidator(ErrorMessage = "Email không đúng định dạng vd: abc@xyz.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu hiện tại")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "{0} phải có ít nhất {2} kí tự.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Xác nhận mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
    }
}
