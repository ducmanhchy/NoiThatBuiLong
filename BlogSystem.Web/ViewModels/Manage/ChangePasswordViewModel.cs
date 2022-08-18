namespace BlogSystem.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nh?p m?t kh?u hi?n t?i")]
        [DataType(DataType.Password)]
        [Display(Name = "M?t kh?u hi?n t?i")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nh?p m?t kh?u m?i")]
        [StringLength(100, ErrorMessage = "{0} ph?i có ít nh?t {2} kí t?.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "M?t kh?u m?i")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nh?n m?t kh?u m?i")]
        [Compare("NewPassword", ErrorMessage = "Xác nh?n m?t kh?u không kh?p")]
        public string ConfirmPassword { get; set; }
    }
}