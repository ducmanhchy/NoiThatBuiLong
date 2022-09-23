using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.Web.App_Start.Identity;
using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using BlogSystem.Web.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Services
{
    public class ServiceViewModel : AdministrationViewModel, IMapFrom<Service>, IHaveCustomMappings
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

        [Display(Name = "Nội dung tóm tắt")]
        public string ShortContent { get; set; }

        public string AuthorId { get; set; }


        [Display(Name = "Người tạo")]
        public string Author { get; set; }


        [Display(Name = "Công khai bản ghi")]
        public bool isPublish { get; set; }

        public string type { get; set; }
        public string typeFullName {
            get
            {
                return MappedProperty.GetServiceTypeByKey(type);
            }
        }
        public string ParentType { get; set; }
        public string ParentTypeFullName
        {
            get
            {
                return MappedProperty.GetMenuTypeByKey(ParentType);
            }
        }

        public string linkIMG { get; set; }


        [Display(Name = "Tiêu đề ảnh")]
        public string TitleIMG { get; set; }


        [Display(Name = "Trạng thái")]
        public int status { get; set; }

        [Display(Name = "Tải ảnh lên")]
        [AllowFileSize(FileSize = 3 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 3 MB")]
        public HttpPostedFileBase ImgPost { get; set; }

        [Display(Name = "Mô tả")]
        public string Desc { get; set; }

        [Display(Name = "Link bài viết")]
        public string LinkPost { get; set; }

        [Display(Name = "Thứ tự sắp xếp")]
        public int Ord { get; set; }
        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Service, ServiceViewModel>().ForMember(m => m.Author, c => c.MapFrom(p => p.Author.UserName));
        }
    }
}