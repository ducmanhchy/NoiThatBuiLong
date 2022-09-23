using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Excute
{
    public class ExcuteViewModel
    {
        [Required]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public string Result { get; set; }

    }
}