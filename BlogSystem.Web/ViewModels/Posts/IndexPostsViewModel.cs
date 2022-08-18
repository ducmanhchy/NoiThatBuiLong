using System.Collections.Generic;

namespace BlogSystem.Web.ViewModels.Posts
{
    public class IndexPostsViewModel : PaginationViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}