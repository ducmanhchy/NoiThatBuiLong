using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using BlogSystem.Data.Contracts.Models;

namespace BlogSystem.Data.Models
{
    public class Post : BaseModel<int>
    {
        public Post()
        {
            
        }

        [Required]
        [MinLength(3, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string ShortContent { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [MinLength(10, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        public bool isPublish { get; set; }

        public string type { get; set; }

        public string ParentType { get; set; }

        public string linkIMG { get; set; }

        public string TitleIMG { get; set; }

        public int status { get; set; }

        public string Desc { get; set; }

        public string LinkPost { get; set; }

        public int Ord { get; set; }

    }
}