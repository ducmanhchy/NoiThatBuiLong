using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogSystem.Data.Models;
using BlogSystem.Web.Infrastructure.Mapping;
using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using BlogSystem.Web.Infrastructure.Helpers.Url;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Comments
{
    public class CollectionViewModel: AdministrationViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        private readonly IUrlGenerator urlGenerator;

        public CollectionViewModel() : this(new UrlGenerator())
        {

        }

        public CollectionViewModel(IUrlGenerator urlGenerator)
        {
            this.urlGenerator = urlGenerator;
        }

        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("TinyMCE")]
        public string Content { get; set; }

        public string Author { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public string Post { get; set; }

        public string PostUrl => this.urlGenerator.GenerateUrl(this.Post);

        [Required]
        public int PostId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Comment, CollectionViewModel>()
                .ForMember(m => m.Author, c => c.MapFrom(comment => comment.Author.UserName))
                .ForMember(m => m.Post, c => c.MapFrom(comment => comment.Post.Title));
        }
    }
}