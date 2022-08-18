namespace BlogSystem.Web.Areas.Administration.ViewModels.Posts
{
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;
   
    using AutoMapper;

    using BlogSystem.Data.Models;
    using BlogSystem.Web.Infrastructure.Mapping;
    using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
    using System.Web;
    using BlogSystem.Web.App_Start.Identity;

    public class PostViewModel : AdministrationViewModel, IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("TinyMCE")]
        [Display(Name = "Nội dung chi tiết")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Nội dung tóm tắt")]
        public string ShortContent { get; set; }

        public string AuthorId { get; set; }


        [Display(Name = "Người tạo")]
        public string Author { get; set; }


        [Display(Name = "Công khai bản ghi")]
        public bool isPublish { get; set; }

        public string type { get; set; }

        public string linkIMG { get; set; }


        [Display(Name = "Tiêu đề ảnh")]
        public string TitleIMG { get; set; }


        [Display(Name = "Trạng thái")]
        public int status { get; set; }

        [Required]
        [Display(Name = "Tải ảnh lên")]
        [AllowFileSize(FileSize = 3 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 3 MB")]
        public HttpPostedFileBase ImgPost { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Post, PostViewModel>().ForMember(m => m.Author, c => c.MapFrom(p => p.Author.UserName));
        }
    }
}