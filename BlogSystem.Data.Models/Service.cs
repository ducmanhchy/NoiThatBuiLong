using BlogSystem.Data.Contracts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Data.Models
{
    public class Service : BaseModel<int>
    {
        public Service()
        {

        }

        [MinLength(3, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Title { get; set; }

        public string ShortContent { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

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
