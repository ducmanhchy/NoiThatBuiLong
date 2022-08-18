using BlogSystem.Web.Areas.Administration.ViewModels.Administration;
using System.Collections.Generic;

namespace BlogSystem.Web.Areas.Administration.ViewModels.Posts
{
    public class IndexPostsPageViewModel : PaginationViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}