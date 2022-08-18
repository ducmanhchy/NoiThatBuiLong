namespace BlogSystem.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui l�ng nh?p m?t kh?u hi?n t?i")]
        [DataType(DataType.Password)]
        [Display(Name = "M?t kh?u hi?n t?i")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui l�ng nh?p m?t kh?u m?i")]
        [StringLength(100, ErrorMessage = "{0} ph?i c� �t nh?t {2} k� t?.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "M?t kh?u m?i")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "X�c nh?n m?t kh?u m?i")]
        [Compare("NewPassword", ErrorMessage = "X�c nh?n m?t kh?u kh�ng kh?p")]
        public string ConfirmPassword { get; set; }
    }
}