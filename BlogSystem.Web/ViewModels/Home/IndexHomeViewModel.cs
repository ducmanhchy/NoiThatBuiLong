using BlogSystem.Web.ViewModels.Posts;
using System.Collections.Generic;

namespace BlogSystem.Web.ViewModels.Home
{
    public class IndexHomeViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public CustomerContactViewModel CustomerContactViewModel { get; set; }
    }
}